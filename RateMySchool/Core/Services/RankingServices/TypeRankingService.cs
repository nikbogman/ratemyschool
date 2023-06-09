using Core.Entities.SchoolEntities;
using Core.Interfaces.RepositoryInterfaces;

namespace Core.Services.StatisticServices
{
    public class TypeRankingService : BaseRankingService
    {
        public TypeRankingService(IReviewRepository repository, IComparer<Statistic> comparer) : base(repository, comparer) { }

        public override void CalculateAndSetRanks(BaseSchoolEntity school, IEnumerable<Statistic> statistics)
        {
            int overAllRank = 1;
            int typeRank = 1;
            foreach (var statistic in statistics)
            {
                if (statistic.SchoolId == school.Id)
                {
                    school.Rating = statistic.AverageRating;
                    school.Rank = new()
                    {
                        { "Overall", overAllRank },
                        { "Type", typeRank }
                    };
                    break;
                }
                if (statistic.SchoolType == school.Type)
                {
                    typeRank++;
                }
                overAllRank++;
            }
        }
    }
}
