using System;

namespace Patterns
{
    public class Choice : IPattern
    {
        IPattern[] patterns;

        public Choice(params IPattern[] patterns)
        {
            this.patterns = patterns;
        }

        public IMatch Match(string text)
        {
            foreach (var pattern in this.patterns)
            {
                IMatch isMatch = pattern.Match(text);
                if (isMatch.Success())
                {
                    return isMatch;
                }
            }

            return new Match(false, text);
        }

        public void Add(IPattern pattern)
        {
            int len = this.patterns.Length + 1;
            Array.Resize(ref patterns, len);
            this.patterns[len - 1] = pattern;
        }
    }
}