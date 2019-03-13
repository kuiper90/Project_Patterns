using System;

namespace Patterns
{
    public class Optional : IPattern
    {
        IPattern pattern;

        public Optional(IPattern pattern)
        {
            this.pattern = pattern;
        }

        public IMatch Match(string text)
        {
            var match = this.pattern.Match(text);
            return new Match(true, match.Success() 
                ? match.RemainingText() 
                : text);
        }
    }
}
