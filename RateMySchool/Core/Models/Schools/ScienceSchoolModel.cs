using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Core.Models.Schools
{
    public class ScienceSchoolModel : SchoolModel
    {
        [Required(ErrorMessage = "Study language property is required")]
        public string Study { get; set; }

        [DefaultValue(null)]
        public int? ScoreRequirement { get; set; }

        [DefaultValue(false)]
        public bool EntryAssessment { get; set; }
    }
}
