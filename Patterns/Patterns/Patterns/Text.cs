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
            if (String.IsNullOrEmpty(text))
                return (new Match(false, text));   
            string remainingText = text;
            foreach (char chr in this.prefix)
            {
                if (remainingText[0] != chr)
                    return (new Match(false, text));
                else
                    remainingText = remainingText.Remove(0, 1);
            }
            return (new Match(true, remainingText));
        }
    }
}
