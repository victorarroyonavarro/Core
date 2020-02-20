using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Web.Data;
using Core.Web.Models.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Core.Web.Controllers
{
    [Route("configuraciones/usuarios")]
    [Authorize]
    public class MantenedorUsuarioController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly UserManager<Usuario> _userManager;
        private readonly RoleManager<Rol> _roleManager;
        public MantenedorUsuarioController(ApplicationDbContext context,
                                            RoleManager<Rol> roleManager,
                                            UserManager<Usuario> userManager)
        {
            _context = context;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        [Route("")]
        public IActionResult Listado()
        {
            ViewBag.usuariosList = _context.Users.ToList();
            return View();
        }


        [Route("formulario/{id?}")]
        public async Task<IActionResult> Formulario(string id = "")
        {

            ViewBag.editando = !String.IsNullOrEmpty(id);
            
            if (ViewBag.editando)
            {
                var user = await _context.Users.FindAsync(id);
                ViewBag.rolUsuario = await _userManager.GetRolesAsync(user);
                ViewBag.usuario = user;
            }

            return View();
        }




    }
}