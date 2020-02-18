
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Web.Models.Security
{
    public static class CustomClaimTypes
    {
        public const string TipoAcceso = "http://core.cl/identidad/claims/dominio/acceso"; 
        public const string UsuarioNombres = "http://core.cl/identidad/claims/dominio/usuario/nombres"; 
        public const string UsuarioCorreo = "http://core.cl/identidad/claims/dominio/usuario/correo"; 
        
    }
}
