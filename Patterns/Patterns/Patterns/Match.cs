namespace Patterns
{
    public class Match : IMatch
    {
        bool isMatch;
        string remainingText;

        public Match(bool isMatch, string remainingText)
        {
            this.isMatch = isMatch;
            this.remainingText = remainingText;
        }

        public bool Success()
            => this.isMatch;

        public string RemainingText()
            => this.remainingText;
    }
}