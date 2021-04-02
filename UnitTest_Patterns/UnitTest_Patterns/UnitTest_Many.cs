using Patterns;
using Xunit;

namespace UnitTest_Patterns
{
    public class UnitTest_Many
    {
        [Fact]
        public void FirstCharacterMatchesManyCharPattern()
        {
            Many pattern = new Many(new Character('a'));
            Assert.True(pattern.Match("abc").Success());
            Assert.True(pattern.Match("abc").RemainingText() == "bc");
        }

        [Fact]
        public void MultipleFirstCharacterMatchesManyCharPattern()
        {
            Many pattern = new Many(new Character('a'));
            Assert.True(pattern.Match("aaaabc").Success());
            Assert.True(pattern.Match("aaaabc").RemainingText() == "bc");
        }

        [Fact]
        public void DiferentFirstCharacterMatchesCharPattern()
        {
            Many pattern = new Many(new Character('a'));
            Assert.True(pattern.Match("bc").Success());
            Assert.True(pattern.Match("bc").RemainingText() == "bc");
        }

        [Fact]
        public void EmptyMatchesManyCharacterPattern()
        {
            Many pattern = new Many(new Character('a'));
            Assert.True(pattern.Match("").Success());
            Assert.True(pattern.Match("").RemainingText()?.Length == 0);
        }

        [Fact]
        public void NullMatchesManyCharPattern()
        {
            Many pattern = new Many(new Character('a'));
            Assert.True(pattern.Match(null).Success());
            Assert.True(pattern.Match(null).RemainingText() == null);
        }

        [Fact]
        public void FirstNumberMatchManyDigitsPattern()
        {
            Many pattern = new Many(new Range('0', '9'));
            Assert.True(pattern.Match("12345ab123").Success());
            Assert.True(pattern.Match("12345ab123").RemainingText() == "ab123");
        }

        [Fact]
        public void FirstCharMatchesManyDigitsPattern()
        {
            Many pattern = new Many(new Range('0', '9'));
            Assert.True(pattern.Match("ab").Success());
            Assert.True(pattern.Match("ab").RemainingText() == "ab");
        }

        [Fact]
        public void NullMatchesManyDigitRange()
        {
            Many pattern = new Many(new Range('0', '9'));
            Assert.True(pattern.Match(null).Success());
            Assert.True(pattern.Match(null).RemainingText() == null);
        }

        [Fact]
        public void TextMatchesManyTextPattern()
        {
            Many pattern = new Many(new Text("abc"));
            Assert.True(pattern.Match("abcabcd").Success());
            Assert.True(pattern.Match("abcabcd").RemainingText() == "d");
        }
    }
}
