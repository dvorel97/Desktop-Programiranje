using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt
{
        public class NoteRepository
        {
            private List<Note> notes = new();

            public IReadOnlyList<Note> Notes => notes.AsReadOnly();

            public void Add(Note note)
            {
                notes.Add(note);
                OnNoteModified?.Invoke(note, "Added");
            }

            public void Remove(Note note)
            {
                notes.Remove(note);
                OnNoteModified?.Invoke(note, "Removed");
            }

            public void Update(Note note)
            {
                OnNoteModified?.Invoke(note, "Updated");
            }

            public List<Note> Search(string query)
            {
                var results = new List<Note>();
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

            public List<Note> GetByType(NoteType type)
            {
                var results = new List<Note>();
                foreach (var note in notes)
                    if (note.Type == type)
                        results.Add(note);
                return results;
            }

            public delegate void NoteModifiedHandler(Note note, string action);
            public event NoteModifiedHandler OnNoteModified;
        }
    }
