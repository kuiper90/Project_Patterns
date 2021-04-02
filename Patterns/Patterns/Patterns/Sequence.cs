namespace Patterns
{
    public class Sequence : IPattern
    {
        IPattern[] patterns;

        public Sequence(params IPattern[] patterns)
        {
            this.patterns = patterns;
        }

        public IMatch Match(string text)
        {
            IMatch isMatch = new Match(true, text);
            foreach (var pattern in this.patterns)
            {
                isMatch = pattern.Match(isMatch.RemainingText());
                if (!isMatch.Success())
                {
                    return new Match(false, text);
                }
            }

            return new Match(true, isMatch.RemainingText());
        }
    }
}