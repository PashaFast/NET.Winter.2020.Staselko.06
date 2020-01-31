using NUnit.Framework;

namespace TransformerToWords.Tests
{
    public class TransformerTests
    {
        [TestCase(double.NaN, "Not a number")]
        [TestCase(double.NegativeInfinity, "Negative infinity")]
        [TestCase(double.PositiveInfinity, "Positive infinity")]
        [TestCase(-0.0d, "zero")]
        [TestCase(0.0d, "zero")]
        [TestCase(0.1d, "zero point one")]
        [TestCase(-23.809d, "minus two three point eight zero nine")]
        [TestCase(-0.123456789d, "minus zero point one two three four five six seven eight nine")]
        [TestCase(1.23333e308d, "one point two three three three three E plus three zero eight")]
        [TestCase(double.Epsilon, "Epsilon")]
        [TestCase(double.MaxValue, "one point seven nine seven six nine three one three four eight six two three one five seven E plus three zero eight")]
        [TestCase(double.MinValue, "minus one point seven nine seven six nine three one three four eight six two three one five seven E plus three zero eight")]
        [TestCase(double.NegativeInfinity, "Negative infinity")]

        public void TransformToWords_WithSomeCases_ExpectedResults(double number, string expected)
        {
            Assert.AreEqual(expected, new Transformer().TransformToWords(number));
        }
    }
}