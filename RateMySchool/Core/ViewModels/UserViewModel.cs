using Core.Enums;
using Core.Interfaces;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Core.ViewModels
{
    public class UserViewModel: IViewModel
    {
        [Required(ErrorMessage = "Password of user shoud be provided for creation")]
        [MinLength(8)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Email of user shoud be provided for creation")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Birth year of user shoud be provided for creation")]
        [Range(1923, 2023, ErrorMessage = "Birth year not in the expected range")]
        public int BirthYear { get; set; }
    }
}
