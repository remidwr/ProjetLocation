using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Tools.Security.Token;

namespace ProjetLocation.API.Infrastructure
{
    public class AuthRequiredAttribute : AuthorizationFilterAttribute
    {
        private ITokenService _tokenSerivce;

        public AuthRequiredAttribute(TokenService tokenService)
        {
            _tokenSerivce = tokenService;
        }

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            actionContext.Request.Headers.TryGetValues("Authorization", out IEnumerable<string> authorisations);

            string token = authorisations?.SingleOrDefault(t => t.StartsWith("Bearer "));

            if (token is null)
            {
                actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
            }
            else
            {
                IDictionary<string, string> keyValuePairs = _tokenSerivce.DecodeToken(token, new string[] { "Id" });

                if (keyValuePairs is null)
                {
                    actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                }
                else if (keyValuePairs.Count == 0)
                {
                    actionContext.Response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                }
                else
                {
                    actionContext.RequestContext.RouteData.Values.Add("userId", int.Parse(keyValuePairs["Id"]));
                }
            }
        }
    }
}
