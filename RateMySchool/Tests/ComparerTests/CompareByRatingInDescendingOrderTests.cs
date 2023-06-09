using Core.Services;
using Core;

namespace Tests.ComparerTests
{
    [TestFixture]
    public class CompareByRatingInDescendingOrderTests
    {
        private readonly CompareByRatingInDescendingOrder comparer = new();
        [Test]
        public void TestCompare_SmallerElement_ReturnsPositive()
        {
            var element1 = new Statistic() { AverageRating = 1 };
            var element2 = new Statistic() { AverageRating = 5 };
            var result = comparer.Compare(element1, element2);
            Assert.That(result, Is.GreaterThan(0), "The Compare method should return a positive value when the first element is greater.");
        }

        [Test]
        public void TestCompare_GreaterElement_ReturnsNegative()
        {
            var element1 = new Statistic() { AverageRating = 5 };
            var element2 = new Statistic() { AverageRating = 1 };
            var result = comparer.Compare(element1, element2);
            Assert.That(result, Is.LessThan(0), "The Compare method should return a negative value when the first element is smaller.");
        }

        [Test]
        public void TestCompare_EqualElements_ReturnsZero()
        {
            var element1 = new Statistic() { AverageRating = 3 };
            var element2 = new Statistic() { AverageRating = 3 };
            var result = comparer.Compare(element1, element2);
            Assert.That(result, Is.EqualTo(0), "The Compare method should return zero when the elements are equal.");
        }

        [Test]
        public void TestCompare_FirstNullElement_ReturnsPositive()
        {
            var element2 = new Statistic() { AverageRating = 5 };
            var result = comparer.Compare(null, element2);
            Assert.That(result, Is.GreaterThan(0), "The Compare method should return a positive value when the first element is greater.");
        }

        [Test]
        public void TestCompare_SecondNullElement_ReturnsNegative()
        {
            var element1 = new Statistic() { AverageRating = 5 };
            var result = comparer.Compare(element1, null);
            Assert.That(result, Is.LessThan(0), "The Compare method should return a negative value when the first element is smaller.");
        }

        [Test]
        public void TestCompare_BothNullElements_ReturnsZero()
        {
            var result = comparer.Compare(null, null);
            Assert.That(result, Is.EqualTo(0), "The Compare method should return zero when the elements are equal.");
        }


    }
}
