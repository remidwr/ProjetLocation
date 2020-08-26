﻿using ProjetLocation.API.Utils.Security.Token;
using ProjetLocation.DAL.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace ProjetLocation.API.Infrastructure
{
    public class AuthRequiredAttribute : AuthorizationFilterAttribute
    {
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
                User user = TokenService.Instance.DecodeToken(token);

                if (user is null)
                {
                    actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                }
                else
                {
                    actionContext.RequestContext.RouteData.Values.Add("userId", user.Id);
                }
            }
        }
    }
}
