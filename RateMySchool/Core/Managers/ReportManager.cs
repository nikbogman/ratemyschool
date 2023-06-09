using Core.Entities;
using Core.Interfaces.RepositoryInterfaces;
using Core.ViewModels;

namespace Core.Managers
{
    public class ReportManager : BaseManager<ReportEntity, ReportViewModel>
    {
        public ReportManager(IRepository<ReportEntity> repository): base(repository) {  }
    }
}
