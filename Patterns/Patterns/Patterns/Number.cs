using System;

namespace Patterns
{
    public class Number : IPattern
    {
        private readonly IPattern pattern;

        public Number()
        {
            IPattern digit = new Range('0', '9');

            IPattern exponent = new Sequence(new Any("eE"), new Optional(new Any("+-")), new OneOrMore(digit));

            IPattern integerPart = new Sequence(new Optional(new Character('-')), 
                                                new Choice(new Character('0'), new OneOrMore(digit)));

            IPattern fractionalPart = new Sequence(new Character('.'), new OneOrMore(digit));

            pattern = new Sequence(integerPart, new Optional(fractionalPart), new Optional(exponent));
        }

        public IMatch Match(string text)
        {
            return (pattern.Match(text));
        }
    }
}
