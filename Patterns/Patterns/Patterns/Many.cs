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
            IMatch isMatch = this.pattern.Match(text);
            while (isMatch.Success())
            {
                isMatch = this.pattern.Match(isMatch.RemainingText());
            }

            return new Match(true, isMatch.RemainingText());
        }
    }
}