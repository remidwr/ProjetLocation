﻿using DAL.Models;
using System;
using System.Data;

namespace DAL.Repositories.Extensions
{
    internal static class DataRecordExtensions
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
                IsBanned = (bool)record["IsBanned"],
                RoleId = (int)record["Role_Id"]
            };
        }

        internal static Role ToDAL_Role(this IDataRecord record)
        {
            return new Role()
            {
                Id = (int)record["Role_Id"],
                Name = (string)record["RoleName"]
            };
        }

        internal static Good ToDAL_Good(this IDataRecord record)
        {
            return new Good()
            {
                Id = (int)record["Good_Id"],
                Name = (string)record["Good_Name"],
                Description = (string)record["Description"],
                State = (string)record["State"],
                AmountPerDay = (double)record["AmountPerDay"],
                AmountPerWeek = record["AmountPerWeek"] is DBNull ? null : (double?)record["AmountPerWeek"],
                AmountPerMonth = record["AmountPerMonth"] is DBNull ? null : (double?)record["AmountPerMonth"],
                Street = (string)record["Street"],
                Number = (string)record["Number"],
                Box = record["Box"] is DBNull ? null : (string)record["Box"],
                PostCode = (int)record["PostCode"],
                City = (string)record["City"],
                Picture = (string)record["Picture"],
                UserId = (int)record["User_Id"],
                SectionId = (int)record["Section_Id"]
            };
        }
    }
}