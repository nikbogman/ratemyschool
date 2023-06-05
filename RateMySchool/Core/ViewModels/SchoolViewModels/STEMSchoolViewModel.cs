using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ViewModels.SchoolViewModels
{
    public class STEMSchoolViewModel : BaseSchoolViewModel
    {
        [Required(ErrorMessage = "Study language property is required")]
        public string Study { get; set; }

        [DefaultValue(null)]
        public int? ScoreRequirement { get; set; }

        [DefaultValue(false)]
        public bool EntryAssessment { get; set; }
    }
}
