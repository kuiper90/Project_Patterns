using System;

namespace Patterns
{
    public class Many : IPattern
    {
        IPattern pattern;

        public Many(IPattern pattern)
        {
            this.pattern = pattern;
        }

        public IMatch Match(string text)
        {   
            IMatch match = this.pattern.Match(text);

            while (match.Success())
                match = this.pattern.Match(match.RemainingText());
            
            return new Match(true, match.RemainingText());
        }
    }
}
