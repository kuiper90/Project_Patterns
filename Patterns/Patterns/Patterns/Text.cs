using System;

namespace Patterns
{
    public class Text : IPattern
    {
        string prefix;

        public Text(string prefix)
        {
            this.prefix = prefix;
        }

        public IMatch Match(string text)
        {
            if (this.prefix == "")
                return (new Match(text != null, text));
            int len = prefix.Length;
            return !String.IsNullOrEmpty(text) && text.StartsWith(prefix)
                ? new Match(true, text.Substring(len))
                : new Match(false, text);
        }
    }
}
