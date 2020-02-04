using NUnit.Framework;
using PolynomialTask;
using System;

namespace PolymomialTask.Tests
{
    public class PolynomialTests
    {
        #region Sum two polynomials
        [TestCase(new double[] { 1, 1, 1 }, new double[] { 2, 2, 2 }, new double[] { 3, 3, 3 }, ExpectedResult = true)]
        [TestCase(new double[] { 1, 0, 2 }, new double[] { 0, 0, 1, 2, 2 }, new double[] { 1, 0, 3, 2, 2 }, ExpectedResult = true)]
        [TestCase(new double[] { 0, 2 }, new double[] { 0, 0, 1, 2, 2 }, new double[] { 1, 0, 2 }, ExpectedResult = false)]
        public bool Polynomial_Sum_Tests(double[] arrLhs, double[] arrRhs, double[] excepted)
        {
            var lhs = new Polynomial(arrLhs);
            var rhs = new Polynomial(arrRhs);
            return Polynomial_Method_Sum_Tests(lhs, rhs, excepted);
        }
        public bool Polynomial_Method_Sum_Tests(Polynomial lhs, Polynomial rhs, double[] excepted)
        {
            var result = lhs + rhs;
            var expected = new Polynomial(excepted);
           
            return result == expected;
        }
        #endregion

        #region Substraction two polynomials
        [TestCase(new double[] { 1, 1, 1 }, new double[] { 2, 2, 2 }, new double[] { -1, -1, -1 }, ExpectedResult = true)]
        [TestCase(new double[] { 1, 0, 2 }, new double[] { 0, 0, 1, 2, 2 }, new double[] { 1, 0, 1, -2, -2 }, ExpectedResult = true)]
        [TestCase(new double[] { 0, 2 }, new double[] { 0, 0, 1, 2, 2 }, new double[] { 1, 0, 2 }, ExpectedResult = false)]
        public bool Polynomial_Subtraction_Tests(double[] arrLhs, double[] arrRhs, double[] excepted)
        {
            var lhs = new Polynomial(arrLhs);
            var rhs = new Polynomial(arrRhs);
            return Polynomial_Method_Subtraction_Tests(lhs, rhs, excepted);
        }
        public bool Polynomial_Method_Subtraction_Tests(Polynomial lhs, Polynomial rhs, double[] excepted)
        {
            var result = lhs - rhs;
            var expected = new Polynomial(excepted);
            return result == expected;
        }
        #endregion

        #region Multiplication two polynomials
        [TestCase(new double[] { 1, 1, 1 }, new double[] { 5, 0, 0, 2, 4 }, new double[] { 5, 5, 5, 2, 6, 6, 4 }, ExpectedResult = true)]
        [TestCase(new double[] { 1, 0, 2 }, new double[] { 0, 0, 0, 8 }, new double[] { 0, 1, 0, 8, 0, 16 }, ExpectedResult = false)]
        [TestCase(new double[] { 2, 1 }, new double[] { 0, 1, 0, 8 }, new double[] { 0, 2, 1, 16, 8 }, ExpectedResult = true)]
        public bool Polynomial_Mult_Tests(double[] arrLhs, double[] arrRhs, double[] excepted)
        {
            var lhs = new Polynomial(arrLhs);
            var rhs = new Polynomial(arrRhs);
            return Polynomial_Method_Mult_Tests(lhs, rhs, excepted);
        }
        public bool Polynomial_Method_Mult_Tests(Polynomial lhs, Polynomial rhs, double[] excepted)
        {
            var result = lhs * rhs;
            var expected = new Polynomial(excepted);
            return result == expected;
        }
        #endregion

        #region Compiring two polynomials by ==
        [TestCase(new double[] { 1, 1, 1 }, new double[] { 1, 1, 1 }, ExpectedResult = true)]
        [TestCase(new double[] { 1, 0, 2 }, new double[] { 0, 0, 1, 2, 2 }, ExpectedResult = false)]
        [TestCase(new double[] { 0, 2 }, new double[] { 0, 3 }, ExpectedResult = false)]
        public bool Polynomial_Equal_Tests(double[] arrLhs, double[] arrRhs)
        {
            var lhs = new Polynomial(arrLhs);
            var rhs = new Polynomial(arrRhs);
            return lhs == rhs;
        }
        #endregion
        #region Compiring two polynomials by !=
        [TestCase(new double[] { 1, 1, 1 }, new double[] { 1, 1, 1 }, ExpectedResult = false)]
        [TestCase(new double[] { 1, 0, 2 }, new double[] { 0, 0, 1, 2, 2 }, ExpectedResult = true)]
        [TestCase(new double[] { 0, 2 }, new double[] { 0, 3 }, ExpectedResult = true)]
        public bool Polynomial_NonEqual_Tests(double[] arrLhs, double[] arrRhs)
        {
            var lhs = new Polynomial(arrLhs);
            var rhs = new Polynomial(arrRhs);
            return lhs != rhs;
        }
        #endregion

        [Test]
        public void Empty_Polynomial_ArgumentException()
        {
            var arr = new double[] { };
            Assert.Throws<ArgumentException>(() => NewPolynomial(arr));
        }
        [Test]
        public void Null_Polynomial_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => NewPolynomial(null));
        }

        public void NewPolynomial(double[] array)
        {
            var result = new Polynomial(array);
        }
    }
}