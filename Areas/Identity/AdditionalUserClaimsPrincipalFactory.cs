using flytt2021.Data.Database;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace flytt2021.Areas.Identity
{
    public class AdditionalUserClaimsPrincipalFactory : UserClaimsPrincipalFactory<FlyttUser, IdentityRole>
    {
        public AdditionalUserClaimsPrincipalFactory(UserManager<FlyttUser> userManager, RoleManager<IdentityRole> roleManager, IOptions<IdentityOptions> options) : base(userManager, roleManager, options)
        {
        }

		public async override Task<ClaimsPrincipal> CreateAsync(FlyttUser user)
		{
			var principal = await base.CreateAsync(user);
			var identity = (ClaimsIdentity)principal.Identity;

			var claims = new List<Claim>();

			claims.Add(new Claim("moveid", user.MoveId.ToString()));
			
			identity.AddClaims(claims);
			return principal;
		}
	}
}
