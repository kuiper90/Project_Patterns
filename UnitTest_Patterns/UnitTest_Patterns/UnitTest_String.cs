using Patterns;
using Xunit;

namespace UnitTest_Patterns
{
    public class UnitTest_String
    {
        [Fact]
        public void CharactersUnicodeNumberNewlineCharactersSequenceDoesNotMatchString()
        {
            IPattern pattern = new String();
            Assert.False(pattern.Match("\"Test\\u0097\nAnother line\"").Success());
            Assert.True(pattern.Match("\"Test\\u0097\nAnother line\"").RemainingText() == "\"Test\\u0097\nAnother line\"");
        }

        [Fact]
        public void CharactersUnicodeNumberEscapedNewlineCharactersSequenceDoesNotMatchString()
        {
            IPattern pattern = new String();
            Assert.True(pattern.Match("\"Test\\u0097\\nAnother line\"").Success());
            Assert.True(pattern.Match("\"Test\\u0097\\nAnother line\"").RemainingText()?.Length == 0);
        }

        [Fact]
        public void CharactersEscapedDoubleQuotesSequenceMatchesString()
        {
            IPattern pattern = new String();
            Assert.True(pattern.Match("\"abc\"").Success());
            Assert.True(pattern.Match("\"abc\"").RemainingText()?.Length == 0);
        }

        [Fact]
        public void EscapedQuotesCharactersAndDoubleEscapedQuotesSequenceMatchesString()
        {
            IPattern pattern = new String();
            Assert.True(pattern.Match("\"abc\"\"").Success());
            Assert.True(pattern.Match("\"abc\"\"").RemainingText() == "\"");
        }

        [Fact]
        public void CharactersEscapedDoubleQuotesCharactersSequenceMatchesString()
        {
            IPattern pattern = new String();
            Assert.True(pattern.Match("\"ab\"c\"").Success());
            Assert.True(pattern.Match("\"ab\"c\"").RemainingText() == "c\"");
        }

        [Fact]
        public void CharactersUnicodeNumberOneHexSequenceMatchesString()
        {
            IPattern pattern = new String();
            Assert.False(pattern.Match("\"ab12\\uc\"").Success());
            Assert.True(pattern.Match("\"ab12\\uc\"").RemainingText() == "\"ab12\\uc\"");
        }

        [Fact]
        public void CharactersDoubleQuotesSequenceDoesNotMatchString()
        {
            IPattern pattern = new String();
            Assert.False(pattern.Match("Test\"").Success());
            Assert.True(pattern.Match("Test\"").RemainingText() == "Test\"");
        }

        [Fact]
        public void DoubleQuotesCharactersSequenceDoesNotMatchString()
        {
            IPattern pattern = new String();
            Assert.False(pattern.Match("\"Test").Success());
            Assert.True(pattern.Match("\"Test").RemainingText() == "\"Test");
        }

        [Fact]
        public void EscapedReverseSolidusCharactersQuotedSequenceDoesNotMatchString()
        {
            IPattern pattern = new String();
            Assert.False(pattern.Match("\"\\Test\"").Success());
            Assert.True(pattern.Match("\"\\Test\"").RemainingText() == "\"\\Test\"");
        }

        [Fact]
        public void CharactersEscapedCarriageReturnCharactersQuotedSequenceMatchesString()
        {
            IPattern pattern = new String();
            Assert.True(pattern.Match("\"ab12\\rc\"").Success());
            Assert.True(pattern.Match("\"ab12\\rc\"").RemainingText()?.Length == 0);
        }

        [Fact]
        public void CharactersEscapedDoubleQuotesCharactersMatchesString()
        {
            IPattern pattern = new String();
            Assert.True(pattern.Match("\"Te\"st\"").Success());
            Assert.True(pattern.Match("\"Te\"st\"").RemainingText() == "st\"");
        }

        [Fact]
        public void CharactersDoubleReverseSolidusCharactersSequenceMatchesString()
        {
            IPattern pattern = new String();
            Assert.True(pattern.Match("\"Te\\\\st\"").Success());
            Assert.True(pattern.Match("\"Te\\\\st\"").RemainingText()?.Length == 0);
        }

        [Fact]
        public void DoubleQuotesSequenceMatchesString()
        {
            IPattern pattern = new String();
            Assert.True(pattern.Match("\"\"").Success());
            Assert.True(pattern.Match("\"\"").RemainingText()?.Length == 0);
        }

        [Fact]
        public void EmptyDoesNotMatchString()
        {
            IPattern pattern = new String();
            Assert.False(pattern.Match("").Success());
            Assert.True(pattern.Match("").RemainingText()?.Length == 0);
        }
    }
}
