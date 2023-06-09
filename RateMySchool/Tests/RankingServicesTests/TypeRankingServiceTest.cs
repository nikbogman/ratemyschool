using Core.Interfaces.RepositoryInterfaces;
using Core.Services.StatisticServices;
using Core.Services;
using Core;
using Tests.MockRepositories;

namespace Tests.RankingServicesTests
{
    [TestFixture]
    public class TypeRankingServiceTest
    {
        private IReviewRepository _reviewRepository;

        [SetUp]
        public void SetUp()
        {
            _reviewRepository = new MockReviewRepository();
        }

        [Test]
        public void TestCalculateAndSetRanksIntoSchool()
        {
            float rating = 5;
            DummySchool school = new DummySchool(
                viewModel: new()
                {
                    Name = "Test1",
                    Number = 1,
                    City = "TestCity1"
                }
            );
            school.GenerateId();
            CompareByRatingInDescendingOrder comparer = new();
            TypeRankingService service = new(_reviewRepository, comparer);

            List<Statistic> statistics = new()
            {
                new Statistic(){ SchoolId = school.Id, AverageRating = rating },
            };
            service.CalculateAndSetRanks(school, statistics);
            Assert.That(school.Rank.ContainsKey("Overall"));
            Assert.IsNotNull(school.Rank["Overall"]);
            Assert.That(school.Rank.ContainsKey("Type"));
            Assert.IsNotNull(school.Rank["Type"]);
            Assert.AreEqual(school.Rating, rating);
        }
    }
}
