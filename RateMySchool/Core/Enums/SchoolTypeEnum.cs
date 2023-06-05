using System.ComponentModel.DataAnnotations;

namespace Core.Enums
{
    public enum SchoolType
    {
        [Display(Name = "language")]
        Language = 1,
        [Display(Name = "stem")]
        STEM = 2,
        [Display(Name = "specialized")]
        Specialized = 3
    }
}
