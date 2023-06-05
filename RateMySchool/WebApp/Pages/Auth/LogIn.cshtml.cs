using Core.Entities;
using Core.Exceptions;
using Core.Managers;
using DAL.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using WebApp.ViewModels;

namespace WebApp.Pages.Auth
{
    public class LogInModel : PageModel
    {
        [BindProperty]
        public LogInViewModel Credentials { get; set; }

        private UserManager _manager = new UserManager(
            repository: new UserRepository("Server=localhost;Uid=root;Database=ratemyschool;Pwd=rootpass")
        );

        public bool IsIncorrect { get; private set; } = false;

        public async Task<IActionResult> OnPostAsync()
        {
            var user = _manager.GetOneWithCredentials(Credentials.Email, Credentials.Password);
            if (user == null)
            {
                IsIncorrect = true;
                return Page();
            }
            List<Claim> claims = new()
                {
                    new Claim("id", user.Id.ToString())
                };
            await HttpContext.SignInAsync(
                new ClaimsPrincipal(
                    new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme)
                )
            );
            return RedirectToPage("/Index");
        }
    }
}
