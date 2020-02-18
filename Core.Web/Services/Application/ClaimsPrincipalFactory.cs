using System.Security.Claims;
using System.Threading.Tasks;
using Galvarino.Web.Models.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Core.Web.Models.Security;

public class ClaimsPrincipalFactory : UserClaimsPrincipalFactory<Usuario, Rol>
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
        try
        {
            var identity = await base.GenerateClaimsAsync(user);
            identity.AddClaim(new Claim("Correo", user.Email ?? ""));
            identity.AddClaim(new Claim(CustomClaimTypes.TipoAcceso, "login"));
            return identity;
        }
        catch (System.Exception ex )
        {

            throw;
        }
       
    }

   
}