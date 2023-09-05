using Core.Entities;
using Core.Exceptions;
using Core.Interfaces.Repositories;
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
    public class LoginModel : PageModel
    {
        private readonly UserManager _manager;

        public LoginModel(IUserRepository repo) { _manager = new(repo); }


        [BindProperty]
        public LogInViewModel Credentials { get; set; }

        public string? Error { get; private set; }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                UserEntity user = _manager.GetOneWithCredentials(Credentials.Email, Credentials.Password);
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
            catch (Exception ex)
            {
                var path = ErrorHandler.GetPath(ex);
                if(path == string.Empty)
                {
                    Error = ex.Message;
                    return Page();
                }
                return RedirectToPage("/Errors/" + path);
            }

        }
    }
}
