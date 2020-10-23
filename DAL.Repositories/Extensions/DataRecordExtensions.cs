using DAL.Models;
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
                BirthDate = (DateTime)record["BirthDate"],
                Email = (string)record["Email"],
                Street = record["Street"] is DBNull ? null : (string)record["Street"],
                Number = record["Number"] is DBNull ? null : (string)record["Number"],
                Box = record["Box"] is DBNull ? null : (string)record["Box"],
                PostCode = record["PostCode"] is DBNull ? null : (int?)record["PostCode"],
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
                Amount = (double)record["Amount"],
                Street = (string)record["Street"],
                Number = (string)record["Number"],
                Box = record["Box"] is DBNull ? null : (string)record["Box"],
                PostCode = (int)record["PostCode"],
                City = (string)record["City"],
                Picture = (string)record["Picture"],
                UserId = (int)record["User_Id"],
                SectionId = (int)record["Section_Id"],
                CategoryId = (int)record["Category_Id"],
                IsActive = (bool)record["IsActive"]
            };
        }

        internal static Section ToDAL_Section(this IDataRecord record)
        {
            return new Section()
            {
                Id = (int)record["Section_Id"],
                Name = (string)record["Section_Name"]
            };
        }

        internal static Category ToDAL_Category(this IDataRecord record)
        {
            return new Category()
            {
                Id = (int)record["Category_Id"],
                Name = (string)record["Category_Name"],
                SectionId = (int)record["Section_Id"]
            };
        }

        internal static Rental ToDAL_Rental(this IDataRecord record)
        {
            return new Rental()
            {
                Id = (int)record["Rental_Id"],
                GoodId = (int)record["Good_Id"],
                OwnerId = (int)record["Owner_Id"],
                TenantId = (int)record["Tenant_Id"],
                CreationDate = (DateTime)record["CreationDate"],
                RentedFrom = (DateTime)record["RentedFrom"],
                RentedTo = (DateTime)record["RentedTo"],
                Amount = (double)record["Amount"],
                Deposit = record["Deposit"] is DBNull ? null : (double?)record["Deposit"],
                Rating = record["Rating"] is DBNull ? null : (int?)record["Rating"],
                Review = record["Review"] is DBNull ? null : (string)record["Review"]
            };
        }
    }
}
