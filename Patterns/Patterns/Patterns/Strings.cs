namespace Patterns
{
    public class String : IPattern
    {
        private readonly IPattern pattern;

        public String()
        {
            IPattern doubleQuotes = new Character('"');
            IPattern digit = new Range('0', '9');
            IPattern hexaCharacter = new Choice(
                new Range('a', 'f'),
                new Range('A', 'F'));
            IPattern hexaDigit = new Choice(
                digit,
                hexaCharacter);
            IPattern hexaNumber = new Sequence(
                new Character('u'),
                hexaDigit,
                hexaDigit,
                hexaDigit,
                hexaDigit);
            IPattern escapeCharacter = new Sequence(
                new Character('\\'),
                new Choice(
                    hexaNumber,
                    new Any("/\\bfnrt\"")));
            IPattern character = new Choice(
                new Range((char)32, (char)33),
                new Range((char)35, (char)91),
                new Range((char)93, char.MaxValue),
                escapeCharacter,
                hexaNumber);

            this.pattern = new Sequence(
                doubleQuotes,
                new Many(character),
                doubleQuotes);
        }

        public IMatch Match(string text)
            => this.pattern.Match(text);
    }
}