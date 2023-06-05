using Core.Enums;
using Core.ViewModels.SchoolViewModels;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace Core.Entities.SchoolEntities
{
    [Table("language_school")]
    public class LanguageSchoolEntity : BaseSchoolEntity
    {
        [Column("primary_language")]
        public string PrimaryLanguage { get; private set; }

        [Column("secondary_language")]
        public string SecondaryLanguage { get; private set; }

        [Column("score_requirement")]
        public int? ScoreRequirement { get; private set; }

        public LanguageSchoolEntity(DataRow row) : base(row)
        {
            PrimaryLanguage = (string)row["primary_language"];
            SecondaryLanguage = (string)row["secondary_language"];
            ScoreRequirement = row["score_requirement"] == DBNull.Value ? null : (int?)row["score_requirement"];
        }

        public LanguageSchoolEntity(LanguageSchoolViewModel viewModel) : base(viewModel)
        {
            PrimaryLanguage = viewModel.PrimaryLanguage;
            SecondaryLanguage = viewModel.SecondaryLanguage;
            ScoreRequirement = viewModel.ScoreRequirement;
            Type = SchoolType.Language;
        }

    }
}
