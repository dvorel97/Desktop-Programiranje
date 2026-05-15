using Projekt.Services;

namespace Projekt
{
    public class NoteRepository<T> where T : Note
    {
        private List<T> notes = new();
        private SyncService syncService = new();

        public IReadOnlyList<T> Notes => notes.AsReadOnly();

        public void Add(T note)
        {
            notes.Add(note);
            note.OnContentChanged += OnNoteContentChanged;
            OnNoteModified?.Invoke(note, "Added");
            syncService.SyncNote(note);
        }

        public void AddLocal(T note)
        {
            notes.Add(note);
            note.OnContentChanged += OnNoteContentChanged;
            OnNoteModified?.Invoke(note, "Added");
        }

        public void Remove(T note)
        {
            notes.Remove(note);
            OnNoteModified?.Invoke(note, "Removed");
            syncService.SyncDelete(note);
        }

        public void Update(T note)
        {
            OnNoteModified?.Invoke(note, "Updated");
            syncService.SyncUpdate(note);
        }

        public List<T> Search(string query)
        {
            var results = new List<T>();
            foreach (var note in notes)
            {
                bool titleMatch = note.Title.Contains(query,
                    StringComparison.OrdinalIgnoreCase);
                bool contentMatch = note.Content?.Contains(query,
                    StringComparison.OrdinalIgnoreCase) ?? false;

                if (titleMatch || contentMatch)
                    results.Add(note);
            }
            return results;
        }

        public List<T> GetByType(NoteType type)
        {
            var results = new List<T>();
            foreach (var note in notes)
                if (note.Type == type)
                    results.Add(note);
            return results;
        }

        private void OnNoteContentChanged(Note note)
        {
            syncService.SyncUpdate(note);
        }

        public delegate void NoteModifiedHandler(T note, string action);
        public event NoteModifiedHandler OnNoteModified;
    }
}