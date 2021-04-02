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
            IMatch isMatch = this.pattern.Match(text);
            return isMatch.Success() ?
                   new Match(true, isMatch.RemainingText()) :
                   new Match(true, text);
        }
    }
}