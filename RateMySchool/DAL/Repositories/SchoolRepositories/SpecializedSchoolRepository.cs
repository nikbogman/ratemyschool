using Core.Entities.SchoolEntities;
using Core.Interfaces;

namespace DAL.Repositories.SchoolRepositories
{
    public class SpecializedSchoolRepository : AbstractSchoolRepository<SpecializedSchoolEntity>, ISpecializedSchoolRepository
    {
        public SpecializedSchoolRepository(string connectionString) : base(connectionString) { }
    }
}
