using System;

namespace Projekt
{
    public class NoteNotFoundException : Exception
    {
        public string NoteId { get; }

        public NoteNotFoundException(string id)
            : base($"Bilješka s ID-om '{id}' nije pronađena.")
        {
            NoteId = id;
        }
    }
}
