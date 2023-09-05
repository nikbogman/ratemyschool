using Core.Interfaces.RepositoryInterfaces;
using Core.Services;
using Core.Entities.Schools;
using Core.Services.RankCalculators;
using Core.Structs;

namespace Tests.RankingCalculatorTests
{
    [TestFixture]
    public class TypeRankingCalculatorTest
    {
        private InCategoryRankCalculator _calculator;

        [SetUp]
        public void SetUp() { _calculator = new(); }

        [Test]
        public void TestRankCalculator_ReturnsCalculationResult_Success()
        {
            SchoolEntity school = new SchoolEntity(
                viewModel: new()
                {
                    Name = "Test1",
                    Number = 1,
                    City = "TestCity1"
                }
            );
            school.GenerateId();
            List<Rating> statistics = new()
            {
                new Rating(){ SchoolId = school.Id, SchoolType = school.Type, AverageRating = 5},
            };
            var result = _calculator.Calculate(school, statistics);
            Assert.That(result.Rank.ContainsKey("Overall"));
            Assert.That(result.Rank.ContainsKey("Type"));
            Assert.AreEqual(result.Rank["Overall"], 1);
            Assert.AreEqual(result.Rank["Type"], 1);
            Assert.AreEqual(result.Rating, 5);
        }

        [Test]
        public void TestRankCalculator_ReturnsCalculationResult_Failuire()
        {
            SchoolEntity school = new SchoolEntity(
                viewModel: new()
                {
                    Name = "Test1",
                    Number = 1,
                    City = "TestCity1"
                }
            );
            school.GenerateId();
            List<Rating> statistics = new() { };
            var result = _calculator.Calculate(school, statistics);
            Assert.That(result.Rank.ContainsKey("Overall"));
            Assert.That(result.Rank.ContainsKey("Type"));
            Assert.AreEqual(result.Rank["Overall"], 0);
            Assert.AreEqual(result.Rank["Type"], 0);
            Assert.AreEqual(result.Rating, 0);
        }
    }
}
