using Core;
using Core.Services;

namespace Tests.ComparerTests
{
    [TestFixture]
    public class CompareByRatingInAescendingOrderTests
    {
        private readonly CompareByRatingInAescendingOrder comparer = new();

        [Test]
        public void TestCompare_SmallerElement_ReturnsNegative()
        {
            var element1 = new RatingStatistic() { AverageRating = 1 };
            var element2 = new RatingStatistic() { AverageRating = 5 };
            var result = comparer.Compare(element1, element2);
            Assert.That(result, Is.LessThan(0), "The Compare method should return a negative value when the first element is smaller.");
        }

        [Test]
        public void TestCompare_GreaterElement_ReturnsPositive()
        {
            var element1 = new RatingStatistic() { AverageRating = 5 };
            var element2 = new RatingStatistic() { AverageRating = 1 };
            var result = comparer.Compare(element1, element2);
            Assert.That(result, Is.GreaterThan(0), "The Compare method should return a positive value when the first element is greater.");
        }

        [Test]
        public void TestCompare_EqualElements_ReturnsZero()
        {
            var element1 = new RatingStatistic() { AverageRating = 3 };
            var element2 = new RatingStatistic() { AverageRating = 3 };
            var result = comparer.Compare(element1, element2);
            Assert.That(result, Is.EqualTo(0), "The Compare method should return zero when the elements are equal.");
        }

        [Test]
        public void TestCompare_FirstNullElement_ReturnsNegative()
        {
            var element2 = new RatingStatistic() { AverageRating = 5 };
            var result = comparer.Compare(null, element2);
            Assert.That(result, Is.LessThan(0), "The Compare method should return a negative value when the first element is smaller.");
        }

        [Test]
        public void TestCompare_SecondNullElement_ReturnsPositive()
        {
            var element1 = new RatingStatistic() { AverageRating = 5 };
            var result = comparer.Compare(element1, null);
            Assert.That(result, Is.GreaterThan(0), "The Compare method should return a positive value when the first element is greater.");
        }

        [Test]
        public void TestCompare_BothNullElements_ReturnsZero()
        {
            var result = comparer.Compare(null, null);
            Assert.That(result, Is.EqualTo(0), "The Compare method should return zero when the elements are equal.");
        }
    }
}
