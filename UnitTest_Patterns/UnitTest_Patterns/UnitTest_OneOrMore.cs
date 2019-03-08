using System;
using Patterns;
using Xunit;

namespace Patterns
{
    public class UnitTest_OneOrMore
    {
        [Fact]
        public void FirstChar_Should_Match_Char()
        {
            OneOrMore a = new OneOrMore(new Character('a'));
            Assert.True(a.Match("abc").Success() == true);
            Assert.True(a.Match("abc").RemainingText() == "bc");
        }

        [Fact]
        public void MultipleFirstChar_Should_Match_Char()
        {
            OneOrMore a = new OneOrMore(new Character('a'));
            Assert.True(a.Match("aaaabc").Success() == true);
            Assert.True(a.Match("aaaabc").RemainingText() == "bc");
        }

        [Fact]
        public void InputFirstChar_Should_Match_Char()
        {
            OneOrMore a = new OneOrMore(new Character('a'));
            Assert.True(a.Match("bc").Success() == false);
            Assert.True(a.Match("bc").RemainingText() == "bc");
        }

        [Fact]
        public void Empty_Should_Match_Char()
        {
            OneOrMore a = new OneOrMore(new Character('a'));
            Assert.True(a.Match("").Success() == false);
            Assert.True(a.Match("").RemainingText() == "");
        }

        [Fact]
        public void FirstCharDigit_Should_Match_Char()
        {
            OneOrMore a = new OneOrMore(new Character('a'));
            Assert.True(a.Match("1 a").Success() == false);
            Assert.True(a.Match("1 a").RemainingText() == "1 a");
        }

        [Fact]
        public void FirstCharWhitespace_ShouldNot_Match_Char()
        {
            OneOrMore a = new OneOrMore(new Character('a'));
            Assert.True(a.Match(" a").Success() == false);
            Assert.True(a.Match(" a").RemainingText() == " a");
        }

        [Fact]
        public void FirstCharAndSpace_Should_Match_Char()
        {
            OneOrMore a = new OneOrMore(new Character('a'));
            Assert.True(a.Match("a ").Success() == true);
            Assert.True(a.Match("a ").RemainingText() == " ");
        }

        [Fact]
        public void FirstNumber_Should_Match_RangeOfDigits()
        {
            OneOrMore digits = new OneOrMore(new Range('0', '9'));
            Assert.True(digits.Match("12345ab123").Success() == true);
            Assert.True(digits.Match("12345ab123").RemainingText() == "ab123");
        }

        [Fact]
        public void Letters_Should_Match_RangeOfDigits()
        {
            OneOrMore digits = new OneOrMore(new Range('0', '9'));
            Assert.True(digits.Match("ab").Success() == false);
            Assert.True(digits.Match("ab").RemainingText() == "ab");
        }

        [Fact]
        public void Null_ShouldNot_Match_RangeOfDigits()
        {
            OneOrMore digits = new OneOrMore(new Range('0', '9'));
            Assert.True(digits.Match(null).Success() == false);
            Assert.True(digits.Match(null).RemainingText() == null);
        }

        [Fact]
        public void NumberAndChars_Should_Match_RangeOfDigits()
        {
            OneOrMore digits = new OneOrMore(new Range('0', '9'));
            Assert.True(digits.Match("123ab").Success() == true);
            Assert.True(digits.Match("123ab").RemainingText() == "ab");
        }

        [Fact]
        public void Number_Should_Match_RangeOfDigits()
        {
            OneOrMore digits = new OneOrMore(new Range('0', '9'));
            Assert.True(digits.Match("123").Success() == true);
            Assert.True(digits.Match("123").RemainingText() == "");
        }

        [Fact]
        public void MultipleFirstChar_Should_Match_Many_TextPattern()
        {
            OneOrMore a = new OneOrMore(new Text("abc"));
            Assert.True(a.Match("abcabcd").Success() == true);
            Assert.True(a.Match("abcabcd").RemainingText() == "d");
        }
    }
}
