using Core.Entities.Schools;
using Core.Interfaces;
using Core.Structs;

namespace Core.Services.RankCalculators
{
    public class OverallRankCalculator : IRankCalculator
    {
        public SchoolStatistics Calculate(SchoolEntity school, IEnumerable<Rating> ratings)
        {
            int overallRank = 1;
            foreach (var rating in ratings)
            {
                if (rating.info.schoolId == school.Id)
                {
                    return new()
                    {
                        rating = rating.value,
                        ranks = new()
                        {
                            { "Overall", overallRank },
                        }
                    };
                }
                overallRank++;
            }
            return new()
            {
                rating = 0,
                ranks = new()
                {
                    { "Overall", 0 },
                }
            };
        }
    }
}
