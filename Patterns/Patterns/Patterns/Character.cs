using Patterns;
using System;

namespace Patterns
{
    public class Character : IPattern
    {
        readonly char chr;

        public Character(char chr)
        {
            this.chr = chr;
        }

        public IMatch Match(string text)
        {
            if (String.IsNullOrEmpty(text))
                return (new Match(false, text));
            //bool success = text[0] == this.chr;
            //if (!success)
            //    return (new Match(false, text));
            //return (new Match(success, text.Remove(0, 1)));
            return (text[0] != this.chr ? new Match(false, text) : new Match(true, text.Substring(1)));
        }
    }
}
