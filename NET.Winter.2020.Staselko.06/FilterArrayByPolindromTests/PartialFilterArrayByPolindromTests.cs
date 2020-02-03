using NUnit.Framework;
using System;
using static FilterArrayByPolindrom.ArrayExtension;

namespace FilterArrayByPolindrom.Tests
{
    public class PartialFilterArrayByPolindromTests
    {
        [TestCase(new[] { 11111, 10001, 256 }, new[] { 11111, 10001 })]
        [TestCase(new[] { 2, 3, 4, 5 }, new[] { 2, 3, 4, 5 })]
        [TestCase(new[] { 10101, 101101 }, new[] { 10101, 101101 })]
        [TestCase(new[] { 145, 58, 78, 89 }, new int[0])]

        public void FilterArrayByKey_WithPossitivePowers_ExpectedResults(int[] array, int[] expected)
        {
            Assert.AreEqual(expected, FilterArrayByKey(array));
        }

        [Test]
        public void FilterArrayByKey_WithEmptyArray_ReturnsArgumentException() =>
           Assert.Throws<ArgumentException>(() => FilterArrayByKey(new int[0]),
               message: "Array cannot be empty!");   
    }
}