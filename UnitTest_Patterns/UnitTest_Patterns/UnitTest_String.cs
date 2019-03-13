using System;
using Patterns;
using Xunit;

namespace UnitTest_Patterns
{
    public class UnitTest_String
    {
        [Fact]
        public void ShouldBe_False_UnicodeNumberAndNewline()
        {
            IPattern str = new Strings();
            Assert.False(str.Match("\"Test\\u0097\nAnother line\"").Success());
            Assert.True(str.Match("\"Test\\u0097\nAnother line\"").RemainingText() == "\"Test\\u0097\nAnother line\"");
        }

        [Fact]
        public void ShouldBe_True_UnicodeNumberAndEscapedNewline()
        {
            IPattern str = new Strings();
            Assert.True(str.Match("\"Test\\u0097\\nAnother line\"").Success());
            Assert.True(str.Match("\"Test\\u0097\\nAnother line\"").RemainingText() == "");
        }

        [Fact]
        public void ShouldBe_True_StartAndEndDoubleQuotes()
        {
            IPattern str = new Strings();
            Assert.True(str.Match("\"abc\"").Success());
            Assert.True(str.Match("\"abc\"").RemainingText() == "");
        }

        [Fact]
        public void ShouldBe_False_EndExtraEscapedDoubleQuotes()
        {
            IPattern str = new Strings();
            Assert.True(str.Match("\"abc\"\"").Success());
            Assert.True(str.Match("\"abc\"\"").RemainingText() == "\"");
        }

        [Fact]
        public void ShouldBe_False_MidEscapedDoubleQuotes()
        {
            IPattern str = new Strings();
            Assert.True(str.Match("\"ab\"c\"").Success());
            Assert.True(str.Match("\"ab\"c\"").RemainingText() == "c\"");
        }

        [Fact]
        public void ShouldBe_False_UnicodeNumberOneHex()
        {
            IPattern str = new Strings();
            Assert.False(str.Match("\"ab12\\uc\"").Success());
            Assert.True(str.Match("\"ab12\\uc\"").RemainingText() == "\"ab12\\uc\"");
        }

        [Fact]
        public void ShouldBe_False_StartNoDoubleQuotes()
        {
            IPattern str = new Strings();
            Assert.False(str.Match("Test\"").Success());
            Assert.True(str.Match("Test\"").RemainingText() == "Test\"");
        }

        [Fact]
        public void ShouldBe_False_EndNoDoubleQuotes()
        {
            IPattern str = new Strings();
            Assert.False(str.Match("\"Test").Success());
            Assert.True(str.Match("\"Test").RemainingText() == "\"Test");
        }

        [Fact]
        public void ShouldBe_False_StartEscapedReverseSolidus()
        {
            IPattern str = new Strings();
            Assert.False(str.Match("\"\\Test\"").Success());
            Assert.True(str.Match("\"\\Test\"").RemainingText() == "\"\\Test\"");
        }

        [Fact]
        public void ShouldBe_True_EscapedCarriageReturn()
        {
            IPattern str = new Strings();
            Assert.True(str.Match("\"ab12\\rc\"").Success());
            Assert.True(str.Match("\"ab12\\rc\"").RemainingText() == "");
        }

        [Fact]
        public void ShouldBe_False_InternEscapedDoubleQuotes()
        {
            IPattern str = new Strings();
            Assert.True(str.Match("\"Te\"st\"").Success());
            Assert.True(str.Match("\"Te\"st\"").RemainingText() == "st\"");
        }

        [Fact]
        public void ShouldBe_False_InternDoubleReverseSolidus()
        {
            IPattern str = new Strings();
            Assert.True(str.Match("\"Te\\\\st\"").Success());
            Assert.True(str.Match("\"Te\\\\st\"").RemainingText() == "");
        }

        [Fact]
        public void ShouldBe_True_DoubleQuotes()
        {
            IPattern str = new Strings();
            Assert.True(str.Match("\"\"").Success());
            Assert.True(str.Match("\"\"").RemainingText() == "");
        }

        [Fact]
        public void ShouldBe_False_EmtpyString()
        {
            IPattern str = new Strings();
            Assert.False(str.Match("").Success());
            Assert.True(str.Match("").RemainingText() == "");
        }
    }
}
