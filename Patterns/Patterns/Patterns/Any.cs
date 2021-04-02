using System.Linq;

namespace Patterns
{
    public class Any : IPattern
    {
        private readonly string accepted;

        public Any(string accepted)
        {
            this.accepted = accepted;
        }

        public IMatch Match(string text)
            => !string.IsNullOrEmpty(text) && this.accepted.Contains(text[0])
                ? new Match(true, text.Substring(1))
                : new Match(false, text);
    }
}