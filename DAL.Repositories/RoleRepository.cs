using DAL.IRepositories;
using DAL.Models;
using DAL.Repositories.Extensions;
using System.Collections.Generic;
using System.Linq;
using Tools.Database;

namespace DAL.Repositories
{
    public class RoleRepository : IRoleRepository<Role>
    {
        private static Connection _connection;

        public RoleRepository(Connection connection)
        {
            _connection = connection;
        }

        public RoleRepository() : this(_connection)
        {
        }

        public IEnumerable<Role> GetAll()
        {
            Command command = new Command("SELECT * FROM Roles;");

            return _connection.ExecuteReader(command, dr => dr.ToDAL_Role());
        }

        public Role GetById(int id)
        {
            Command command = new Command("SELECT * FROM Roles WHERE Role_Id = @RoleId;");

            return _connection.ExecuteReader(command, dr => dr.ToDAL_Role()).SingleOrDefault();
        }

        public IEnumerable<User> GetUsersByRoleId(int id)
        {
            Command command = new Command("SELECT * FROM Roles R JOIN Users U ON R.Role_Id = U.Role_Id WHERE R.Role_Id = @RoleId;");
            command.AddParameter("RoleId", id);

            return _connection.ExecuteReader(command, dr => dr.ToDAL_User());
        }
    }
}
