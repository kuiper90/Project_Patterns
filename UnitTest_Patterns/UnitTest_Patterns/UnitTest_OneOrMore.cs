using Patterns;
using Xunit;

namespace UnitTest_Patterns
{
    public class UnitTest_OneOrMore
    {
        [Fact]
        public void FirstCharacterMatchesCharacter()
        {
            OneOrMore pattern = new OneOrMore(new Character('a'));
            Assert.True(pattern.Match("abc").Success());
            Assert.True(pattern.Match("abc").RemainingText() == "bc");
        }

        [Fact]
        public void MultipleFirstCharacterMatchesCharacter()
        {
            OneOrMore pattern = new OneOrMore(new Character('a'));
            Assert.True(pattern.Match("aaaabc").Success());
            Assert.True(pattern.Match("aaaabc").RemainingText() == "bc");
        }

        [Fact]
        public void FirstCharacterDoesNotMatchCharacter()
        {
            OneOrMore pattern = new OneOrMore(new Character('a'));
            Assert.False(pattern.Match("bc").Success());
            Assert.True(pattern.Match("bc").RemainingText() == "bc");
        }

        [Fact]
        public void EmptyStringMatchesCharacter()
        {
            OneOrMore pattern = new OneOrMore(new Character('a'));
            Assert.False(pattern.Match("").Success());
            Assert.True(pattern.Match("").RemainingText() == "");
        }

        [Fact]
        public void FirstCharPlusMatchesCharacter()
        {
            OneOrMore pattern = new OneOrMore(new Character('a'));
            Assert.False(pattern.Match("+1 a").Success());
            Assert.True(pattern.Match("+1 a").RemainingText() == "+1 a");
        }

        [Fact]
        public void FirstCharacterDigitMatchesCharacter()
        {
            OneOrMore pattern = new OneOrMore(new Character('a'));
            Assert.False(pattern.Match("1a").Success());
            Assert.True(pattern.Match("1a").RemainingText() == "1a");
        }

        [Fact]
        public void SpaceAndFirstCharacterMatchCharacter()
        {
            OneOrMore pattern = new OneOrMore(new Character('a'));
            Assert.False(pattern.Match(" a").Success());
            Assert.True(pattern.Match(" a").RemainingText() == " a");
        }

        [Fact]
        public void FirstCharacterAndSpaceMatchCharacter()
        {
            OneOrMore pattern = new OneOrMore(new Character('a'));
            Assert.True(pattern.Match("a ").Success());
            Assert.True(pattern.Match("a ").RemainingText() == " ");
        }

        [Fact]
        public void FirstNumberMatchesRangeOfDigits()
        {
            OneOrMore pattern = new OneOrMore(new Range('0', '9'));
            Assert.True(pattern.Match("12345ab123").Success());
            Assert.True(pattern.Match("12345ab123").RemainingText() == "ab123");
        }

        [Fact]
        public void LettersMatchRangeOfDigits()
        {
            OneOrMore pattern = new OneOrMore(new Range('0', '9'));
            Assert.False(pattern.Match("bc").Success());
            Assert.True(pattern.Match("bc").RemainingText() == "bc");
        }

        [Fact]
        public void NullDoesNotMatchRangeOfDigits()
        {
            OneOrMore pattern = new OneOrMore(new Range('0', '9'));
            Assert.False(pattern.Match(null).Success());
            Assert.True(pattern.Match(null).RemainingText() == null);
        }

        [Fact]
        public void NumberAndCharacterMatchesRangeOfDigits()
        {
            OneOrMore pattern = new OneOrMore(new Range('0', '9'));
            Assert.True(pattern.Match("123ab").Success());
            Assert.True(pattern.Match("123ab").RemainingText() == "ab");
        }

        [Fact]
        public void NumberMatchesRangeOfDigits()
        {
            OneOrMore pattern = new OneOrMore(new Range('0', '9'));
            Assert.True(pattern.Match("123").Success());
            Assert.True(pattern.Match("123").RemainingText() == "");
        }

        [Fact]
        public void MultipleFirstCharacterMatchManyTextPattern()
        {
            OneOrMore pattern = new OneOrMore(new Text("abc"));
            Assert.True(pattern.Match("abcabcd").Success());
            Assert.True(pattern.Match("abcabcd").RemainingText() == "d");
        }
    }
}
