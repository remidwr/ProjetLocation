using DAL.IRepositories;
using DAL.Models;
using DAL.Repositories.Extensions;
using System.Collections.Generic;
using System.Linq;
using Tools.Database;

namespace DAL.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private static Connection _connection;

        public RoleRepository(Connection connection)
        {
            _connection = connection;
        }

        public IEnumerable<Role> GetAll()
        {
            Command command = new Command("SELECT * FROM Roles;");

            return _connection.ExecuteReader(command, dr => dr.ToDAL_Role());
        }

        public Role GetById(int roleId)
        {
            Command command = new Command("SELECT * FROM Roles WHERE Role_Id = @RoleId;");
            command.AddParameter("RoleId", roleId);

            return _connection.ExecuteReader(command, dr => dr.ToDAL_Role()).SingleOrDefault();
        }
    }
}
