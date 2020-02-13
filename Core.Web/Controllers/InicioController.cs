using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Core.Web.Controllers.Api
{
    [Route("paginas")]
    public class InicioController : Controller
    {
        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}