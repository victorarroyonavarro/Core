using System.Security.Claims;
using System.Threading.Tasks;
using Core.Web.Models.Security;
using Galvarino.Web.Models.Security;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

public class CustomClaimsTransformer : IClaimsTransformation
{
    private readonly UserManager<Usuario> _userManager;
    public CustomClaimsTransformer(UserManager<Usuario> userManager)
    {
        _userManager = userManager;
    }
    public async Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
    {
        var idt = ((ClaimsIdentity)principal.Identity);
        var rut = idt.Name;
        var user = await _userManager.Users.FirstOrDefaultAsync(d => d.Identificador == rut);
        if(user != null)
        {
            idt.AddClaim(new Claim(CustomClaimTypes.UsuarioNombres, user.Nombres));
            idt.AddClaim(new Claim(CustomClaimTypes.UsuarioCorreo, user.NormalizedEmail.ToLower()));
            
            var roles = await _userManager.GetRolesAsync(user);
            foreach (var rol in roles)
            {
                if(!idt.HasClaim(ClaimTypes.Role, rol))
                {
                    idt.AddClaim(new Claim(ClaimTypes.Role, rol));
                }
            }
            
        }

        return principal;
    }
}