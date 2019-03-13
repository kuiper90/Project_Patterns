using System;

namespace Patterns
{
    public class Strings : IPattern
    {
        IPattern pattern;
        public Strings()
        {
            IPattern doubleQuotes = new Character('"');

            IPattern escapedDoubleQuotes = new Sequence(new Character('\\'), new Character('"'));

            IPattern solidus = new Sequence(new Character('\\'), new Choice(new Character('\\'), new Character('/')));
  
            IPattern controlCharacter = new Sequence(new Character('\\'), 
                                                     new Choice(new Character('b'),
                                                                new Character('f'),
                                                                new Character('n'),
                                                                new Character('r'),
                                                                new Character('t')));
            //IPattern controlCharacter = new Many(new Any("\b\f\n\r\t"));

            IPattern digit = new Range('0', '9');

            IPattern nonOffensiveUnicodeChar = new Choice(new Range((char)32, (char)33), 
                                                          new Range ((char)35, (char)91),
                                                          new Range((char)93, (char)255));

            IPattern hexaLetter = new Choice(new Range('a', 'f'), new Range('A', 'F'));

            IPattern hexaChar = new Choice(digit, hexaLetter);

            IPattern hexaNr = new Sequence(new Character('\\'), new Character('u'), hexaChar, hexaChar, hexaChar, hexaChar);

            IPattern item = new Choice(nonOffensiveUnicodeChar, controlCharacter, solidus, escapedDoubleQuotes, hexaNr);

            pattern = new Sequence(doubleQuotes, new Many(item), doubleQuotes);
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
