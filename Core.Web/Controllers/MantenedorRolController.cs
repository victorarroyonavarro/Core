using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Web.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core.Web.Controllers
{
    [Route("configuraciones/roles")]
    [Authorize]
    public class MantenedorRolController : Controller
    {
        private readonly ApplicationDbContext _context;
        public MantenedorRolController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Route("")]
        public IActionResult Listado()
        {
            var rols = _context.Roles.ToList();
            ViewBag.rolesList = rols;
            return View();
        }
    }
}