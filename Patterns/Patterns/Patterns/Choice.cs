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

        static void Main()
        {

        }
    }
}

