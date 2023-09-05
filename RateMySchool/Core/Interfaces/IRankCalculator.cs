using Core.Entities.Schools;
using Core.Structs;

namespace Core.Interfaces
{
    public interface IRankCalculator
    {
        public SchoolStatistics Calculate(SchoolEntity school, IEnumerable<Rating> statistics);
    }
}
