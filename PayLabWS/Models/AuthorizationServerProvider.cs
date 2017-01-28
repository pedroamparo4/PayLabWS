using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace PayLabWS.Models
{
    public class AuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            var PayLabAuth = new PayLabAuthentication();
            var claimsResult = PayLabAuth.Authenticate(context.UserName, context.Password);

            if(claimsResult != null)
            {
                identity.AddClaims(claimsResult);
                context.Validated(identity);
            }
            else
            {
                context.SetError("invalid grant", "Provider username and password is incorrect");
                return;
            }
        }

    }
}