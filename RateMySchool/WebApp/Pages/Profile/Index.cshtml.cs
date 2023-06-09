using Core.Entities;
using Core.Exceptions;
using Core.Interfaces.RepositoryInterfaces;
using Core.Managers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;
using System.Security.Claims;

namespace WebApp.Pages.Profile
{
    public class IndexModel : PageModel
    {
        private readonly UserManager _manager;

        public IndexModel(IUserRepository repo) { _manager = new(repo); }

        public UserEntity UserData { get; set; }

        public IActionResult OnGet()
        {
            try
            {
                if (User.Identity == null || User.Identity.IsAuthenticated == false)
                {
                    throw new UnauthorizedException();
                }
                string? idClaim = User.FindFirstValue("id");
                if (idClaim == null)
                {
                    throw new UnauthorizedException();
                }
                Guid userId = Guid.Parse(idClaim);
                UserData = _manager.GetOneById(userId);
                return Page();
            }
            catch (Exception ex)
            {
                return RedirectToPage("/Errors/" + ErrorHandler.GetPath(ex));
            }
        }

        public IActionResult OnPost()
        {
            try
            {
                if (User.Identity == null || User.Identity.IsAuthenticated == false)
                {
                    throw new UnauthorizedException();
                }
                string? idClaim = User.FindFirstValue("id");
                if (idClaim == null)
                {
                    throw new UnauthorizedException();
                }
                Guid userId = Guid.Parse(idClaim);
                _manager.DeleteOne(userId);
                return RedirectToPage("/Index");
            }
            catch (Exception ex)
            {
                return RedirectToPage("/Errors/" + ErrorHandler.GetPath(ex));
            }
        }
    }
}
