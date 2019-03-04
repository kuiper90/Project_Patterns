using System;
using Patterns;
using Xunit;

namespace Patterns
{
    public class UnitTest_Sequence
    {
        public Choice GetDigit()
        {
            return (new Choice(new Character('0'), new Range('1', '9')));
        }

        public Choice GetHex()
        {
            return (new Choice(GetDigit(), new Range('a', 'f'), new Range('A', 'F')));
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
