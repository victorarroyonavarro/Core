using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Core.Web.Models.Security
{
    public class Usuario : IdentityUser
    {

        
        public string Identificador { get; set; }
        public string Nombres { get; set; }
        //public string Id { get; set; }
        //public string Rut { get; set; }
        //public string nombre { get; set; }
        //public string apellido { get; set; }
        //public string contrasenia { get; set; }
       
        //public Perfil Perfil { get; set; }
        //public string TokenRecuerdaAcceso { get; set; }
        //public bool estado { get; set; }
    }
}