using Core.Entities.SchoolEntities;
using Core.Interfaces;

namespace Core.Services.StatisticServices
{
    public class TypeRankingCalculator : IRankingCalculator
    {
        public SchoolStatistic Calculate(BaseSchoolEntity school, IEnumerable<RatingStatistic> statistics)
        {
            int overAllRank = 1;
            int typeRank = 1;
            foreach (var statistic in statistics)
            {
                if (statistic.SchoolId == school.Id)
                {
                    return new SchoolStatistic()
                    {
                        Rating = statistic.AverageRating,
                        Rank = new Dictionary<string, int>() {
                         { "Overall", overAllRank},
                         { "Type", typeRank}
                    }
                    };
                }
                if (statistic.SchoolType == school.Type)
                {
                    typeRank++;
                }
                overAllRank++;
            }
            return new SchoolStatistic()
            {
                Rating = 0,
                Rank = new Dictionary<string, int>() {
                { "Overall", 0},
                { "Type", 0}
            }
            };
        }
    }
}