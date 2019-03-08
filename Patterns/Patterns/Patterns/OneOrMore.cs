using Patterns;
using System;

namespace Patterns
{
    public class OneOrMore : IPattern
    {
        IPattern pattern;

        public OneOrMore(IPattern pattern)
        {
            this.pattern = pattern;
        }

        public IMatch Match(string text)
        {
            if (text == null)
                return (new Match(false, text));
            string remainingText = text;
            while (this.pattern.Match(remainingText).Success())
                remainingText = this.pattern.Match(remainingText).RemainingText();
            return text.Length > remainingText.Length 
                ? new Match(true, remainingText)
                : new Match(false, text);
        }
    }
}
