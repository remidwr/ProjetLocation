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
                Street = record["Street"] is DBNull ? null : (string)record["Street"],
                Number = record["Number"] is DBNull ? null : (string)record["Number"],
                Box = record["Box"] is DBNull ? null : (string)record["Box"],
                PostCode = record["PostCode"] is DBNull ? 0 : (int)record["PostCode"],
                City = record["City"] is DBNull ? null : (string)record["City"],
                Phone1 = record["Phone1"] is DBNull ? null : (string)record["Phone1"],
                Phone2 = record["Phone2"] is DBNull ? null : (string)record["Phone2"],
                Picture = record["Picture"] is DBNull ? null : (string)record["Picture"],
                IsActive = (bool)record["IsActive"],
                IsAdmin = (bool)record["IsAdmin"]
            };
        }
    }
}
