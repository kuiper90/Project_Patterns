using System;

namespace Patterns
{
    public class Any : IPattern
    {
        string accepted;

        public Any(string accepted)
        {
            this.accepted = accepted;
        }

        public IMatch Match(string text)
        {
            return !String.IsNullOrEmpty(text) && accepted.Contains(text[0].ToString())
                ? new Match(true, text.Substring(1))
                : new Match(false, text);
        }
    }
}
