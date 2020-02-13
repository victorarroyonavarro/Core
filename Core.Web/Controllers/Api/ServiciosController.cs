using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Core.Web.Data.Repository;

namespace Core.Web.Controllers.Api
{
    [Route("api")]
    [ApiController]
    
    public class ServiciosController : ControllerBase
    {
               
        private readonly ISolicitudRepository _solicitudRepository;
        public ServiciosController( ISolicitudRepository solicitudRepo)
        {
          
            _solicitudRepository = solicitudRepo;
        }

        [HttpGet("listar-sucursales")]
        public IActionResult listar([FromQuery] int offset = 0, [FromQuery] int limit = 20)
        {
            var salida = _solicitudRepository.listar_sucursal();
            var lida = new
            {
                total = salida.Count(),
                rows = salida.Count() < offset ? salida : salida.Skip(offset).Take(limit).ToList()
            };
            return Ok(lida);
        }


        [HttpPost("insertar-direccion/{direccion}/{latitud}/{longitud}")]
        public IActionResult Insertar([FromQuery] string  direccion, [FromQuery] string latitud, [FromQuery] string longitud)
        {
             _solicitudRepository.Insertardireccion(direccion, latitud, longitud);
            
            return Ok();
        }




    }
}
    