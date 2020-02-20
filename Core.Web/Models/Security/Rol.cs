using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Core.Web.Models.Security
{
    public class Rol : IdentityRole
    {

        public Organizacion Orzanizacion { get; set; }
        public Rol Padre { get; set; }
        public ICollection<Rol> Hijos { get; set; }
        public bool Activo { get; set; }
    }
}
