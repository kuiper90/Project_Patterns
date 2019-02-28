using System;
using Patterns;
using Xunit;

namespace UnitTest_Patterns
{
    public class UnitTest_Pattern
    {
        public Choice GetDigit()
        {
            return (new Choice(new Character('0'), new Range('1', '9')));
        }

        public Choice GetHex()
        {
            return (new Choice(new Range('0', '9'), new Range('a', 'f'), new Range('A', 'F')));
        }

        [Fact]
        public void InputFirstChar_ShouldMatch_Char()
        {
            Character chr = new Character('c');
            Assert.True(chr.Match("casper").Success() == true);
            Assert.True(chr.Match("casper").RemainingText() == "asper");
        }

        [Fact]
        public void InputFirstChar_ShouldNot_Match_Char()
        {
            Character chr = new Character('d');
            Assert.True(chr.Match("casper").Success() == false);
            Assert.True(chr.Match("casper").RemainingText() == "casper");
        }

        [Fact]
        public void EmptyInput_ShouldNot_Match_Char()
        {
            Character chr = new Character('d');
            Assert.False(chr.Match("").Success() == true);
            Assert.True(chr.Match("").RemainingText() == "");
        }

        [Fact]
        public void InputFirstChar_ShouldNot_Match_Range()
        {
            Range range = new Range('d', 'g');
            Assert.True(range.Match("casper").Success() == false);
            Assert.True(range.Match("casper").RemainingText() == "casper");
        }

        [Fact]
        public void InputFirstChar_Should_Match_Range()
        {
            Range range = new Range('a', 'g');
            Assert.True(range.Match("casper").Success() == true);
            Assert.True(range.Match("casper").RemainingText() == "asper");
        }

        [Fact]
        public void EmptyInput_ShouldNot_Match_Range()
        {
            Range range = new Range('a', 'g');
            Assert.True(range.Match("").Success() == false);
            Assert.True(range.Match("").RemainingText() == "");
        }

        [Fact]
        public void InputFirstChar_ShouldNot_Match_Digit()
        {
            Choice choice = GetDigit();
            Assert.True(choice.Match("casper").Success() == false);
            Assert.True(choice.Match("casper").RemainingText() == "casper");
        }

        [Fact]
        public void InputFirstChar_Five_Should_Match_Five()
        {
            Choice choice = GetDigit();
            Assert.True(choice.Match("5casper").Success() == true);
            Assert.True(choice.Match("5casper").RemainingText() == "casper");
        }

        [Fact]
        public void InputFirstChar_Zero_Should_Match_Zero()
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

        [Fact]
        public void InputFirstChar_Should_Match_SeqPatterns()
        {
            Sequence seq = new Sequence(new Character('a'), new Character('b'));
            Assert.True(seq.Match("012").Success() == false);
            Assert.True(seq.Match("012").RemainingText() == "012");
        }

        [Fact]
        public void InputString_Should_Match_SeqCharPatterns()
        {
            Sequence seq = new Sequence(new Character('a'), new Character('b'));
            Assert.True(seq.Match("abcd").Success() == true);
            Assert.True(seq.Match("abcd").RemainingText() == "cd");
        }

        [Fact]
        public void EmptyInput_Should_Match_SeqCharPatterns()
        {
            Sequence seq = new Sequence(new Character('a'), new Character('b'));
            Assert.True(seq.Match("").Success() == false);
            Assert.True(seq.Match("").RemainingText() == "");
        }

        [Fact]
        public void EmptyInput_Should_Match_SeqPatterns()
        {
            Sequence seq = new Sequence(new Character('u'), new Sequence(GetHex(), GetHex(), GetHex(), GetHex()));
            Assert.True(seq.Match("").Success() == false);
            Assert.True(seq.Match("").RemainingText() == "");
        }

        [Fact]
        public void Hexa_Should_Match_SeqPatterns()
        {
            Sequence seq = new Sequence(new Character('u'), new Sequence(GetHex(), GetHex(), GetHex(), GetHex()));
            Assert.True(seq.Match("u1234").Success() == true);
            Assert.True(seq.Match("u1234").RemainingText() == "");
        }

        [Fact]
        public void InputContainingHexa_Should_Match_SeqHexa()
        {
            Sequence seq = new Sequence(new Character('u'), new Sequence(GetHex(), GetHex(), GetHex(), GetHex()));
            Assert.True(seq.Match("uB005 ab").Success() == true);
            Assert.True(seq.Match("uB005 ab").RemainingText() == " ab");
        }

        [Fact]
        public void InputHexa_Should_Match_SeqHexa()
        {
            Sequence seq = new Sequence(new Character('u'), new Sequence(GetHex(), GetHex(), GetHex(), GetHex()));
            Assert.True(seq.Match("u123b").Success() == true);
            Assert.True(seq.Match("u123b").RemainingText() == "");
        }

        [Fact]
        public void IncompleteHexa_ShouldNot_Match_SeqPatterns()
        {
            Sequence seq = new Sequence(new Character('u'), new Sequence(GetHex(), GetHex(), GetHex(), GetHex()));
            Assert.True(seq.Match("u123").Success() == false);
            Assert.True(seq.Match("u123").RemainingText() == "u123");
        }

        [Fact]
        public void IncorrectCharHexa_ShouldNot_Match_SeqPatterns()
        {
            Sequence seq = new Sequence(new Character('u'), new Sequence(GetHex(), GetHex(), GetHex(), GetHex()));
            Assert.True(seq.Match("u123z").Success() == false);
            Assert.True(seq.Match("u123z").RemainingText() == "u123z");
        }

        [Fact]
        public void DigitFirstCharHexa_ShouldNot_Match_SeqPatterns()
        {
            Sequence seq = new Sequence(new Character('u'), new Sequence(GetHex(), GetHex(), GetHex(), GetHex()));
            Assert.True(seq.Match("123b").Success() == false);
            Assert.True(seq.Match("123b").RemainingText() == "123b");
        }
    }
}
