using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetLocation.API.Infrastructure
{
    public class AuthorizeRoles : AuthorizeAttribute
    {
        [Flags]
        public enum Role
        {
            Subscriber = 0,
            Contributor = 1,
            Author = 2,
            Editor = 4,
            Administrator = 8,
            SuperAdministrator = 16
        }
    }
}
