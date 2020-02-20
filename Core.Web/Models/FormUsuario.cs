using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Web.Models
{
         public class FormUsuario
        {
            public string Nombres { get; set; }
            public string Identificacion { get; set; }
       
        [EmailAddress(ErrorMessage ="ibalid email")]
        [Required(ErrorMessage ="debe ingerssar email")]
        [BindProperty]
        public string Correo { get; set; }
            public string Llave { get; set; }
            public string TipoUsuario { get; set; }
            public IEnumerable<string> Rol { get; set; }
            public string Telefono { get; set; }
        }
 
}
