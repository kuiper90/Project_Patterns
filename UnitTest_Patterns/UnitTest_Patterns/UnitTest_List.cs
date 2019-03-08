using System;
using Patterns;
using Xunit;

namespace Patterns
{
    public class UnitTest_List
    {
        [Fact]
        public void InputPattern_DigitCommaDigit_Should_Match_DigitComma()
        {
            List a = new List(new Range('0', '9'), new Character(','));
            Assert.True(a.Match("1,2,3").Success() == true);
            Assert.True(a.Match("1,2,3").RemainingText() == "");
        }

        [Fact]
        public void InputPattern_DigitComma_Should_Match_DigitComma()
        {
            List a = new List(new Range('0', '9'), new Character(','));
            Assert.True(a.Match("1,2,3,").Success() == true);
            Assert.True(a.Match("1,2,3,").RemainingText() == ",");
        }

        [Fact]
        public void DigitLetter_Should_Match_DigitComma()
        {
            List a = new List(new Range('0', '9'), new Character(','));
            Assert.True(a.Match("1a").Success() == true);
            Assert.True(a.Match("1a").RemainingText() == "a");
        }

        [Fact]
        public void Chars_Should_Match_DigitComma()
        {
            List a = new List(new Range('0', '9'), new Character(','));
            Assert.True(a.Match("abc").Success() == true);
            Assert.True(a.Match("abc").RemainingText() == "abc");
        }

        [Fact]
        public void Empty_Should_Match_DigitComma()
        {
            List a = new List(new Range('0', '9'), new Character(','));
            Assert.True(a.Match("").Success() == true);
            Assert.True(a.Match("").RemainingText() == "");
        }

        [Fact]
        public void Null_Should_Match_DigitComma()
        {
            List a = new List(new Range('0', '9'), new Character(','));
            Assert.True(a.Match(null).Success() == true);
            Assert.True(a.Match(null).RemainingText() == null);
        }

        public List GetList()
        {
            IPattern digits = new OneOrMore(new Range('0', '9'));
            IPattern whitespace = new Many(new Any(" \r\n\t"));
            IPattern separator = new Sequence(whitespace, new Character(';'), whitespace);
            return (new List(digits, separator));
        }
       
        [Fact]
        public void Null_Should_Match_ListOfPatterns()
        {
            List a = GetList();
            Assert.True(a.Match(null).Success() == true);
            Assert.True(a.Match(null).RemainingText() == null);
        }

        [Fact]
        public void DigitsSeparatorsDigits_Should_Match_ListOfPatterns()
        {
            List a = GetList();
            Assert.True(a.Match("1; 22  ;\n 333 \t; 22").Success() == true);
            Assert.True(a.Match("1; 22  ;\n 333 \t; 22").RemainingText() == "");
        }

        [Fact]
        public void DigitsSeparators_Should_Match_ListOfPatterns()
        {
            List a = GetList();
            Assert.True(a.Match("1 \n;").Success() == true);
            Assert.True(a.Match("1 \n;").RemainingText() == " \n;");
        }

        [Fact]
        public void Letters_Should_Match_ListOfPatterns()
        {
            List a = GetList();
            Assert.True(a.Match("abc").Success() == true);
            Assert.True(a.Match("abc").RemainingText() == "abc");
        }

        [Fact]
        public void Empty_Should_Match_ListOfPatterns()
        {
            List a = GetList();
            Assert.True(a.Match("").Success() == true);
            Assert.True(a.Match("").RemainingText() == "");
        }
    }
}
