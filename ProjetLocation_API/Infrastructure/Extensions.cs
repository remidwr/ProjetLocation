using DAL.Models;
using System.Collections.Generic;
using System.Security.Claims;

namespace ProjetLocation.API.Infrastructure
{
    internal static class Extensions
    {
        internal static IEnumerable<Claim> ToCLaims(this User user)
        {
            yield return new Claim("Id", user.Id.ToString());
            yield return new Claim("LastName", user.LastName);
            yield return new Claim("FirstName", user.FirstName);
            yield return new Claim("Birthdate", user.Birthdate.ToString());
            yield return new Claim("Email", user.Email);
            yield return new Claim("IsActive", user.IsActive.ToString());
            yield return new Claim("IsAdmin", user.IsAdmin.ToString());
        }
    }
}
