using Core.Web.Models;
using Core.Web.Models.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Core.Web.Controllers
{
    public class LoginController : Controller
    {


        private readonly SignInManager<Usuario> _signInManager;
        private readonly IConfiguration _configuration;

        public LoginController(SignInManager<Usuario> signInManager, IConfiguration configuration)
        {
            _signInManager = signInManager;
            _configuration = configuration;
        }


        [Route("Login")]
        public IActionResult Login()
        {
            return View();
        }
        [Route("Login2")]
        public IActionResult Login2()
        {
            return View();
        }

        [Route("SinPermiso")]
        public IActionResult SinPermiso()
        {
            return View();
        }


       

        public async Task<IActionResult> SignIn(string email)
        {
            try
            {
                var user = await _signInManager.UserManager.FindByEmailAsync(email);

                await _signInManager.SignInAsync(user, true);


                return Redirect("/wf/v1/mis-solicitudes");
            }
            catch (Exception)
            {
                return View();
            }
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}