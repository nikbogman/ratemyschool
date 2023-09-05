using Core.Enums.Schools;
using Core.Models.Schools;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace Core.Entities.Schools
{
    [Table("science_school")]
    public class ScienceSchoolEntity : SchoolEntity
    {
        [Column("study")]
        public string Study { get; private set; }

        [Column("entry_assessment")]
        public bool EntryAssessment { get; private set; }

        [Column("score_requirement")]
        public int? ScoreRequirement { get; private set; }

        public ScienceSchoolEntity(DataRow row) : base(row)
        {
            Study = (string)row["study"];
            EntryAssessment = (bool)row["entry_assessment"];
            ScoreRequirement = row["score_requirement"] == DBNull.Value ? null : (int?)row["score_requirement"];
        }

        public ScienceSchoolEntity(ScienceSchoolModel model) : base(model)
        {
            Study = model.Study;
            EntryAssessment = model.EntryAssessment;
            ScoreRequirement = model.ScoreRequirement;
            CategoryType = SchoolCategoryType.Science;
        }
    }
}
