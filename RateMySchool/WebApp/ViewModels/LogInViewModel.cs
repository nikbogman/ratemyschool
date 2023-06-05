using System.ComponentModel.DataAnnotations;

namespace WebApp.ViewModels
{
    public class LogInViewModel
    {
        [Required(ErrorMessage = "Email of user shoud be provided for email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password of user shoud be provided for login")]
        [MinLength(8)]
        public string Password { get; set; }
    }
}
