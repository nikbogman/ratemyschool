using Core.Entities.SchoolEntities;
using Core.Interfaces;

namespace Core.Services.StatisticServices
{
    public class BaseRankingCalculator : IRankingCalculator
    {
        public SchoolStatistic Calculate(BaseSchoolEntity school, IEnumerable<RatingStatistic> statistics)
        {
            int overAllRank = 1;
            foreach (var statistic in statistics)
            {
                if (statistic.SchoolId == school.Id)
                {
                    return new SchoolStatistic()
                    {
                        Rating = statistic.AverageRating,
                        Rank = new Dictionary<string, int>() {
                         { "Overall", overAllRank},
                    }
                    };
                }
                overAllRank++;
            }
            return new SchoolStatistic()
            {
                Rating = 0,
                Rank = new Dictionary<string, int>() {
                { "Overall", 0},
            }
            };
        }
    }
}
