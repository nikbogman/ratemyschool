using DAL.Repositories;
using Core.Managers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Core.ViewModels;
using Core.Exceptions;

namespace WebApp.Pages.Auth
{
    public class RegisterModel : PageModel
    {
        [BindProperty]
        public UserViewModel UserViewModel { get; set; }

        private UserManager _manager = new UserManager(
            repository: new UserRepository("Server=localhost;Uid=root;Database=ratemyschool;Pwd=rootpass")
        );

        public string? Error { get; private set; }

        public IActionResult OnPost()
        {
            try
            {
                _manager.CreateOne(UserViewModel);
                return RedirectToPage("/Auth/Login");
            }
            catch (InputValidationException ex)
            {
                ModelState.AddModelError("UserViewModel.Password", ex.Message);
                return Page();
            }
        }
    }
}
