using Core.Entities;
using Core.Interfaces;
using Core.ViewModels;

namespace Core.Managers
{
    public class ReportManager: BaseManager<ReportEntity, ReportViewModel>
    {
        public ReportManager(IReportRepository repository): base(repository) {  }
    }
}
