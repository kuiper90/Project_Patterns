using Patterns;
using System;

namespace Patterns
{
    public class Range : IPattern
    {
        char start;
        char end;

        public Range(char start, char end)
        {
            this.start = start;
            this.end = end;
        }

        public IMatch Match(string text)
        {
            if (String.IsNullOrEmpty(text))
                return (new Match(false, text));
            bool success = ((text[0] >= start) && (text[0] <= end));
            if (!success)
                return (new Match(false, text));
            return (new Match(success, text.Remove(0, 1)));            
        }
    }
}
