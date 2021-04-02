using Patterns;
using Xunit;

namespace UnitTest_Patterns
{
    public class UnitTest_Any
    {
        [Fact]
        public void LowerCaseFirstCharacterMatchesAny()
        {
            Any pattern = new Any("eE");
            Assert.True(pattern.Match("ea").Success());
            Assert.True(pattern.Match("ea").RemainingText() == "a");
        }

        [Fact]
        public void UpperCaseFirstCharacterMatchesAny()
        {
            Any pattern = new Any("Ea");
            Assert.True(pattern.Match("Ea").Success());
            Assert.True(pattern.Match("Ea").RemainingText() == "a");
        }

        [Fact]
        public void CharacterNotInPatternDoesNotMatchAny()
        {
            Any pattern = new Any("eE");
            Assert.False(pattern.Match("a").Success());
            Assert.True(pattern.Match("a").RemainingText() == "a");
        }

        [Fact]
        public void EmptyStringDoesNotMatchAny()
        {
            Any pattern = new Any("eE");
            Assert.False(pattern.Match("").Success());
            Assert.True(pattern.Match("").RemainingText()?.Length == 0);
        }

        [Fact]
        public void NullDoesNotMatchAny()
        {
            Any pattern = new Any("eE");
            Assert.False(pattern.Match(null).Success());
            Assert.True(pattern.Match(null).RemainingText() == null);
        }

        [Fact]
        public void PlusMatchesAnySigns()
        {
            Any pattern = new Any("-+");
            Assert.True(pattern.Match("+3").Success());
            Assert.True(pattern.Match("+3").RemainingText() == "3");
        }

        [Fact]
        public void MinusMatchesAnySigns()
        {
            Any pattern = new Any("-+");
            Assert.True(pattern.Match("-8").Success());
            Assert.True(pattern.Match("-8").RemainingText() == "8");
        }

        [Fact]
        public void DigitDoesNotMatchAnySigns()
        {
            Any pattern = new Any("-+");
            Assert.False(pattern.Match("2").Success());
            Assert.True(pattern.Match("2").RemainingText() == "2");
        }

        [Fact]
        public void EmptyDoesNotMatchAnySigns()
        {
            Any pattern = new Any("-+");
            Assert.False(pattern.Match("").Success());
            Assert.True(pattern.Match("").RemainingText()?.Length == 0);
        }

        [Fact]
        public void NullDoesNotMatchAnySigns()
        {
            Any pattern = new Any("-+");
            Assert.False(pattern.Match(null).Success());
            Assert.True(pattern.Match(null).RemainingText() == null);
        }
    }
}
