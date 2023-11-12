using Fase3.Services;
using Microsoft.AspNetCore.Mvc;

namespace Fase3.Controllers
{
    public class UserPanelController : Controller
    {
        private readonly IAuthenticationUserService _authenticationUserService;

        public UserPanelController(IAuthenticationUserService authenticationUser)
        {
            _authenticationUserService = authenticationUser;

        }

        public IActionResult Index()
        {
            return _authenticationUserService.authenticating(HttpContext.Session.GetString("userName"), HttpContext.Session.GetString("password")) ? View() : RedirectToAction("Index", "LoginPanel");
        }

        public IActionResult Logout()
        {

            _authenticationUserService.clearAuthentication(HttpContext);

            return RedirectToAction("Index", "LoginPanel");
        }

    }
}
