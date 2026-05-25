using Projekt.Services;

namespace Projekt
{
    public class NoteRepository<T> where T : Note
    {
        private SyncService syncService = new();
        private List<T> notes = new();
        private Dictionary<string, List<T>> notesByTag = new();
        private HashSet<string> uniqueTags = new();
        private SortedList<DateTime, T> notesByDate = new();
        private readonly ReaderWriterLockSlim _searchLock = new();

        public IReadOnlyList<T> Notes => notes.AsReadOnly();

        public void Add(T note, bool sync=true)
        {
            _searchLock.EnterWriteLock();
            try
            {
                //dodavanje note u repozitory
                notes.Add(note);
                //dodavanje note u sorted list by date
                notesByDate.Add(note.LastModified, note);
                //dodavanje note u dict by tag, i tag u unique tags
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

        }

        public void Remove(T note)
        {
            _searchLock.EnterWriteLock();
            try
            {
                notes.Remove(note);

                var key = notesByDate.Keys.FirstOrDefault(k => notesByDate[k].Id == note.Id);
                if (key != default)
                    notesByDate.Remove(key);

                // Ukloni iz Dictionary i HashSet
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
        }

        public void Update(T note)
        {
            // Azuriraj SortedList
            var key = notesByDate.Keys.FirstOrDefault(k => notesByDate[k].Id == note.Id);
            if (key != default)
                notesByDate.Remove(key);

            while (notesByDate.ContainsKey(note.LastModified))
                note.LastModified = note.LastModified.AddTicks(1);
            notesByDate.Add(note.LastModified, note);

            // Azuriraj tagove — ukloni stare, dodaj nove
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
        }

        public List<SearchResult> Search(string query)
        {
            _searchLock.EnterReadLock();
            try
            {
                var results = new List<SearchResult>();
                foreach (var note in notes)
                {
                    int titleMatches = CountOccurrences(note.Title, query);
                    int contentMatches = CountOccurrences(note.Content ?? "", query);

                    if (titleMatches > 0)
                        results.Add(new SearchResult(note, "Title", titleMatches));
                    else if (contentMatches > 0)
                        results.Add(new SearchResult(note, "Content", contentMatches));
                }
                return results;
            }
            finally
            {
                _searchLock.ExitReadLock();
            }
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

        public delegate void NoteModifiedHandler(T note, string action);
        public event NoteModifiedHandler OnNoteModified;
        public IReadOnlyDictionary<string, List<T>> NotesByTag => notesByTag;
        public IReadOnlySet<string> UniqueTags => uniqueTags;
        public IReadOnlyList<T> NotesByDate => notesByDate.Values.ToList();
    }
}