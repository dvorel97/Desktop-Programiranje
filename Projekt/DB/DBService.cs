using Projekt.DB;

namespace Projekt.Services
{
    public class DBService
    {
        public void SaveNote(Note note)
        {
            using var noteContext = new NoteContext();
            noteContext.Notes.Add(new NoteEntity
            {
                Id = note.Id,
                Title = note.Title,
                Content = note.Content ?? "",
                Type = note.Type.ToString(),
                Created = note.Created,
                Modified = note.LastModified,
            });
            noteContext.SaveChanges();
        }

        public void DeleteNote(string id)
        {
            using var noteContext = new NoteContext();
            var entity = noteContext.Notes.Find(id);
            if (entity == null) return;
            noteContext.Notes.Remove(entity);
            noteContext.SaveChanges();
        }

        public void UpdateNote(Note note)
        {
            using var noteContext = new NoteContext();
            var entity = noteContext.Notes.Find(note.Id);
            if (entity == null) return;
            entity.Title = note.Title;
            entity.Content = note.Content ?? "";
            entity.Type = note.Type.ToString();
            entity.Modified = note.LastModified;
            noteContext.SaveChanges();
        }

        public List<Note> LoadNotes()
        {
            using var ctx = new NoteContext();
            var entities = ctx.Notes.ToList();

            var notes = new List<Note>();
            foreach (var entity in entities)
            {
                NoteType type = NoteType.Personal;
                if (!string.IsNullOrEmpty(entity.Type))
                    Enum.TryParse<NoteType>(entity.Type, out type);

                var note = new MarkdownNote(
                    entity.Id,
                    entity.Title ?? "Bez naslova",
                    entity.Content ?? "",
                    type
                );
                note.Content = entity.Content ?? "";
                notes.Add(note);
            }
            return notes;
        }
    }
}