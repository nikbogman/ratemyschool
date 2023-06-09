using Core.Entities.SchoolEntities;
using Core.Interfaces.RepositoryInterfaces;

namespace DAL.Repositories.SchoolRepositories
{
    public class LanguageSchoolRepository : AbstractSchoolRepository<LanguageSchoolEntity>, IRepository<LanguageSchoolEntity>
    {
        public LanguageSchoolRepository(string connectionString) : base(connectionString) { }
    }
}
