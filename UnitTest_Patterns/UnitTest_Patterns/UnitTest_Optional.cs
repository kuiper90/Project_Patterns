using Patterns;
using Xunit;

namespace UnitTest_Patterns
{
    public class UnitTest_Optional
    {
        [Fact]
        public void FirstCharacterMatchesCharacter()
        {
            Optional pattern = new Optional(new Character('a'));
            Assert.True(pattern.Match("abc").Success());
            Assert.True(pattern.Match("abc").RemainingText() == "bc");
        }

        [Fact]
        public void MultipleFirstCharactersMatchesCharacter()
        {
            Optional pattern = new Optional(new Character('a'));
            Assert.True(pattern.Match("aaabc").Success());
            Assert.True(pattern.Match("aaabc").RemainingText() == "aabc");
        }

        [Fact]
        public void NotInPatternFirstCharacterDoesNotMatchCharacter()
        {
            Optional pattern = new Optional(new Character('a'));
            Assert.True(pattern.Match("bc").Success());
            Assert.True(pattern.Match("bc").RemainingText() == "bc");
        }

        [Fact]
        public void EmptyStringDoesNotMatchCharacter()
        {
            Many pattern = new Many(new Character('a'));
            Assert.True(pattern.Match("").Success());
            Assert.True(pattern.Match("").RemainingText() == "");
        }

        [Fact]
        public void NullDoesNotMatchCharacter()
        {
            Optional pattern = new Optional(new Character('a'));
            Assert.True(pattern.Match(null).Success());
            Assert.True(pattern.Match(null).RemainingText() == null);
        }

        [Fact]
        public void FirstCharacterDigitDoesNotMatchMinus()
        {
            Optional pattern = new Optional(new Character('-'));
            Assert.True(pattern.Match("123").Success());
            Assert.True(pattern.Match("123").RemainingText() == "123");
        }

        [Fact]
        public void FirstCharacterMinusMatchesMinus()
        {
            Optional pattern = new Optional(new Character('-'));
            Assert.True(pattern.Match("-123").Success());
            Assert.True(pattern.Match("-123").RemainingText() == "123");
        }

        [Fact]
        public void NullDoesNotMatchRangeOfDigits()
        {
            Optional pattern = new Optional(new Range('0', '9'));
            Assert.True(pattern.Match(null).Success());
            Assert.True(pattern.Match(null).RemainingText() == null);
        }

        [Fact]
        public void FirstCharacterDigitMatchesRangeOfDigits()
        {
            Optional pattern = new Optional(new Range('0', '9'));
            Assert.True(pattern.Match("12345ab123").Success());
            Assert.True(pattern.Match("12345ab123").RemainingText() == "2345ab123");
        }

        [Fact]
        public void FirstCharacterDoesNotMatchRangeOfDigits()
        {
            Optional pattern = new Optional(new Range('0', '9'));
            Assert.True(pattern.Match("ab").Success());
            Assert.True(pattern.Match("ab").RemainingText() == "ab");
        }
    }
}
