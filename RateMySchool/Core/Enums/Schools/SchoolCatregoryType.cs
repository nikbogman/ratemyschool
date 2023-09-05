using System.ComponentModel.DataAnnotations;

namespace Core.Enums.Schools
{
    public enum SchoolCategoryType
    {
        [Display(Name = "language")]
        Language = 1,
        [Display(Name = "science")]
        Science = 2,
    }
}
