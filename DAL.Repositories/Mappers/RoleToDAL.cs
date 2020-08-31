using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DAL.Repositories.Mappers
{
    internal static class RoleToDAL
    {
        internal static Role ToDAL_Role(this IDataRecord record)
        {
            return new Role()
            {
                Id = (int)record["Role_Id"],
                Name = (string)record["RoleName"]
            };
        }
    }
}
