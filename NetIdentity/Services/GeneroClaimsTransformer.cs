using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using NetIdentity.Models;

namespace NetIdentity.Services
{
    public class GeneroClaimsTransformer : IClaimsTransformation
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public GeneroClaimsTransformer(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            var identity = principal.Identity as ClaimsIdentity;
            if (identity == null) return principal;

            // If the genero claim is already present, do nothing
            if (identity.HasClaim(c => c.Type == "genero"))
                return principal;

            var user = await _userManager.GetUserAsync(principal);
            if (user != null && !string.IsNullOrWhiteSpace(user.genero))
            {
                identity.AddClaim(new Claim("genero", user.genero));
            }
            return principal;
        }
    }
}
