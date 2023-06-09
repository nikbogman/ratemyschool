using Core.Entities.SchoolEntities;
using Core.ViewModels.SchoolViewModels;
using System.Data;

namespace Tests
{
    public class DummyViewModel : BaseSchoolViewModel { }
    public class DummySchool : BaseSchoolEntity
    {
        public DummySchool(DataRow row) : base(row) { }
        public DummySchool(DummyViewModel viewModel) : base(viewModel) { Type = Core.Enums.SchoolType.Language; }
    }

}
