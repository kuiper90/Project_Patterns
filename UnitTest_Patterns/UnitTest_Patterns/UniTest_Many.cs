using System;
using Patterns;
using Xunit;

namespace Patterns
{
    public class UniTest_Many
    {
        [Fact]
        public void FirstChar_Should_Match_Many_CharPattern()
        {
            Many a = new Many(new Character('a'));
            Assert.True(a.Match("abc").Success() == true);
            Assert.True(a.Match("abc").RemainingText() == "bc");
        }

        [Fact]
        public void MultipleFirstChar_Should_Match_Many_CharPattern()
        {
            Many a = new Many(new Character('a'));
            Assert.True(a.Match("aaaabc").Success() == true);
            Assert.True(a.Match("aaaabc").RemainingText() == "bc");
        }

        [Fact]
        public void DiferentFirstChar_Should_Match_Many_CharPattern()
        {
            Many a = new Many(new Character('a'));
            Assert.True(a.Match("bc").Success() == true);
            Assert.True(a.Match("bc").RemainingText() == "bc");
        }

        [Fact]
        public void Empty_Should_Match_Many_CharPattern()
        {
            Many a = new Many(new Character('a'));
            Assert.True(a.Match("").Success() == true);
            Assert.True(a.Match("").RemainingText() == "");
        }

        [Fact]
        public void Null_Should_Match_Many_CharPattern()
        {
            Many a = new Many(new Character('a'));
            Assert.True(a.Match(null).Success() == true);
            Assert.True(a.Match(null).RemainingText() == null);
        }

        [Fact]
        public void FirstNumber_Should_Match_Many_DigitsPattern()
        {
            Many digits = new Many(new Range('0', '9'));
            Assert.True(digits.Match("12345ab123").Success() == true);
            Assert.True(digits.Match("12345ab123").RemainingText() == "ab123");
        }

        [Fact]
        public void FirstChar_Should_Match_Many_DigitsPattern()
        {
            Many digits = new Many(new Range('0', '9'));
            Assert.True(digits.Match("ab").Success() == true);
            Assert.True(digits.Match("ab").RemainingText() == "ab");
        }

        [Fact]
        public void Null_Should_Match_Many_DigitRange()
        {
            Many digits = new Many(new Range('0', '9'));
            Assert.True(digits.Match(null).Success() == true);
            Assert.True(digits.Match(null).RemainingText() == null);
        }

        [Fact]
        public void Text_Should_Match_Many_TextPattern()
        {
            Many a = new Many(new Text("abc"));
            Assert.True(a.Match("abcabcd").Success() == true);
            Assert.True(a.Match("abcabcd").RemainingText() == "d");
        }
    }
}
