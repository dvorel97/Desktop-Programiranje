using Projekt.DB;

namespace Projekt.Services
{
    public class SyncService
    {
        private readonly DBService _db = new();

        public void SyncNote(Note note)
        {
            Thread thread = new Thread(() => SaveToDatabase(note));
            thread.IsBackground = true;
            thread.Start();
        }

        public void SyncDelete(Note note)
        {
            Thread thread = new Thread(() => DeleteFromDatabase(note));
            thread.IsBackground = true;
            thread.Start();
        }

        public void SyncUpdate(Note note)
        {
            Thread thread = new Thread(() => UpdateInDatabase(note));
            thread.IsBackground = true;
            thread.Start();
        }

        private void SaveToDatabase(Note note)
        {
            try
            {
                _db.SaveNote(note);
                Console.WriteLine($"Synced: {note.Title} (ID: {note.Id})");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Sync error: {ex.Message}");
            }
        }

        private void DeleteFromDatabase(Note note)
        {
            try
            {
                _db.DeleteNote(note.Id);
                Console.WriteLine($"Deleted: {note.Title}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Delete error: {ex.Message}");
            }
        }

        private void UpdateInDatabase(Note note)
        {
            try
            {
                _db.UpdateNote(note);
                Console.WriteLine($"Updated: {note.Title}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Update error: {ex.Message}");
            }
        }
    }
}