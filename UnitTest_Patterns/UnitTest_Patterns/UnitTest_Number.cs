using System;
using Patterns;
using Xunit;

namespace Patterns
{
    public class UnitTest_Number
    {
        [Fact]
        public void ShouldBe_True_UnsignedByte()
        {
            IPattern number = new Number();
            Assert.True(number.Match("234").Success());
            Assert.True(number.Match("234").RemainingText() == "");
        }

        [Fact]
        public void ShouldBe_True_SignedByte()
        {
            IPattern number = new Number();
            Assert.True(number.Match("-123").Success());
            Assert.True(number.Match("-123").RemainingText() == "");
        }

        [Fact]
        public void ShouldBe_True_Float()
        {
            IPattern number = new Number();
            Assert.True(number.Match("12.34").Success() == true);
            Assert.True(number.Match("12.34").RemainingText() == "");

        }

        [Fact]
        public void ShouldBe_True_FloatWithPositiveExponent1()
        {
            IPattern number = new Number();
            Assert.True(number.Match("12.123e3").Success());
            Assert.True(number.Match("12.123e3").RemainingText() == "");
        }

        [Fact]
        public void ShouldBe_True_FloatWithPositiveExponent2()
        {
            IPattern number = new Number();
            Assert.True(number.Match("12.123E+3").Success());
            Assert.True(number.Match("12.123E+3").RemainingText() == "");
        }

        [Fact]
        public void ShouldBe_True_FloatWithNegativeExponent()
        {
            IPattern number = new Number();
            Assert.True(number.Match("12.123E-2").Success());
            Assert.True(number.Match("12.123E-2").RemainingText() == "");
        }

        [Fact]
        public void ShouldBe_True_UnsignedByteStartWithZero()
        {
            IPattern number = new Number();
            Assert.True(number.Match("012").Success());
            Assert.True(number.Match("012").RemainingText() == "12");
        }

        [Fact]
        public void ShouldBe_True_FloatNoExp()
        {
            IPattern number = new Number();
            Assert.True(number.Match("12.123E").Success());
            Assert.True(number.Match("12.123E").RemainingText() == "E");
        }

        [Fact]
        public void ShouldBe_True_UnsignedByteEndWithPeriod()
        {
            IPattern number = new Number();
            Assert.True(number.Match("12.").Success());
            Assert.True(number.Match("12.").RemainingText() == ".");
        }

        [Fact]
        public void ShouldBe_False_Period()
        {
            IPattern number = new Number();
            Assert.False(number.Match(".").Success());
            Assert.True(number.Match(".").RemainingText() == ".");
        }

        [Fact]
        public void ShouldBe_False_PeriodDigit()
        {
            IPattern number = new Number();
            Assert.False(number.Match(".5").Success());
            Assert.True(number.Match(".5").RemainingText() == ".5");
        }

        [Fact]
        public void ShouldBe_True_ZeroPeriod()
        {
            IPattern number = new Number();
            Assert.True(number.Match("0.").Success());
            Assert.True(number.Match("0.").RemainingText() == ".");
        }

        [Fact]
        public void ShouldBe_True_FloatNoFractionalPartWithExp()
        {
            IPattern number = new Number();
            Assert.True(number.Match("123.E15").Success());
            Assert.True(number.Match("123.E15").RemainingText() == ".E15");
        }

        [Fact]
        public void ShouldBe_True_NegFloatNoFractionalPartWithNegExp()
        {
            IPattern number = new Number();
            Assert.True(number.Match("-123.E-15").Success());
            Assert.True(number.Match("-123.E-15").RemainingText() == ".E-15");
        }

        [Fact]
        public void ShouldBe_True_NegFloatWithNegExp()
        {
            IPattern number = new Number();
            Assert.True(number.Match("-123.1E-15").Success());
            Assert.True(number.Match("-123.1E-15").RemainingText() == "");
        }

        [Fact]
        public void ShouldBe_False_Exp()
        {
            IPattern number = new Number();
            Assert.False(number.Match("e").Success());
            Assert.True(number.Match("e").RemainingText() == "e");
        }

        [Fact]
        public void ShouldBe_False_FractionalExp()
        {
            IPattern number = new Number();
            Assert.False(number.Match(".e").Success());
            Assert.True(number.Match(".e").RemainingText() == ".e");
        }

        [Fact]
        public void ShouldBe_False_FloatExp()
        {
            IPattern number = new Number();
            Assert.False(number.Match("e.").Success());
            Assert.True(number.Match("e.").RemainingText() == "e.");
        }

        [Fact]
        public void ShouldBe_False_DoubleZero()
        {
            IPattern number = new Number();
            Assert.True(number.Match("00").Success());
            Assert.True(number.Match("00").RemainingText() == "0");
        }

        [Fact]
        public void ShouldBe_True_Zero()
        {
            IPattern number = new Number();
            Assert.True(number.Match("0").Success());
            Assert.True(number.Match("0").RemainingText() == "");
        }

        [Fact]
        public void ShouldBe_True_MinusZero()
        {
            IPattern number = new Number();
            Assert.True(number.Match("-0").Success());
            Assert.True(number.Match("-0").RemainingText() == "");
        }

        [Fact]
        public void ShouldBe_True_NegFloatZeroFractionalPartWithNegExp()
        {
            IPattern number = new Number();
            Assert.True(number.Match("-123.0E-15").Success());
            Assert.True(number.Match("-123.0E-15").RemainingText() == "");
        }

        [Fact]
        public void ShouldBe_False_NegFloatWithNegFractionalExp()
        {
            IPattern number = new Number();
            Assert.True(number.Match("-123.01E-1.5").Success());
            Assert.True(number.Match("-123.01E-1.5").RemainingText() == ".5");
        }

        [Fact]
        public void ShouldBe_True_NegFloatWithDoubleNegExp()
        {
            IPattern number = new Number();
            Assert.True(number.Match("-123.01Ee-15").Success());
            Assert.True(number.Match("-123.01Ee-15").RemainingText() == "Ee-15");
        }

        [Fact]
        public void ShouldBe_False_NegZeroMinusExp()
        {
            IPattern number = new Number();
            Assert.True(number.Match("-0-e12").Success());
            Assert.True(number.Match("-0-e12").RemainingText() == "-e12");
        }

        [Fact]
        public void ShouldBe_True_NegFloatZeroFractionalPartWithPosEx()
        {
            IPattern number = new Number();
            Assert.True(number.Match("12.0E+2").Success());
            Assert.True(number.Match("12.0E+2").RemainingText() == "");
        }

        [Fact]
        public void ShouldBe_False_EmtpyNumber()
        {
            IPattern number = new Number();
            Assert.False(number.Match("").Success());
            Assert.True(number.Match("").RemainingText() == "");
        }
    }
}