using Projekt.DB;

namespace Projekt.Services
{
    public class SyncService
    {
        private readonly DBService _db = new();

        public void SyncNote(Note note) => RunInBackground(() => _db.SaveNote(note), note.Title, "Synced");

        public void SyncDelete(Note note) => RunInBackground(() => _db.DeleteNote(note.Id), note.Title, "Deleted");

        public void SyncUpdate(Note note) => RunInBackground(() => _db.UpdateNote(note), note.Title, "Updated");

        private void RunInBackground(Action action, string noteTitle, string successLabel)
        {
            Thread thread = new Thread(() =>
            {
                try
                {
                    action();
                    Console.WriteLine($"{successLabel}: {noteTitle}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{successLabel} error ({noteTitle}): {ex.Message}");
                }
            });
            thread.IsBackground = true;
            thread.Start();
        }
    }
}
