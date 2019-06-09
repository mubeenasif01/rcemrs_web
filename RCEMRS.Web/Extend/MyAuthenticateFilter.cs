using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Filters;

namespace RCEMRS.Web.Extend
{
    public class MyAuthenticateFilter :Attribute,IAuthenticationFilter 
    {
        //Secretkey to create token 
        private const string SecretKey = "b3OIsj+BXE9NZDy0t8W3TcNe";
       
        //Support Token Schema Property
        public const string SupportTokenSchema = "Bearer";

        public bool AllowMultiple
        {
            get { return false; }
        }

        private readonly string _audience = "https://my.company.com";
        private readonly string _validIssuer = "http://my.tokenissuer.com";

        public bool SendChallenge { get; set; }


        public async Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
        {
            //Extract Creadential from the authorzation Request Header to Validate whether the request header is not null 
            //if null it will return false to calling party.
            var authicateHeader = context.Request.Headers.Authorization;
            if (authicateHeader == null)
                return;
            
            //Extract the Authentication Token Schema from request header and check whether it is bearer or not 
            var tokenSchema = authicateHeader.Scheme;
            if (!tokenSchema.Equals(SupportTokenSchema))
                return;

            //Given a valid token scheme and verify credentials are present
            var credentials = authicateHeader.Parameter;
            if (string.IsNullOrEmpty(credentials))
            {
                //no credential sent ,about out the request 
                context.ErrorResult = new  AuthenticationFailureResult("Missing Credentials",context.Request);
                return;
            }

            try
            {
                //validate the credential 
                IPrincipal principal = await ValidateCredentialsAsync(credentials, context.Request, cancellationToken);
                if (principal == null)
                {
                    //Invalid Credentials:abourt out the request 
                    context.ErrorResult = new AuthenticationFailureResult("Invalid Credentials", context.Request);
                }
                else
                {
                    //User Autheticated:save the principal into the request principal
                    context.Principal = principal;
                }
            }
            catch (Exception ex) when (ex is SecurityTokenInvalidLifetimeException ||
                                             ex is SecurityTokenExpiredException ||
                                             ex is SecurityTokenNoExpirationException ||
                                             ex is SecurityTokenNotYetValidException)
            {

                context.ErrorResult = new AuthenticationFailureResult("Security Token Lifetime Expired",context.Request);
            }
            catch(Exception ex)
            {
                context.ErrorResult = new AuthenticationFailureResult("Invalid Security Token", context.Request);
            }

            
        }

        private async Task<IPrincipal> ValidateCredentialsAsync(string credentials, HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // Create a binary signing key from the secret key
            var symmetricKey = Convert.FromBase64String(SecretKey);

            //Verify whether it is valid token or not 
            var jwtHandler = new JwtSecurityTokenHandler();
            var isValidToken = jwtHandler.ReadJwtToken(credentials);
            if (isValidToken == null)
                return null;

            TokenValidationParameters validationParameter = new TokenValidationParameters
            {
                ValidateAudience = true,
                ValidAudiences = new[] { _audience },

                ValidateIssuer = true,
                ValidIssuers = new[] { _validIssuer },

                RequireSignedTokens =true,
                RequireExpirationTime = true,

                NameClaimType = ClaimTypes.NameIdentifier,
                AuthenticationType = SupportTokenSchema,

                IssuerSigningKey = new SymmetricSecurityKey(symmetricKey)
            };

            SecurityToken validatedToken = new JwtSecurityToken();
            ClaimsPrincipal principal = jwtHandler.ValidateToken(credentials, validationParameter, out validatedToken);

            ((ClaimsIdentity)principal.Identity).AddClaim(new Claim("urn:Issuer",
               validatedToken.Issuer));
            ((ClaimsIdentity)principal.Identity).AddClaim(new Claim("urn:TokenScheme",
                SupportTokenSchema));

            return await Task.FromResult(principal);
          
        }

        public Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
        {
            if (SendChallenge)
            {
                // FYI: Azure AD does support challenges for JWT tokens... the header looks like 
                // this, where authority looks like <instance>/<tenant> ex.
                //  https://login.microsoftonline.com/my.company.com
                //  and audience is the App ID URI of your Azure app. So if you needed that you
                //  would default SendChallenge to true in a constructor, and create your 
                // challenge header like this:
                // AuthenticationHeaderValue authenticateHeader = new 
                //      AuthenticationHeaderValue("Bearer", 
                //      "authorization_uri=\"" + authority + "\"" + "," + "resource_id=" + audience);

                context.Result = new AddChallengeOnUnauthorizedResult(
                    new AuthenticationHeaderValue(SupportTokenSchema),
                    context.Result);
            }

            return Task.FromResult(0);
        }
    }
}