using System;

namespace Patterns
{
    public class List : IPattern
    {
        IPattern element;
        IPattern template;

        public List(IPattern element, IPattern separator)
        {
            this.element = element;
            this.template = new Many(new Sequence(separator, element));
        }

        public IMatch Match(string text)
        {
            var match = element.Match(text);
            return match.Success()
                ? this.template.Match(match.RemainingText())
                : new Match(true, text);
        }
    }
}
