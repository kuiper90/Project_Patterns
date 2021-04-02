using Patterns;
using Xunit;

namespace UnitTest_Patterns
{
    public class UnitTest_List
    {
        [Fact]
        public void CharactersStringMatchesList()
        {
            var pattern = new List(new Range('0', '9'), new Character(','));
            Assert.True(pattern.Match("1,2,3").Success());
            Assert.True(pattern.Match("1,2,3").RemainingText() == "");
        }

        [Fact]
        public void StringEndingInCommaMatchesList()
        {
            var pattern = new List(new Range('0', '9'), new Character(','));
            Assert.True(pattern.Match("1,2,3,").Success());
            Assert.True(pattern.Match("1,2,3,").RemainingText() == ",");
        }

        [Fact]
        public void DigitLetterMatchesList()
        {
            var pattern = new List(new Range('0', '9'), new Character(','));
            Assert.True(pattern.Match("1a").Success());
            Assert.True(pattern.Match("1a").RemainingText() == "a");
        }

        [Fact]
        public void LettersMatchList()
        {
            var pattern = new List(new Range('0', '9'), new Character(','));
            Assert.True(pattern.Match("abc").Success());
            Assert.True(pattern.Match("abc").RemainingText() == "abc");
        }

        [Fact]
        public void EmptyMatchesListPattern()
        {
            var pattern = new List(new Range('0', '9'), new Character(','));
            Assert.True(pattern.Match("").Success());
            Assert.True(pattern.Match("").RemainingText() == "");
        }

        [Fact]
        public void NullMatchesList()
        {
            var pattern = new List(new Range('0', '9'), new Character(','));
            Assert.True(pattern.Match(null).Success());
            Assert.True(pattern.Match(null).RemainingText() == null);
        }

        [Fact]
        public void NullMatchesListComplexList()
        {
            var digits = new OneOrMore(new Range('0', '9'));
            var whitespace = new Many(new Any(" \r\n\t"));
            var separator = new Sequence(whitespace, new Character(';'), whitespace);
            var list = new List(digits, separator);
            Assert.True(list.Match(null).Success());
            Assert.True(list.Match(null).RemainingText() == null);
        }

        [Fact]
        public void DigitsAndSeparatorsStringMatchesComplexList()
        {
            var digits = new OneOrMore(new Range('0', '9'));
            var whitespace = new Many(new Any(" \r\n\t"));
            var separator = new Sequence(whitespace, new Character(';'), whitespace);
            var list = new List(digits, separator);
            Assert.True(list.Match("1; 22  ;\n 333 \t; 22").Success());
            Assert.True(list.Match("1; 22  ;\n 333 \t; 22").RemainingText()?.Length == 0);
        }

        [Fact]
        public void DigitsSeparatorsMatchComplexList()
        {
            var digits = new OneOrMore(new Range('0', '9'));
            var whitespace = new Many(new Any(" \r\n\t"));
            var separator = new Sequence(whitespace, new Character(';'), whitespace);
            var list = new List(digits, separator);
            Assert.True(list.Match("1 \n;").Success());
            Assert.True(list.Match("1 \n;").RemainingText() == " \n;");
        }

        [Fact]
        public void CharactersMatchComplexList()
        {
            var digits = new OneOrMore(new Range('0', '9'));
            var whitespace = new OneOrMore(new Any(" \r\n\t"));
            var separator = new Sequence(whitespace, new Character(';'), whitespace);
            var list = new List(digits, separator);
            Assert.True(list.Match("abc").Success());
            Assert.True(list.Match("abc").RemainingText() == "abc");
        }

        [Fact]
        public void EmptyStringMatchesList()
        {
            IPattern digits = new OneOrMore(new Range('0', '9'));
            IPattern whitespace = new Many(new Any(" \r\n\t"));
            IPattern separator = new Sequence(whitespace, new Character(';'), whitespace);
            List list = new List(digits, separator);
            Assert.True(list.Match("").Success());
            Assert.True(list.Match("").RemainingText()?.Length == 0);
        }
    }
}
