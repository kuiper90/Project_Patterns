using Patterns;
using Xunit;

namespace UnitTest_Patterns
{
    public class UnitTest_Range
    {
        [Fact]
        public void MatchesFirstDigitWithStartOfRange()
        {
            Range pattern = new Range('0', '1');
            Assert.True(pattern.Match("0").Success());
            Assert.True(pattern.Match("0").RemainingText()?.Length == 0);
        }

        [Fact]
        public void MatchesFirstDigitWithDigitInRange()
        {
            Range pattern = new Range('0', '9');
            Assert.True(pattern.Match("765465").Success());
            Assert.True(pattern.Match("765465").RemainingText() == "65465");
        }

        [Fact]
        public void MatchesFirstDigitWithEndOfRange()
        {
            Range pattern = new Range('7', '8');
            Assert.True(pattern.Match("8").Success());
            Assert.True(pattern.Match("8").RemainingText()?.Length == 0);
        }

        [Fact]
        public void MatchesFirstCharacterWithStartOfRange()
        {
            Range pattern = new Range('m', 'o');
            Assert.True(pattern.Match("mno").Success());
            Assert.True(pattern.Match("mno").RemainingText() == "no");
        }

        [Fact]
        public void MatchesFirstCharacterWithCharacterInRange()
        {
            Range pattern = new Range('a', 'z');
            Assert.True(pattern.Match("x").Success());
            Assert.True(pattern.Match("x").RemainingText()?.Length == 0);
        }

        [Fact]
        public void MatchesFirstCharacterWithEndOfRange()
        {
            Range pattern = new Range('a', 'f');
            Assert.True(pattern.Match("ffab").Success());
            Assert.True(pattern.Match("ffab").RemainingText() == "fab");
        }

        [Fact]
        public void DoesNotMatchDigitOnFirstPositionIfNotInRange()
        {
            Range pattern = new Range('a', 'f');
            Assert.False(pattern.Match("1abc").Success());
            Assert.False(pattern.Match("1abc").RemainingText() == "1");
        }

        [Fact]
        public void MatchesFirstCharacterInAnyGivenRange()
        {
            Range pattern = new Range((char)0, (char)127);
            Assert.True(pattern.Match("*+-,whoksj.@#$!%\\^%&CTBVXkN").Success());
            Assert.True(pattern.Match("*+-,whoksj.@#$!%\\^%&CTBVXkN").RemainingText() == "+-,whoksj.@#$!%\\^%&CTBVXkN");
        }
    }
}
