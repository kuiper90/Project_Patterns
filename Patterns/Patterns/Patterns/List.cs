using System;

namespace Patterns
{
    public class List : IPattern
    {
        IPattern element;
        IPattern separator;

        public List(IPattern element, IPattern separator)
        {
            this.element = element;
            this.separator = separator;
        }

        public IMatch Match(string text)
        {
            if (String.IsNullOrEmpty(text))
                return (new Match(true, text));
            string remainingText = text;
            string tmp = "";

            //while (element.Match(remainingText).Success())
            //{
            //    remainingText = element.Match(remainingText).RemainingText();
            //    if (separator.Match(remainingText).Success())
            //    {
            //        tmp = separator.Match(remainingText).RemainingText();
            //        if (!(element.Match(tmp).Success()))                    
            //            return (new Match(true, remainingText));
            //        remainingText = separator.Match(remainingText).RemainingText();
            //    }
            //}
            //return (new Match(true, remainingText));

            if (element.Match(text).Success())
            {
                remainingText = element.Match(remainingText).RemainingText();
                tmp = remainingText;
                while (separator.Match(remainingText).Success())
                {
                    tmp = separator.Match(remainingText).RemainingText();
                    if (element.Match(tmp).Success())
                        remainingText = element.Match(tmp).RemainingText();
                    else
                        return new Match(true, remainingText);
                }
            }
            return new Match(true, remainingText);
        }
    }
}
