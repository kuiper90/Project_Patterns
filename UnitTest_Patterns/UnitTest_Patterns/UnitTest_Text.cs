using System;
using Patterns;
using Xunit;

namespace Patterns
{
    public class UnitTest_Text
    {
        [Fact]
        public void TrueString_Should_Match_StringTrue()
        {
            Text trueText = new Text("true");
            Assert.True(trueText.Match("true").Success() == true);
            Assert.True(trueText.Match("true").RemainingText() == "");
        }

        [Fact]
        public void TrueString_Should_Match_StringTrueAndChar()
        {
            Text trueText = new Text("true");
            Assert.True(trueText.Match("trueX").Success() == true);
            Assert.True(trueText.Match("trueX").RemainingText() == "X");
        }

        [Fact]
        public void TrueString_ShouldNot_Match_StringFalse()
        {
            Text trueText = new Text("true");
            Assert.True(trueText.Match("false").Success() == false);
            Assert.True(trueText.Match("false").RemainingText() == "false");
        }

        [Fact]
        public void Empty_ShouldNot_Match_StringTrue()
        {
            Text trueText = new Text("true");
            Assert.True(trueText.Match("").Success() == false);
            Assert.True(trueText.Match("").RemainingText() == "");
        }

        [Fact]
        public void Null_ShouldNot_Match_StringTrue()
        {
            Text trueText = new Text("true");
            Assert.True(trueText.Match(null).Success() == false);
            Assert.True(trueText.Match(null).RemainingText() == null);
        }

        [Fact]
        public void FalseString_Should_Match_StringFalse()
        {
            Text falseText = new Text("false");
            Assert.True(falseText.Match("false").Success() == true);
            Assert.True(falseText.Match("false").RemainingText() == "");
        }

        [Fact]
        public void FalseString_Should_Match_StringFalseAndChars()
        {
            Text falseText = new Text("false");
            Assert.True(falseText.Match("falseX").Success() == true);
            Assert.True(falseText.Match("falseX").RemainingText() == "X");
        }

        [Fact]
        public void FalseString_ShouldNot_Match_StringTrue()
        {
            Text falseText = new Text("false");
            Assert.True(falseText.Match("true").Success() == false);
            Assert.True(falseText.Match("true").RemainingText() == "true");
        }

        [Fact]
        public void Empty_ShouldNot_Match_StringFalse()
        {
            Text falseText = new Text("false");
            Assert.True(falseText.Match("").Success() == false);
            Assert.True(falseText.Match("").RemainingText() == "");
        }

        [Fact]
        public void Null_ShouldNot_Match_StringFalse()
        {
            Text falseText = new Text("false");
            Assert.True(falseText.Match(null).Success() == false);
            Assert.True(falseText.Match(null).RemainingText() == null);
        }

        [Fact]
        public void Empty_Should_Match_Empty()
        {
            Text empty = new Text("");
            Assert.True(empty.Match("").Success() == true);
            Assert.True(empty.Match("").RemainingText() == "");
        }

        [Fact]
        public void TrueString_Should_Match_Empty()
        {
            Text empty = new Text("");
            Assert.True(empty.Match("true").Success() == true);
            Assert.True(empty.Match("true").RemainingText() == "true");
        }

        [Fact]
        public void Null_ShouldNot_Match_Empty()
        {
            Text empty = new Text("");
            Assert.True(empty.Match(null).Success() == false);
            Assert.True(empty.Match(null).RemainingText() == null);
        }
    }
}
