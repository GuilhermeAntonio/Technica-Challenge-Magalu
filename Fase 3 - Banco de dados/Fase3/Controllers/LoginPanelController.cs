using Fase3.Models;
using Fase3.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Reflection;


namespace Fase3.Controllers
{
    public class LoginPanelController : Controller
    {
        private readonly IAuthenticationUserService _authenticationUserService;

        public LoginPanelController(IAuthenticationUserService authenticationUser)
        {
            _authenticationUserService = authenticationUser;

        }

        public IActionResult Index()
        {
            return _authenticationUserService.authenticating(HttpContext.Session.GetString("userName"), HttpContext.Session.GetString("password")) ? RedirectToAction("Index", "UserPanel") : View("Index");
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View("Index");

        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {

            if (_authenticationUserService.authenticating(username, password))
            {

                _authenticationUserService.saveAuthentication(HttpContext, username, password);

                return RedirectToAction("Index", "UserPanel"); 

            }

            ViewData["flag-error"] = "";

            return View("Index");
        }

    }
}