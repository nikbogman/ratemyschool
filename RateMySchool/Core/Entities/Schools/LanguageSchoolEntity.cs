using Core.Enums.Schools;
using Core.Models.Schools;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace Core.Entities.Schools
{
    [Table("language_school")]
    public class LanguageSchoolEntity : SchoolEntity
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

        public LanguageSchoolEntity(LanguageSchoolModel model) : base(model)
        {
            PrimaryLanguage = model.PrimaryLanguage;
            SecondaryLanguage = model.SecondaryLanguage;
            ScoreRequirement = model.ScoreRequirement;
            CategoryType = SchoolCategoryType.Language;
        }

    }
}
