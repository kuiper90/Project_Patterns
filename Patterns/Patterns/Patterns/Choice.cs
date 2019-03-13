using Patterns;

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
                IMatch match = pattern.Match(text);
                if (match.Success())
                    return (match);
            }
            return (new Match(false, text));
        }

        public void Add(IPattern pattern)
        {
            int len = this.patterns.Length;
            IPattern[] patt = new IPattern[len + 1];

            patterns.CopyTo(patt, 0);
            patt[len] = pattern;
            this.patterns = patt;            
        }

        static void Main()
        {

        }
    }
}

