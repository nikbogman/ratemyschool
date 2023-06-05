using Core.Enums;
using Core.ViewModels.SchoolViewModels;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace Core.Entities.SchoolEntities
{
    [Table("stem_school")]
    public class STEMSchoolEntity : BaseSchoolEntity
    {
        [Column("study")]
        public string Study { get; private set; }

        [Column("entry_assessment")]
        public bool EntryAssessment { get; private set; }

        [Column("score_requirement")]
        public int? ScoreRequirement { get; private set; }

        public STEMSchoolEntity(DataRow row) : base(row)
        {
            Study = (string)row["study"];
            EntryAssessment = (bool)row["entry_assessment"];
            ScoreRequirement = row["score_requirement"] == DBNull.Value ? null : (int?)row["score_requirement"];
        }

        public STEMSchoolEntity(STEMSchoolViewModel viewModel) : base(viewModel)
        {
            Study = viewModel.Study;
            EntryAssessment = viewModel.EntryAssessment;
            ScoreRequirement = viewModel.ScoreRequirement;
            Type = SchoolType.STEM;
        }
    }
}
