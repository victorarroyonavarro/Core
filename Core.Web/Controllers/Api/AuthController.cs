using Core.Web.Data;
using Core.Web.Models.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace Core.Web.Controllers.Api
{
    [Route("api/auth")]
    [ApiController]

    public class AuthController : Controller
    {
        private readonly UserManager<Usuario> _userManager;
        private readonly SignInManager<Usuario> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly RoleManager<Rol> _roleManager;
        private readonly ApplicationDbContext _context;

        public AuthController(
            UserManager<Usuario> userManager,
            SignInManager<Usuario> signInManager,
            RoleManager<Rol> roleManager,
            ApplicationDbContext context,
            IConfiguration configuration
        )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _roleManager = roleManager;
            _context = context;
        }

        [HttpPost]
        [Route("ingreso-usuario")]
        public async  Task<IActionResult> IngresoUsuario([FromBody] Usuario usuario)
        {


            if (ModelState.IsValid)
            {
                
                    var user = await _signInManager.UserManager.FindByEmailAsync(usuario.Email);

                    var result = await _signInManager.PasswordSignInAsync("1-9", "Victor.2020", isPersistent: true, lockoutOnFailure: false);

                    //if (result.Succeeded)
                    //{
                    await _signInManager.SignInAsync(user, true);

                    return Ok();
                    //}
                    //else
                    //{
                    //    ModelState.AddModelError(string.Empty, "Datos de Acceso Invalidos.");
                    //    return BadRequest(ModelState);
                    //}

               


            }
            else
            {
                return BadRequest(ModelState);
            }


        }
    }
}