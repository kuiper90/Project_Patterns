using Patterns;

namespace Patterns
{
    interface IPattern
    {
        bool Match(string text);
    }

    class Choice : IPattern
    {
        IPattern[] patterns;

        public Choice(params IPattern[] patterns)
        {
            this.patterns = patterns;
        }

        public bool Match(string text)
        {
            foreach (var pattern in this.patterns)
            {
                if (pattern.Match(text))
                    return (true);
            }
            return (false);
        }

        public void Main()
        {
            var chr = new Range('a', 'f');
            var digit = new Choice(new Character('0'), new Range('1', '9'));
            var hex = new Choice(digit, new Choice(new Range('a', 'f'), new Range('A', 'F')));

            chr.Match("abc"); // true
            chr.Match("fab"); // true
            chr.Match("ffg"); // true
            chr.Match("bcd"); // true
            chr.Match("1ab"); // false
            chr.Match(null); // false
            chr.Match(""); // false

            digit.Match("012"); // true
            digit.Match("12"); // true
            digit.Match("92"); // true
            digit.Match("a9"); // false
            digit.Match(""); // false
            digit.Match(null); // false

            hex.Match("012"); // true
            hex.Match("12"); // true
            hex.Match("92"); // true
            hex.Match("a9"); // true
            hex.Match("f8"); // true
            hex.Match("A9"); // true
            hex.Match("F8"); // true
            hex.Match("g8"); // false
            hex.Match("G8"); // false
            hex.Match(""); // false
            hex.Match(null); // false
        }

    }
}

