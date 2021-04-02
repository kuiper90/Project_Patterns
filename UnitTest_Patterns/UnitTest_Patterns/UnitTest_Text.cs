using Patterns;
using Xunit;

namespace UnitTest_Patterns
{
    public class UnitTest_Text
    {
        [Fact]
        public void LowerCaseStringMatchesLowerCaseText()
        {
            Text text = new Text("true");
            Assert.True(text.Match("true").Success());
            Assert.True(text.Match("true").RemainingText()?.Length == 0);
        }

        [Fact]
        public void LowerCaseStringMatchesStringWithLowerCapsAndUpperCase()
        {
            Text text = new Text("true");
            Assert.True(text.Match("trueX").Success());
            Assert.True(text.Match("trueX").RemainingText() == "X");
        }

        [Fact]
        public void LowerCaseStringDoesNotMatchLowerCaseText()
        {
            Text text = new Text("true");
            Assert.False(text.Match("false").Success());
            Assert.True(text.Match("false").RemainingText() == "false");
        }

        [Fact]
        public void EmptyStringDoesNotMatchText()
        {
            Text text = new Text("true");
            Assert.False(text.Match("").Success());
            Assert.True(text.Match("").RemainingText()?.Length == 0);
        }

        [Fact]
        public void NullDoesNotMatchLowerCaseText()
        {
            Text text = new Text("true");
            Assert.False(text.Match(null).Success());
            Assert.True(text.Match(null).RemainingText() == null);
        }

        [Fact]
        public void LowerAndUpperCaseStringMatchesLowerCaseText()
        {
            Text text = new Text("false");
            Assert.True(text.Match("falseX").Success());
            Assert.True(text.Match("falseX").RemainingText() == "X");
        }

        [Fact]
        public void StringDoesNotMatchText()
        {
            Text text = new Text("false");
            Assert.False(text.Match("true").Success());
            Assert.True(text.Match("true").RemainingText() == "true");
        }

        [Fact]
        public void NullDoesNotMatchText()
        {
            Text text = new Text("false");
            Assert.False(text.Match(null).Success());
            Assert.True(text.Match(null).RemainingText() == null);
        }

        [Fact]
        public void EmptyStringMatchesEmptyText()
        {
            Text text = new Text("");
            Assert.True(text.Match("").Success());
            Assert.True(text.Match("").RemainingText()?.Length == 0);
        }

        [Fact]
        public void LowerCaseStringMatchesEmptyText()
        {
            Text text = new Text("");
            Assert.True(text.Match("true").Success());
            Assert.True(text.Match("true").RemainingText() == "true");
        }

        [Fact]
        public void NullDoesNotMatchEmptyText()
        {
            Text text = new Text("");
            Assert.False(text.Match(null).Success());
            Assert.True(text.Match(null).RemainingText() == null);
        }
    }
}
