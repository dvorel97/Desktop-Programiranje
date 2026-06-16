using Projekt.Services;

namespace Projekt
{
    public class NoteRepository<T> where T : Note
    {
        private SyncService syncService = new();
        private List<T> notes = new();
        private Dictionary<string, List<T>> notesByTag = new();
        private HashSet<string> uniqueTags = new();
        private readonly ReaderWriterLockSlim _searchLock = new();
        private readonly ReaderWriterLockSlim _indexLock = new();

        private Dictionary<string, List<T>> _searchIndex = new();

        public IReadOnlyList<T> Notes => notes.AsReadOnly();

        public void Add(T note, bool sync=true)
        {
            _searchLock.EnterWriteLock();
            try
            {
                notes.Add(note);
                foreach (var tag in note.Tags)
                {
                    if (!notesByTag.ContainsKey(tag))
                        notesByTag[tag] = new List<T>();
                    notesByTag[tag].Add(note);
                    uniqueTags.Add(tag);
                }
            }
            finally { _searchLock.ExitWriteLock(); }

            note.OnContentChanged += OnNoteContentChanged;
            if (sync)
            {
                syncService.SyncNote(note);
                OnNoteModified?.Invoke(note, "add");
            }

            RebuildSearchIndex();
        }

        public void Remove(T note)
        {
            _searchLock.EnterWriteLock();
            try
            {
                notes.Remove(note);

                foreach (var tag in note.Tags)
                {
                    if (notesByTag.ContainsKey(tag))
                    {
                        notesByTag[tag].Remove(note);
                        if (notesByTag[tag].Count == 0)
                        {
                            notesByTag.Remove(tag);
                            uniqueTags.Remove(tag);
                        }
                    }
                }
            }
            finally { _searchLock.ExitWriteLock(); }

            syncService.SyncDelete(note);
            OnNoteModified?.Invoke(note, "delete");
            RebuildSearchIndex();
        }

        public void Update(T note)
        {
            foreach (var tag in notesByTag.Keys.ToList())
            {
                notesByTag[tag].Remove(note);
                if (notesByTag[tag].Count == 0)
                {
                    notesByTag.Remove(tag);
                    uniqueTags.Remove(tag);
                }
            }

            foreach (var tag in note.Tags)
            {
                uniqueTags.Add(tag);
                if (!notesByTag.ContainsKey(tag))
                    notesByTag[tag] = new List<T>();
                notesByTag[tag].Add(note);
            }

            syncService.SyncUpdate(note);
            OnNoteModified?.Invoke(note, "update");
            RebuildSearchIndex();
        }

        public List<SearchResult> Search(string query)
        {
            _indexLock.EnterReadLock();
            try
            {
                var results = new List<SearchResult>();
                var words = query.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                foreach (var word in words)
                {
                    if (_searchIndex.TryGetValue(word, out var matches))
                    {
                        foreach (var note in matches)
                        {
                            int titleMatches = CountOccurrences(note.Title, word);
                            int contentMatches = CountOccurrences(note.Content ?? "", word);

                            if (titleMatches > 0)
                                results.Add(new SearchResult(note, "Title", titleMatches));
                            if (contentMatches > 0)
                                results.Add(new SearchResult(note, "Content", contentMatches));
                        }
                    }
                }
                return results;
            }
            finally { _indexLock.ExitReadLock(); }
        }

        private int CountOccurrences(string text, string query)
        {
            if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(query)) return 0;
            int count = 0, index = 0;
            while ((index = text.IndexOf(query, index,
                StringComparison.OrdinalIgnoreCase)) != -1)
            {
                count++;
                index += query.Length;
            }
            return count;
        }

        public List<T> GetByType(NoteType type)
        {
            var results = new List<T>();
            foreach (var note in notes)
                if (note.Type == type)
                    results.Add(note);
            return results;
        }

        public List<T> GetByTag(string tag)
        {
            return notesByTag.ContainsKey(tag) ? notesByTag[tag] : new List<T>();
        }

        public T GetById(string id)
        {
            foreach (var note in notes)
                if (note.Id == id)
                    return note;
            throw new NoteNotFoundException(id);
        }

        private void OnNoteContentChanged(Note note)
        {
            syncService.SyncUpdate(note);
        }

        private void RebuildSearchIndex()
        {
            Thread thread = new Thread(() =>
            {
                var newIndex = new Dictionary<string, List<T>>(StringComparer.OrdinalIgnoreCase);

                _searchLock.EnterReadLock();
                var snapshot = notes.ToList();
                _searchLock.ExitReadLock();

                foreach (var note in snapshot)
                {
                    var words = (note.Title + " " + note.Content)
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    foreach (var word in words)
                    {
                        if (!newIndex.ContainsKey(word))
                            newIndex[word] = new List<T>();
                        if (!newIndex[word].Contains(note))
                            newIndex[word].Add(note);
                    }
                }

                _indexLock.EnterWriteLock();
                try { _searchIndex = newIndex; }
                finally { _indexLock.ExitWriteLock(); }
            });
            thread.IsBackground = true;
            thread.Start();
        }

        public delegate void NoteModifiedHandler(T note, string action);
        public event NoteModifiedHandler OnNoteModified;
        public IReadOnlyDictionary<string, List<T>> NotesByTag => notesByTag;
        public IReadOnlySet<string> UniqueTags => uniqueTags;
    }
}
