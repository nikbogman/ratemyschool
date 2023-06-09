using DAL.Repositories;
using Core.Managers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Core.ViewModels;
using Core.Exceptions;
using Google.Protobuf.Collections;
using System.Xml;
using Mysqlx;
using Core.Interfaces.RepositoryInterfaces;

namespace WebApp.Pages.Auth
{
    public class RegisterModel : PageModel
    {
        private readonly UserManager _manager;

        [BindProperty]
        public UserViewModel UserViewModel { get; set; }


        public RegisterModel(IUserRepository repo) { _manager = new(repo); }

        public IActionResult OnPost()
        {
            try
            {
                _manager.CreateOne(UserViewModel);
                return RedirectToPage("/Auth/Login");
            }
            catch (Exception ex)
            {
                var path = ErrorHandler.GetPath(ex);
                if (path == string.Empty)
                {
                    if (ex.Message == "Provided email is not unique. User with this email alredy exists.")
                    {
                        ModelState.AddModelError("UserViewModel.Email", ex.Message);
                    }
                    else
                    {
                        ModelState.AddModelError("UserViewModel.Password", ex.Message);
                    }
                    return Page();
                }
                return RedirectToPage("/Errors/" + path);
            }
        }
    }
}
