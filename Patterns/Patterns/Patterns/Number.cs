using System;

namespace Patterns
{
    public class Number : IPattern
    {
        private readonly IPattern pattern;

        public Number()
        {
            var digit = new Range('0', '9');

            var natural = new Choice(new Character('0'),
                                     new Sequence(new Range('1', '9'),
                                     new Many(digit)));

            var integer = new Sequence(new Optional(new Character('-')),
                                       natural);

            var exponent = new Sequence(new Any("eE"),
                                        new Optional(new Any("+-")),
                                        new OneOrMore(digit));

            var fractional = new Sequence(new Character('.'),
                                          new OneOrMore(digit));

            var generalIntegerPart = new Sequence(integer,
                                                  new Optional(fractional));

            pattern = new Sequence(generalIntegerPart,
                                   new Optional(exponent));
        }

        public IMatch Match(string text)
        {
            return (pattern.Match(text));
        }
    }
}
