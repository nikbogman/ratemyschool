using Core.Entities.SchoolEntities;
using Core.Interfaces.RepositoryInterfaces;
using Core.ViewModels.SchoolViewModels;
using Core.FeatureManagers;

namespace Core.Managers.SchoolManagers
{
    public class STEMSchoolManager : BaseManager<STEMSchoolEntity, STEMSchoolViewModel>
    {
        public STEMSchoolManager(IRepository<STEMSchoolEntity> repository) : base(repository) { }
    }
}
