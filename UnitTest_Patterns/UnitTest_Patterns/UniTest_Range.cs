using System;
using Patterns;
using Xunit;

namespace Patterns
{
    public class UniTest_Range
    {
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
    }
}
