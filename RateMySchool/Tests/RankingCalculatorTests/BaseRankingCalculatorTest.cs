using Core;
using Core.Entities.SchoolEntities;
using Core.Services.StatisticServices;
using Core.ViewModels.SchoolViewModels;

namespace Tests.RankingServicesTests
{
    [TestFixture]
    public class BaseRankingCalculatorTest
    {
        private BaseRankingCalculator _calculator;

        [SetUp]
        public void SetUp() { _calculator = new(); }

        [Test]
        public void TestRankCalculator_ReturnsCalculationResult_Success()
        {
            BaseSchoolEntity school = new BaseSchoolEntity(
                viewModel: new()
                {
                    Name = "Test1",
                    Number = 1,
                    City = "TestCity1"
                }
            );
            school.GenerateId();
            List<RatingStatistic> statistics = new()
            {
                new RatingStatistic(){ SchoolId = school.Id, AverageRating = 5},
            };
            var result = _calculator.Calculate(school, statistics);
            Assert.That(result.Rank.ContainsKey("Overall"));
            Assert.AreEqual(result.Rank["Overall"], 1);
            Assert.AreEqual(result.Rating, 5);
        }

        [Test]
        public void TestRankCalculator_ReturnsCalculationResult_Failuire()
        {
            BaseSchoolEntity school = new BaseSchoolEntity(
                viewModel: new()
                {
                    Name = "Test1",
                    Number = 1,
                    City = "TestCity1"
                }
            );
            school.GenerateId();
            List<RatingStatistic> statistics = new(){};
            var result = _calculator.Calculate(school, statistics);
            Assert.That(result.Rank.ContainsKey("Overall"));
            Assert.AreEqual(result.Rank["Overall"], 0);
            Assert.AreEqual(result.Rating, 0);
        }
    }
}
