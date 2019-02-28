using Patterns;
using System;

namespace Patterns
{
    public class Sequence : IPattern
    {
        IPattern[] patterns;

        public Sequence(params IPattern[] patterns)
        {
            this.patterns = patterns;
        }

        //public IMatch Match(string text)
        public IMatch Match(string text)
        {
            string remainingText = String.Copy(text);

            foreach (var pattern in this.patterns)
            {
                Match match = (Match)pattern.Match(remainingText);
                if (!match.Success())
                    return (new Match(false, text));
                else
                {
                    remainingText = match.RemainingText();
                    continue;
                }
            }
            return (new Match(true, remainingText));
        }
    }
}
