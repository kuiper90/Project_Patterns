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
            if (String.IsNullOrEmpty(text))
                return (new Match(false, text));
            bool success = false;
            foreach (char chr in this.accepted)
            {
                if (success = (text[0] == chr))
                    return (new Match(success, text.Remove(0, 1)));
            }
            return (new Match(false, text));
        }
    }
}
