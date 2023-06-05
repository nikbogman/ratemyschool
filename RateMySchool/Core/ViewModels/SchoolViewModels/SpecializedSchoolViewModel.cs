using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Core.ViewModels.SchoolViewModels
{
    public class SpecializedSchoolViewModel : BaseSchoolViewModel
    {
        [Required(ErrorMessage = "Specialization property is required")]
        public string Specialization { get; set; }

        [DefaultValue(null)]
        public string? Assessment { get; set; }
    }
}
