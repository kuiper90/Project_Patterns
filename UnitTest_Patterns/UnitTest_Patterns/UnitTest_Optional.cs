using System;
using Patterns;
using Xunit;

namespace Patterns
{
    public class UnitTest_Optional
    {
        [Fact]
        public void InputFirstChar_Should_Match_Char()
        {
            Optional a = new Optional(new Character('a'));
            Assert.True(a.Match("abc").Success() == true);
            Assert.True(a.Match("abc").RemainingText() == "bc");
        }

        [Fact]
        public void Only_InputFirstChar_Should_Match_Char()
        {
            Optional a = new Optional(new Character('a'));
            Assert.True(a.Match("aaaabc").Success() == true);
            Assert.True(a.Match("aaaabc").RemainingText() == "aaabc");
        }

        [Fact]
        public void NotInPattern_InputFirstChar_Should_Match_Char()
        {
            Optional a = new Optional(new Character('a'));
            Assert.True(a.Match("bc").Success() == true);
            Assert.True(a.Match("bc").RemainingText() == "bc");
        }

        [Fact]
        public void EmptyInput_Should_Match_Char()
        {
            Many a = new Many(new Character('a'));
            Assert.True(a.Match("").Success() == true);
            Assert.True(a.Match("").RemainingText() == "");
        }

        [Fact]
        public void Null_Should_Match_Char()
        {
            Optional a = new Optional(new Character('a'));
            Assert.True(a.Match(null).Success() == true);
            Assert.True(a.Match(null).RemainingText() == null);
        }

        [Fact]
        public void InputFirstChar_Digit_Should_Match_Minus()
        {
            Optional digits = new Optional(new Character('-'));
            Assert.True(digits.Match("123").Success() == true);
            Assert.True(digits.Match("123").RemainingText() == "123");
        }

        [Fact]
        public void InputFirstChar_Minus_Should_Match_Minus()
        {
            Optional digits = new Optional(new Character('-'));
            Assert.True(digits.Match("-123").Success() == true);
            Assert.True(digits.Match("-123").RemainingText() == "123");
        }

        [Fact]
        public void Null_Should_Match_RangeOfDigits()
        {
            Optional digits = new Optional(new Range('0', '9'));
            Assert.True(digits.Match(null).Success() == true);
            Assert.True(digits.Match(null).RemainingText() == null);
        }

        [Fact]
        public void InputFirstChar_Digit_Should_Match_RangeOfDigits()
        {
            Optional digits = new Optional(new Range('0', '9'));
            Assert.True(digits.Match("12345ab123").Success() == true);
            Assert.True(digits.Match("12345ab123").RemainingText() == "2345ab123");
        }

        [Fact]
        public void InputFirstChar_Should_Match_RangeOfDigits()
        {
            Optional digits = new Optional(new Range('0', '9'));
            Assert.True(digits.Match("ab").Success() == true);
            Assert.True(digits.Match("ab").RemainingText() == "ab");
        }
    }
}
