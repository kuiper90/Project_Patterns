using Patterns;
using Xunit;

namespace UnitTest_Patterns
{
    public class UnitTest_Sequence
    {
        [Fact]
        public void StringMatchesSequence()
        {
            Sequence ab = new Sequence(
                    new Character('a'),
                    new Character('b')
                );
            Assert.True(ab.Match("ab").Success());
            Assert.True(ab.Match("ab").RemainingText()?.Length == 0);
        }

        [Fact]
        public void StringDoesNotMatchPartiallyDifferentSequence()
        {
            Sequence ab = new Sequence(
                    new Character('a'),
                    new Character('b')
                );
            Assert.False(ab.Match("ax").Success());
            Assert.True(ab.Match("ax").RemainingText() == "ax");
        }

        [Fact]
        public void StringDoesNotMatchDifferentSequence()
        {
            Sequence ab = new Sequence(
                    new Character('a'),
                    new Character('b')
                );
            Assert.False(ab.Match("def").Success());
            Assert.True(ab.Match("def").RemainingText() == "def");
        }

        [Fact]
        public void EmptyStringDoesNotMatchSequence()
        {
            Sequence ab = new Sequence(
                    new Character('a'),
                    new Character('b')
                );
            Assert.False(ab.Match("").Success());
            Assert.True(ab.Match("").RemainingText()?.Length == 0);
        }

        [Fact]
        public void EmptyInputMatchesSequence()
        {
            Choice digitPattern = new Choice(
                    new Character('0'),
                    new Range('1', '9')
                );
            Choice hexaPattern = new Choice(
                    digitPattern,
                    new Range('a', 'f'),
                    new Range('A', 'F')
                );
            Sequence sequence = new Sequence(
                    new Character('u'),
                    new Sequence(
                        hexaPattern,
                        hexaPattern,
                        hexaPattern,
                        hexaPattern
                    )
                );
            Assert.False(sequence.Match("").Success());
            Assert.True(sequence.Match("").RemainingText()?.Length == 0);
        }

        [Fact]
        public void HexaOfDigitsMatchesSequence()
        {
            Choice digitPattern = new Choice(
                    new Character('0'),
                    new Range('1', '9')
                );
            Choice hexaPattern = new Choice(
                    digitPattern,
                    new Range('a', 'f'),
                    new Range('A', 'F')
                );
            Sequence sequence = new Sequence(
                    new Character('u'),
                    new Sequence(
                        hexaPattern,
                        hexaPattern,
                        hexaPattern,
                        hexaPattern
                    )
                );
            Assert.True(sequence.Match("u1234").Success());
            Assert.True(sequence.Match("u1234").RemainingText()?.Length == 0);
        }

        [Fact]
        public void HexaofDigitsAndLettersMatchesSequence()
        {
            Choice digitPattern = new Choice(
                    new Character('0'),
                    new Range('1', '9')
                );
            Choice hexaPattern = new Choice(
                    digitPattern,
                    new Range('a', 'f'),
                    new Range('A', 'F')
                );
            Sequence sequence = new Sequence(
                    new Character('u'),
                    new Sequence(
                        hexaPattern,
                        hexaPattern,
                        hexaPattern,
                        hexaPattern
                    )
                );
            Assert.True(sequence.Match("u7f3b").Success());
            Assert.True(sequence.Match("u7f3b").RemainingText()?.Length == 0);
        }

        [Fact]
        public void StringWithHexaMatchesSequence()
        {
            Choice digitPattern = new Choice(
                    new Character('0'),
                    new Range('1', '9')
                );
            Choice hexaPattern = new Choice(
                    digitPattern,
                    new Range('a', 'f'),
                    new Range('A', 'F')
                );
            Sequence sequence = new Sequence(new Character('u'),
                    new Sequence(
                        hexaPattern,
                        hexaPattern,
                        hexaPattern,
                        hexaPattern
                    )
                );
            Assert.True(sequence.Match("uabcdef").Success());
            Assert.True(sequence.Match("uabcdef").RemainingText() == "ef");
        }

        [Fact]
        public void StringWithHexaAndSpaceMatchesSequence()
        {
            Choice digitPattern = new Choice(
                    new Character('0'),
                    new Range('1', '9')
                );
            Choice hexaPattern = new Choice(
                    digitPattern,
                    new Range('a', 'f'),
                    new Range('A', 'F')
                );
            Sequence sequence = new Sequence(new Character('u'),
                    new Sequence(
                        hexaPattern,
                        hexaPattern,
                        hexaPattern,
                        hexaPattern
                    )
                );
            Assert.True(sequence.Match("uB005 ab").Success());
            Assert.True(sequence.Match("uB005 ab").RemainingText() == " ab");
        }

        [Fact]
        public void IncompleteHexaDoesNotMatchSequence()
        {
            Choice digitPattern = new Choice(
                    new Character('0'),
                    new Range('1', '9')
                );
            Choice hexaPattern = new Choice(digitPattern,
                    new Range('a', 'f'),
                    new Range('A', 'F')
                );
            Sequence sequence = new Sequence(
                    new Character('u'),
                    new Sequence(
                        hexaPattern,
                        hexaPattern,
                        hexaPattern,
                        hexaPattern
                    )
                );
            Assert.False(sequence.Match("u139").Success());
            Assert.True(sequence.Match("u139").RemainingText() == "u139");
        }

        [Fact]
        public void IncorrectHexaDoesNotMatchSequence()
        {
            Choice digitPattern = new Choice(
                    new Character('0'),
                    new Range('1', '9')
                );
            Choice hexaPattern = new Choice(
                    digitPattern,
                    new Range('a', 'f'),
                    new Range('A', 'F')
                );
            Sequence sequence = new Sequence(
                    new Character('u'),
                    new Sequence(
                        hexaPattern,
                        hexaPattern,
                        hexaPattern,
                        hexaPattern
                    )
                );
            Assert.False(sequence.Match("u123z").Success());
            Assert.True(sequence.Match("u123z").RemainingText() == "u123z");
        }

        [Fact]
        public void NullDoesNotMatchSequence()
        {
            Choice pattern = new Choice(
                    new Character('\0'),
                    new Range((char)8, (char)13)
                );
            Sequence sequence = new Sequence(
                    pattern,
                    new Range((char)32, (char)127)
                );
            Assert.False(sequence.Match(null).Success());
            Assert.True(sequence.Match(null).RemainingText() == null);
        }

        [Fact]
        public void NegativeThreeDigitNoMatchesSequence()
        {
            Choice digitPattern = new Choice(
                    new Character('0'),
                    new Range('1', '9')
                );
            Sequence sequence = new Sequence(
                    new Character('-'),
                    digitPattern,
                    digitPattern,
                    digitPattern
                );
            Assert.True(sequence.Match("-100").Success());
            Assert.True(sequence.Match("-100").RemainingText() == "");
        }
    }
}
