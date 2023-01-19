using System;

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using RentalServicesWebApi.Models;
using System.IdentityModel.Tokens;
using System.Security.Claims;
using RentalServicesWebApi.Context;

namespace RentalServicesWebApi.Configuratioins
{
    public class UserClaimsPrincipalFactory : UserClaimsPrincipalFactory<ApplicationUser, ApplicationRole>
    {
        public new UserManager<ApplicationUser> UserManager;
        public new RoleManager<ApplicationRole> RoleManager;

        public UserClaimsPrincipalFactory(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager,
            IOptions<IdentityOptions> options) : base(userManager, roleManager, options)
        {
            UserManager = userManager;
            RoleManager = roleManager;
        }

        /// <summary>
        /// Creates a <see cref="T:System.Security.Claims.ClaimsPrincipal" /> from an user asynchronously.
        /// </summary>
        /// <param name="user">The user to create a <see cref="T:System.Security.Claims.ClaimsPrincipal" /> from.</param>
        /// <returns>The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous creation
        /// operation, containing the created <see cref="T:System.Security.Claims.ClaimsPrincipal" />.</returns>
        public override async Task<ClaimsPrincipal> CreateAsync(ApplicationUser user)
        {
            var principal = await base.CreateAsync(user);
            var identity = (ClaimsIdentity)principal.Identity;

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Role, "user"),
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(ClaimTypes.GivenName, user.FirstName),
                new Claim(ClaimTypes.Surname, user.LastName),
                new Claim(ClaimTypes.NameIdentifier, user.UserName)
                
                

            };

            identity.AddClaims(claims);
            return principal;
        }

        /// <summary>Generate the claims for a user.</summary>
        /// <param name="user">The user to create a <see cref="T:System.Security.Claims.ClaimsIdentity" /> from.</param>
        /// <returns>The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous creation operation, containing the created <see cref="T:System.Security.Claims.ClaimsIdentity" />.</returns>
        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(ApplicationUser user)
        {
            try
            {
                var userId = await UserManager.GetUserIdAsync(user);
                var userNameAsync = await UserManager.GetUserNameAsync(user);
                var id = new ClaimsIdentity("Identity.Application",
                    this.Options.ClaimsIdentity.UserNameClaimType, this.Options.ClaimsIdentity.RoleClaimType);
                id.AddClaim(new Claim(this.Options.ClaimsIdentity.UserIdClaimType, userId));
                id.AddClaim(new Claim(this.Options.ClaimsIdentity.UserNameClaimType, userNameAsync));
                
                ClaimsIdentity claimsIdentity;
                if (this.UserManager.SupportsUserSecurityStamp)
                {
                    claimsIdentity = id;
                    string type = this.Options.ClaimsIdentity.SecurityStampClaimType;
                    claimsIdentity.AddClaim(new Claim(type, await this.UserManager.GetSecurityStampAsync(user)));
                    claimsIdentity = (ClaimsIdentity)null;
                    type = (string)null;
                }
                if (this.UserManager.SupportsUserClaim)
                {
                    claimsIdentity = id;
                    claimsIdentity.AddClaims((IEnumerable<Claim>)await this.UserManager.GetClaimsAsync(user));
                    claimsIdentity = (ClaimsIdentity)null;
                }
                return id;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return new ClaimsIdentity();
            }
        }
    }
}

