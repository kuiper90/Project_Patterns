using System;
using Patterns;
using Xunit;

namespace Patterns
{
    public class UnitTest_Choice
    {
        public Choice GetDigit()
        {
            return (new Choice(new Character('0'), new Range('1', '9')));
        }

        [Fact]
        public void FirstChar_ShouldNot_Match_Digit()
        {
            Choice choice = GetDigit();
            Assert.True(choice.Match("casper").Success() == false);
            Assert.True(choice.Match("casper").RemainingText() == "casper");
        }

        [Fact]
        public void FirstChar_Five_Should_Match_Five()
        {
            Choice choice = GetDigit();
            Assert.True(choice.Match("5casper").Success() == true);
            Assert.True(choice.Match("5casper").RemainingText() == "casper");
        }

        [Fact]
        public void FirstChar_Zero_Should_Match_Zero()
        {
            Choice choice = GetDigit();
            Assert.True(choice.Match("0casper").Success() == true);
            Assert.True(choice.Match("0casper").RemainingText() == "casper");
        }

        [Fact]
        public void EmptyInput_Should_Match_Digit()
        {
            Choice choice = GetDigit();
            Assert.True(choice.Match("").Success() == false);
            Assert.True(choice.Match("").RemainingText() == "");
        }

        [Fact]
        public void TwoDigits_Should_Match_Choice()
        {
            Choice choice = new Choice(GetDigit(), new Choice(new Range('a', 'f'), new Range('A', 'F')));
            Assert.True(choice.Match("012").Success() == true);
            Assert.True(choice.Match("012").RemainingText() == "12");
        }

        [Fact]
        public void ThreeDigits_Should_Match_Choice()
        {
            Choice choice = new Choice(GetDigit(), new Choice(new Range('a', 'f'), new Range('A', 'F')));
            Assert.True(choice.Match("12").Success() == true);
            Assert.True(choice.Match("12").RemainingText() == "2");
        }

        [Fact]
        public void LowCharDigit_Should_Match_Choice()
        {
            Choice choice = new Choice(GetDigit(), new Choice(new Range('a', 'f'), new Range('A', 'F')));
            Assert.True(choice.Match("a9").Success() == true);
            Assert.True(choice.Match("a9").RemainingText() == "9");
        }

        [Fact]
        public void UpCharDigit_Should_Match_Choice()
        {
            Choice choice = new Choice(GetDigit(), new Choice(new Range('a', 'f'), new Range('A', 'F')));
            Assert.True(choice.Match("F8").Success() == true);
            Assert.True(choice.Match("F8").RemainingText() == "8");
        }

        [Fact]
        public void LowIncorrectCharDigit_ShouldNot_Match_Choice()
        {
            Choice choice = new Choice(GetDigit(), new Choice(new Range('a', 'f'), new Range('A', 'F')));
            Assert.True(choice.Match("g8").Success() == false);
            Assert.True(choice.Match("g8").RemainingText() == "g8");
        }

        [Fact]
        public void EmptyInput_Should_Match_Choice()
        {
            Choice choice = new Choice(GetDigit(), new Choice(new Range('a', 'f'), new Range('A', 'F')));
            Assert.True(choice.Match("").Success() == false);
            Assert.True(choice.Match("").RemainingText() == "");
        }
    }
}
