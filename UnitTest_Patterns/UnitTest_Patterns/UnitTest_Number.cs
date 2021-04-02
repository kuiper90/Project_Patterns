using Patterns;
using Xunit;

namespace UnitTest_Patterns
{
    public class UnitTest_Number
    {
        [Fact]
        public void UnsignedByteMatchesNumber()
        {
            IPattern number = new Number();
            Assert.True(number.Match("753").Success());
            Assert.True(number.Match("753").RemainingText()?.Length == 0);
        }

        [Fact]
        public void UnsignedDigitSequenceMatchesNumber()
        {
            IPattern number = new Number();
            Assert.True(number.Match("023").Success());
            Assert.True(number.Match("023").RemainingText() == "23");
        }

        [Fact]
        public void SignedByteMatchesNumber()
        {
            IPattern number = new Number();
            Assert.True(number.Match("-78").Success());
            Assert.True(number.Match("-78").RemainingText()?.Length == 0);
        }

        [Fact]
        public void RealNumberMatchesNumber()
        {
            IPattern number = new Number();
            Assert.True(number.Match("75.13").Success());
            Assert.True(number.Match("75.13").RemainingText()?.Length == 0);

        }

        [Fact]
        public void RealNumberAndExponentMatchesNumber()
        {
            IPattern number = new Number();
            Assert.True(number.Match("75.123e3").Success());
            Assert.True(number.Match("75.123e3").RemainingText()?.Length == 0);
        }

        [Fact]
        public void RealNumberAndHighExponentMatchesNumber()
        {
            IPattern number = new Number();
            Assert.True(number.Match("75.123E+3").Success());
            Assert.True(number.Match("75.123E+3").RemainingText()?.Length == 0);
        }

        [Fact]
        public void RealNumberAndNegativeExponentMatchesNumber()
        {
            IPattern number = new Number();
            Assert.True(number.Match("75.123E-2").Success());
            Assert.True(number.Match("75.123E-2").RemainingText()?.Length == 0);
        }

        [Fact]
        public void RealNumberAndIncompleteExponentSequenceMatchesNumber()
        {
            IPattern number = new Number();
            Assert.True(number.Match("75.23E").Success());
            Assert.True(number.Match("75.23E").RemainingText() == "E");
        }

        [Fact]
        public void UnsignedByteEndAndPeriodMatchesNumber()
        {
            IPattern number = new Number();
            Assert.True(number.Match("78.").Success());
            Assert.True(number.Match("78.").RemainingText() == ".");
        }

        [Fact]
        public void PeriodDigitSequenceDoesNotMatchNumber()
        {
            IPattern number = new Number();
            Assert.False(number.Match(".5").Success());
            Assert.True(number.Match(".5").RemainingText() == ".5");
        }

        [Fact]
        public void IntegralPeriodSequenceMatchesNumber()
        {
            IPattern number = new Number();
            Assert.True(number.Match("0.").Success());
            Assert.True(number.Match("0.").RemainingText() == ".");
        }

        [Fact]
        public void IntegralPeriodExponentSequenceMatchesNumber()
        {
            IPattern number = new Number();
            Assert.True(number.Match("754.E9").Success());
            Assert.True(number.Match("754.E9").RemainingText() == ".E9");
        }

        [Fact]
        public void NegativeIntegralPeriodNegativeExponentSequenceMatchesNumber()
        {
            IPattern number = new Number();
            Assert.True(number.Match("-753.E-9").Success());
            Assert.True(number.Match("-753.E-9").RemainingText() == ".E-9");
        }

        [Fact]
        public void NegativeNumberAndNegativeExponentMatchesNumber()
        {
            IPattern number = new Number();
            Assert.True(number.Match("-753.1E-15").Success());
            Assert.True(number.Match("-753.1E-15").RemainingText()?.Length == 0);
        }

        [Fact]
        public void ExponentDoesNotMatchNumber()
        {
            IPattern number = new Number();
            Assert.False(number.Match("e").Success());
            Assert.True(number.Match("e").RemainingText() == "e");
        }

        [Fact]
        public void PeriodExponentSequenceDoesNotMatchNumber()
        {
            IPattern number = new Number();
            Assert.False(number.Match(".e").Success());
            Assert.True(number.Match(".e").RemainingText() == ".e");
        }

        [Fact]
        public void ExponentPeriodSequenceDoesNotMatchNumber()
        {
            IPattern number = new Number();
            Assert.False(number.Match("e.").Success());
            Assert.True(number.Match("e.").RemainingText() == "e.");
        }

        [Fact]
        public void DoubleZeroMatchesNumber()
        {
            IPattern number = new Number();
            Assert.True(number.Match("00").Success());
            Assert.True(number.Match("00").RemainingText() == "0");
        }

        [Fact]
        public void MinusZeroMatchesNumber()
        {
            IPattern number = new Number();
            Assert.True(number.Match("-0").Success());
            Assert.True(number.Match("-0").RemainingText()?.Length == 0);
        }

        [Fact]
        public void DigitMatchesNumber()
        {
            IPattern number = new Number();
            Assert.True(number.Match("7").Success());
            Assert.True(number.Match("7").RemainingText()?.Length == 0);
        }

        [Fact]
        public void NegativeIntegralMinusExponentMatchesNumber()
        {
            IPattern number = new Number();
            Assert.True(number.Match("-0-e9").Success());
            Assert.True(number.Match("-0-e9").RemainingText() == "-e9");
        }

        [Fact]
        public void NegativeRealNumberAndNegativeExponentMatchesNumber()
        {
            IPattern number = new Number();
            Assert.True(number.Match("-754.0E-7").Success());
            Assert.True(number.Match("-754.0E-7").RemainingText()?.Length == 0);
        }

        [Fact]
        public void NegativeNumberAndNegativeRealExponentMatchesNumber()
        {
            IPattern number = new Number();
            Assert.True(number.Match("-754.01E-1.1").Success());
            Assert.True(number.Match("-754.01E-1.1").RemainingText() == ".1");
        }

        [Fact]
        public void NegativeNumberAndNegativeFractionalExponentMatchesNumber()
        {
            IPattern number = new Number();
            Assert.True(number.Match("-754.01E-1.0").Success());
            Assert.True(number.Match("-754.01E-1.0").RemainingText() == ".0");
        }

        [Fact]
        public void NegativeRealNumberAndDoubleNegativeExponentMatchesNumber()
        {
            IPattern number = new Number();
            Assert.True(number.Match("-754.01Ee-7").Success());
            Assert.True(number.Match("-754.01Ee-7").RemainingText() == "Ee-7");
        }

        [Fact]
        public void NegativeRealNumberAndExponentMatchesNumber()
        {
            IPattern number = new Number();
            Assert.True(number.Match("14.0E+7").Success());
            Assert.True(number.Match("14.0E+7").RemainingText()?.Length == 0);
        }

        [Fact]
        public void EmtpyDoesNotMatchNumber()
        {
            IPattern number = new Number();
            Assert.False(number.Match("").Success());
            Assert.True(number.Match("").RemainingText()?.Length == 0);
        }
    }
}