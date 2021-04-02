using Patterns;
using Xunit;

namespace UnitTest_Patterns
{
    public class UnitTest_Character
    {
        [Fact]
        public void MatchesSpaceCharacter()
        {
            Character pattern = new Character(' ');
            Assert.True(pattern.Match(" ").Success());
            Assert.True(pattern.Match(" ").RemainingText()?.Length == 0);
        }

        [Fact]
        public void MatchesStartOfString()
        {
            Character pattern = new Character('a');
            Assert.True(pattern.Match("a").Success());
            Assert.True(pattern.Match("a").RemainingText()?.Length == 0);
        }

        [Fact]
        public void IsNotNull()
        {
            Character pattern = new Character('\0');
            Assert.True(pattern.Match("\0").Success());
            Assert.True(pattern.Match("\0").RemainingText()?.Length == 0);
        }

        [Fact]
        public void MatchesQuotes()
        {
            Character pattern = new Character('\"');
            Assert.True(pattern.Match("\"").Success());
            Assert.True(pattern.Match("\"").RemainingText()?.Length == 0);
        }

        [Fact]
        public void MatchesEscapedLineFeed()
        {
            Character pattern = new Character('\n');
            Assert.True(pattern.Match("\n").Success());
            Assert.True(pattern.Match("\n").RemainingText()?.Length == 0);
        }

        [Fact]
        public void MatchesEscapedCarriageReturn()
        {
            Character pattern = new Character('\r');
            Assert.True(pattern.Match("\r").Success());
            Assert.True(pattern.Match("\r").RemainingText()?.Length == 0);
        }

        [Fact]
        public void MatchesEscapedHorizontalTab()
        {
            Character pattern = new Character('\t');
            Assert.True(pattern.Match("\t").Success());
            Assert.True(pattern.Match("\t").RemainingText()?.Length == 0);
        }

        [Fact]
        public void MatchesEscapedBackspace()
        {
            Character pattern = new Character('\b');
            Assert.True(pattern.Match("\b").Success());
            Assert.True(pattern.Match("\b").RemainingText()?.Length == 0);
        }

        [Fact]
        public void MatchesEscapedReverseSolidus()
        {
            Character pattern = new Character('\\');
            Assert.True(pattern.Match("\\").Success());
            Assert.True(pattern.Match("\\").RemainingText()?.Length == 0);
        }

        [Fact]
        public void MatchesEscapedFormFeed()
        {
            Character pattern = new Character('\f');
            Assert.True(pattern.Match("\f").Success());
            Assert.True(pattern.Match("\f").RemainingText()?.Length == 0);
        }

        [Fact]
        public void MatchesGivenCharacter()
        {
            Character pattern = new Character('j');
            Assert.True(pattern.Match("json").Success());
            Assert.True(pattern.Match("json").RemainingText() == "son");
        }

        [Fact]
        public void MatchesGivenDigit()
        {
            Character pattern = new Character('5');
            Assert.True(pattern.Match("5820").Success());
            Assert.True(pattern.Match("5820").RemainingText() == "820");
        }
    }
}
