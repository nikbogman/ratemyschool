using System.ComponentModel.DataAnnotations;

namespace Core.Enums
{
    public enum UserRole
    {
        [Display(Name = "moderator")]
        Moderator = 1,
        [Display(Name = "standard")]
        Standard = 2
    }
}
