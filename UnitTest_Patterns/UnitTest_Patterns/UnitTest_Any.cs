using System;
using Patterns;
using Xunit;

namespace Patterns
{
    public class UnitTest_Any
    {
        [Fact]
        public void InputLowFirstChar_Should_Match_AnyIn_Pattern()
        {
            Any e = new Any("eE");
            Assert.True(e.Match("ea").Success() == true);
            Assert.True(e.Match("ea").RemainingText() == "a");
        }

        [Fact]
        public void InputUpFirstChar_Should_Match_AnyIn_Pattern()
        {
            Any e = new Any("eE");
            Assert.True(e.Match("Ea").Success() == true);
            Assert.True(e.Match("Ea").RemainingText() == "a");
        }

        [Fact]
        public void CharNotInPattern_ShouldNot_Match_AnyIn_Pattern()
        {
            Any e = new Any("eE");
            Assert.True(e.Match("a").Success() == false);
            Assert.True(e.Match("a").RemainingText() == "a");
        }

        [Fact]
        public void Empty_ShouldNot_Match_AnyIn_CharPattern()
        {
            Any e = new Any("eE");
            Assert.True(e.Match("").Success() == false);
            Assert.True(e.Match("").RemainingText() == "");
        }

        [Fact]
        public void Null_ShouldNot_Match_AnyIn_CharPattern()
        {
            Any e = new Any("eE");
            Assert.True(e.Match(null).Success() == false);
            Assert.True(e.Match(null).RemainingText() == null);
        }

        [Fact]
        public void Plus_Should_Match_AnyIn_Pattern()
        {
            Any sign = new Any("-+");
            Assert.True(sign.Match("+3").Success() == true);
            Assert.True(sign.Match("+3").RemainingText() == "3");
        }

        [Fact]
        public void Minus_Should_Match_AnyIn_Pattern()
        {
            Any sign = new Any("-+");
            Assert.True(sign.Match("-2").Success() == true);
            Assert.True(sign.Match("-2").RemainingText() == "2");
        }

        [Fact]
        public void Digit_ShouldNot_Match_AnyIn_Pattern()
        {
            Any sign = new Any("-+");
            Assert.True(sign.Match("2").Success() == false);
            Assert.True(sign.Match("2").RemainingText() == "2");
        }

        [Fact]
        public void Empty_ShouldNot_Match_AnyIn_Pattern()
        {
            Any sign = new Any("-+");
            Assert.True(sign.Match("").Success() == false);
            Assert.True(sign.Match("").RemainingText() == "");
        }

        [Fact]
        public void Null_ShouldNot_Match_AnyIn_Pattern()
        {
            Any sign = new Any("-+");
            Assert.True(sign.Match(null).Success() == false);
            Assert.True(sign.Match(null).RemainingText() == null);
        }
    }
}
