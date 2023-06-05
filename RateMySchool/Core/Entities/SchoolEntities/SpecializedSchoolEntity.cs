using Core.Enums;
using Core.ViewModels.SchoolViewModels;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace Core.Entities.SchoolEntities
{
    [Table("specialized_school")]
    public class SpecializedSchoolEntity : BaseSchoolEntity
    {
        [Column("specialization")]
        public string Specialization { get; private set; }

        [Column("assessment")]
        public string? Assessment { get; private set; }


        public SpecializedSchoolEntity(DataRow row) : base(row)
        {
            Specialization = (string)row["specialization"];
            Assessment = (string)row["assessment"];
        }

        public SpecializedSchoolEntity(SpecializedSchoolViewModel viewModel) : base(viewModel)
        {
            Specialization = viewModel.Specialization;
            Assessment = viewModel.Assessment;
            Type = SchoolType.Specialized;
        }
    }
}
