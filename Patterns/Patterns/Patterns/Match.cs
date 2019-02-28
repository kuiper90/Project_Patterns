using Patterns;

namespace Patterns
{
    public interface IMatch
    {
        bool Success();
        string RemainingText();
    }

    public interface IPattern
    {
        IMatch Match(string text);
    }

    class Match : IMatch
    {
        bool success;
        string remainingText;

        public Match(bool success, string remainingText)
        {
            this.success = success;
            this.remainingText = remainingText;
        }

        public bool Success()
        {
            return (this.success);
        }

        public string RemainingText()
        {
            return (this.remainingText);
        }
    }
}
