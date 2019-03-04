using System;
using Patterns;
using Xunit;

namespace Patterns
{
    public class UnitTest_Character
    {
        [Fact]
        public void FirstChar_ShouldMatch_Char()
        {
            Character chr = new Character('c');
            Assert.True(chr.Match("casper").Success() == true);
            Assert.True(chr.Match("casper").RemainingText() == "asper");
        }

        [Fact]
        public void FirstChar_ShouldNot_Match_Char()
        {
            Character chr = new Character('d');
            Assert.True(chr.Match("casper").Success() == false);
            Assert.True(chr.Match("casper").RemainingText() == "casper");
        }

        [Fact]
        public void Empty_ShouldNot_Match_Char()
        {
            Character chr = new Character('d');
            Assert.False(chr.Match("").Success() == true);
            Assert.True(chr.Match("").RemainingText() == "");
        }         
    }
}
