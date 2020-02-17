using Core.Web.Models.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.Options;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Core.Web.Services
{
    public class ClaimsPrincipalFactory : UserClaimsPrincipalFactory<Usuario,Rol>
    {

        public ClaimsPrincipalFactory(
            UserManager<Usuario> userManager,
            RoleManager<Rol> roleManager,
            IOptions<IdentityOptions> optionsAccessor)
            : base(userManager, roleManager, optionsAccessor)
        {
            
        }


        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(Usuario user)
        {
            //user = await UserManager.Users.Include(usr => usr.Oficina).FirstOrDefaultAsync(d => d.Id == user.Id);
            var identity = await base.GenerateClaimsAsync(user);
            //identity.AddClaim(new Claim("Oficina", user.Oficina != null ? user.Oficina.Codificacion : ""));
            //identity.AddClaim(new Claim("Nombres", user.Nombres ?? ""));
            identity.AddClaim(new Claim("Correo", user.Email ?? ""));
           // identity.AddClaim(new Claim(CustomClaimTypes.TipoAcceso, "login"));
            return identity;
        }



    }
}
