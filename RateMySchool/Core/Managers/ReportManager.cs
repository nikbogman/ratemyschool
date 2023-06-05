using Core.Entities;
using Core.Interfaces;
using Core.ViewModels;

namespace Core.Managers
{
    public class ReportManager
    {
        private readonly IReportRepository _repository;
        public ReportManager(IReportRepository repository) { _repository = repository; }
    }
}
