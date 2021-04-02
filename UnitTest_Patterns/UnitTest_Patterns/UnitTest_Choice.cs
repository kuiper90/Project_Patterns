using Patterns;
using Xunit;

namespace UnitTest_Patterns
{
    public class UnitTest_Choice
    {
        [Fact]
        public void ChoiceMatchesOneDigitString()
        {
            Choice choice = new Choice(new IPattern[] {
                new Character('0'),
                new Range('1', '9')
            });
            Assert.True(choice.Match("0").Success());
            Assert.True(choice.Match("0").RemainingText()?.Length == 0);
        }

        [Fact]
        public void ChoiceMatchesFirstDigitInNumber()
        {
            Choice choice = new Choice(new IPattern[] {
                new Character('0'),
                new Range('1', '9')
            });
            Assert.True(choice.Match("102").Success());
            Assert.True(choice.Match("102").RemainingText() == "02");
        }

        [Fact]
        public void ChoiceMatchesFirstDigitInDigitString()
        {
            Choice choice = new Choice(new IPattern[] {
                new Character('0'),
                new Range('1', '9')
            });
            Assert.True(choice.Match("012").Success());
            Assert.True(choice.Match("012").RemainingText() == "12");
        }

        [Fact]
        public void ChoiceDoesNotMatchIfCharacterNotInPattern()
        {
            Choice choice = new Choice(new IPattern[] {
                new Character('0'),
                new Range('1', '9')
            });
            Assert.False(choice.Match("a9").Success());
            Assert.True(choice.Match("a9").RemainingText() == "a9");
        }

        [Fact]
        public void ChoiceDoesNotMatchEmptyString()
        {
            Choice choice = new Choice(new IPattern[] {
                new Character('0'),
                new Range('1', '9')
            });
            Assert.False(choice.Match("").Success());
            Assert.True(choice.Match("").RemainingText()?.Length == 0);
        }

        [Fact]
        public void ChoiceDoesNotMatchNull()
        {
            Choice choice = new Choice(new IPattern[] {
                new Character('0'),
                new Range('1', '9')
            });
            Assert.False(choice.Match(null).Success());
            Assert.True(choice.Match(null).RemainingText() == null);
        }

        [Fact]
        public void ChoiceMatchesFirstCharacterInAlphanumericString()
        {
            Choice digit = new Choice(
                    new Character('0'),
                    new Range('1', '9')
                    );
            Choice choice = new Choice(
                    digit,
                    new Choice(
                        new Range('a', 'z'),
                        new Range('A', 'Z')
                        )
                    );
            Assert.True(choice.Match("t0agh").Success());
            Assert.True(choice.Match("t0agh").RemainingText() == "0agh");
        }

        public void ChoiceMatchesFirstCharacterInVariousRanges()
        {
            Choice allCharacters = new Choice(
                    new Range((char)32, (char)47),
                    new Range((char)58, (char)64)
                    );
            Choice choice = new Choice(
                    allCharacters,
                    new Choice(
                        new Range('a', 'z'),
                        new Range('A', 'Z')
                        )
                    );
            Assert.True(choice.Match("#@ta^%&gh").Success());
            Assert.True(choice.Match("#@ta^%&gh").RemainingText() == "#ta^%&gh");
        }

        public void ChoiceMatchesFirstCharacterInSpecialCharactersString()
        {
            Choice character = new Choice(
                    new Character((char)8),
                    new Character((char)9)
                    );
            Choice choice = new Choice(
                    character,
                    new Choice(
                        new Character((char)10),
                        new Character((char)12)
                        )
                    );
            Assert.True(choice.Match("\b\t\n\r").Success());
            Assert.True(choice.Match("\b\t\n\r").RemainingText() == "\t\n\r");
        }

        [Fact]
        public void ChoiceMatchesFirstCharacterInAnyGivenRange()
        {
            Choice choice = new Choice(
                        new Range((char)8, (char)13),
                        new Range((char)33, (char)127)
                    );
            Assert.True(choice.Match("*+-,whoksj.@#$!%\\^%&CTBVXkN").Success());
            Assert.True(choice.Match("*+-,whoksj.@#$!%\\^%&CTBVXkN").RemainingText() == "+-,whoksj.@#$!%\\^%&CTBVXkN");
        }
    }
}
