using Core.Entities;
using Core.Exceptions;
using Core.Interfaces.RepositoryInterfaces;
using Core.ViewModels;
using System.Data;
using System.Diagnostics;

namespace Core.Managers
{
    public class ReviewManager : BaseManager<ReviewEntity, ReviewViewModel>
    {
        public ReviewManager(IReviewRepository repository) : base(repository) { }

        protected override IReviewRepository Repository { get => (IReviewRepository)base.Repository; }

        public IEnumerable<ReviewEntity> GetAllBySchoolId(Guid schoolId)
        {
            return Repository.SelectAllBySchoolId(schoolId);
        }

        public void MarkAsRepoted(Guid schoolId)
        {
            if (!Repository.UpdateReportedStatus(schoolId))
            {
                throw new Exception("Marking review was unsuccessful");
            }
        }
    }
}