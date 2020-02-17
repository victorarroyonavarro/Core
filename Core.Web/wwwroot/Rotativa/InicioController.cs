using Core.Web.Models;
using Core.Web.Models.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Core.Web.Controllers.Api
{

    public class InicioController : Controller
    {

        private readonly SignInManager<Usuario> _signInManager;
        private readonly IConfiguration _configuration;

        public InicioController(SignInManager<Usuario> signInManager, IConfiguration configuration)
        {
            _signInManager = signInManager;
            _configuration = configuration;
        }


        [Route("ingreso-usuario")]
        public async Task<IActionResult> SignIn([FromBody] dynamic entrada)
        {
            try
            {

                string email = entrada.email;
                string contrasenia = entrada.contrasenia;
                var user = await _signInManager.UserManager.FindByEmailAsync(email);


                await _signInManager.SignInAsync(user, true);
                //if(User.Identity.IsAuthenticated)
                //{
                return Redirect("/wf/v1/mis-solicitudes");
                //}
                //else
                //{
                //    return View("SinPermiso");
                //}

            }
            catch (Exception ex)
            {
                return View();
            }
        }
        public IActionResult SinPermiso()
        {
            return View();
        }

        [Route("Login")]
        public IActionResult Login()
        {
            return View();

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}