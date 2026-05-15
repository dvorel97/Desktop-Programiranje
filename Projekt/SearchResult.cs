using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt
{
    public struct SearchResult
    {
        public Note Note { get; init; }
        public string MatchedField { get; init; }
        public int MatchCount { get; init; }

        public SearchResult(Note note, string matchedField, int matchCount)
        {
            Note = note;
            MatchedField = matchedField;
            MatchCount = matchCount;
        }
    }
}
