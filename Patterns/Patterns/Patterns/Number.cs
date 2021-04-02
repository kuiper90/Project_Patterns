namespace Patterns
{
    public class Number : IPattern
    {
        private readonly IPattern pattern;

        public Number()
        {
            IPattern digit = new Range('0', '9');
            IPattern digits = new OneOrMore(digit);
            IPattern exponent = new Sequence(
                new Any("eE"),
                new Optional(new Any("+-")),
                digits);
            IPattern integer = new Sequence(
                new Optional(new Character('-')),
                new Choice(
                    new Character('0'),
                    digits));
            IPattern fractional = new Sequence(
                new Character('.'),
                digits);
            this.pattern = new Sequence(
                integer,
                new Optional(fractional),
                new Optional(exponent));
        }

        public IMatch Match(string text)
            => this.pattern.Match(text);
    }
}