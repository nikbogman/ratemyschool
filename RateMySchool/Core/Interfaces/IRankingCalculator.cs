using Core.Entities.SchoolEntities;

namespace Core.Interfaces
{
    public interface IRankingCalculator
    {
        public SchoolStatistic Calculate(BaseSchoolEntity school, IEnumerable<RatingStatistic> statistics);
    }
}
