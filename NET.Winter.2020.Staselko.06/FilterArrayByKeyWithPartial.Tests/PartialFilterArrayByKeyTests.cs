using NUnit.Framework;
using System;
using static FilterArrayByKeyWithPartial.ArrayExtension;

namespace FilterArrayByKeyWithPartial.Tests
{
    public class PartialFilterArrayByKeyTests
    {
        #region FilterArrayByKey(int[]array, int digit)

        [TestCase(new[] { 2212332, 1405644, 1236674 }, 0, new[] { 1405644 })]
        [TestCase(new[] { 53, 71, -24, 1001, 32, 1005 }, 2, new[] { -24, 32 })]
        [TestCase(new[] { -27, 173, 371132, 7556, 7243, 10017 }, 7, new[] { -27, 173, 371132, 7556, 7243, 10017 })]
        [TestCase(new[] { 7, 2, 5, 5, -1, -1, 2 }, 9, new int[0])]

        public void FilterArrayByKey_WithPossitivePowers_ExpectedResults(int[] array, int digit, int[] expected)
        {
            Digit = digit;
            Assert.AreEqual(expected, FilterArrayByKey(array));
        }
        #endregion

        [Test]
        public void FilterArrayByKey_WithEmptyArray_ArgumentException() =>
           Assert.Throws<ArgumentException>(() => FilterArrayByKey(new int[0]),
               message: "Array cannot be empty!");

        [Test]
        public void FilterArrayByKey_WithNullArray_ArgumentNullException()
        {
            Digit = 0;
            Assert.Throws<ArgumentNullException>(() => FilterArrayByKey(null),
                message: "Array cannot be null");
        }

        [Test]
        public void FilterArrayByKey_WithNegativeDigit_ArgumentOutOfRangeException()
        {
            //Digit = -1;
            Assert.Throws<ArgumentOutOfRangeException>(() => Digit = -1,
                message: "digit must be >=0 and <=9");

        }
        
    }
}