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
                Phone1 = (string)record["Phone1"] is DBNull ? null : (string)record["Phone1"],
                Phone2 = (string)record["Phone2"] is DBNull ? null : (string)record["Phone2"],
                Picture = (string)record["Picture"] is DBNull ? null : (string)record["Picture"],
                Active = (bool)record["Active"],
                GroupId = (int)record["Group_Id"] is DBNull ? 0 : (int)record["Group_Id"]
            };
        }
    }
}
