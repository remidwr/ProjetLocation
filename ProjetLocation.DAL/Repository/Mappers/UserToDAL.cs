using ProjetLocation.DAL.Models;
using System;
using System.Data;

namespace ProjetLocation.DAL.Repository.Mappers
{
    internal static class UserToDAL
    {
        internal static User ToDAL_User(this IDataRecord record)
        {
            return new User()
            {
                Id = (int)record["User_Id"],
                LastName = (string)record["LastName"],
                FirstName = (string)record["FirstName"],
                Birthdate = (DateTime)record["Birthdate"],
                Email = (string)record["Email"],
                Street = (string)record["Street"] is DBNull ? null : (string)record["Street"],
                Number = (string)record["Number"] is DBNull ? null : (string)record["Number"],
                Box = (string)record["Box"] is DBNull ? null : (string)record["Box"],
                PostCode = (int)record["PostCode"] is DBNull ? 0 : (int)record["PostCode"],
                City = (string)record["City"] is DBNull ? null : (string)record["City"],
                Phone1 = (string)record["Phone1"] is DBNull ? null : (string)record["Phone1"],
                Phone2 = (string)record["Phone2"] is DBNull ? null : (string)record["Phone2"],
                Picture = (string)record["Picture"] is DBNull ? null : (string)record["Picture"],
                IsActive = (bool)record["Active"],
                IsAdmin = (bool)record["IsAdmin"]
            };
        }
    }
}
