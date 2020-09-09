using DAL.IRepositories;
using DAL.Models;
using DAL.Repositories.Extensions;
using System.Collections.Generic;
using System.Linq;
using Tools.Database;

namespace DAL.Repositories
{
    public class UserRepository : IUserRepository<User, Good>
    {
        private static Connection _connection;

        public UserRepository(Connection connection)
        {
            _connection = connection;
        }

        public UserRepository() : this(_connection)
        {
        }

        public IEnumerable<User> GetAll()
        {
            Command command = new Command("SELECT * FROM Users WHERE IsActive = 1");

            return _connection.ExecuteReader(command, dr => dr.ToDAL_User());
        }

        public User GetById(int id)
        {
            User user = new User();

            Command command = new Command("SELECT * FROM Users WHERE IsActive = 1 AND [User_Id] = @UserId");
            command.AddParameter("UserId", id);

            return _connection.ExecuteReader(command, dr => dr.ToDAL_User()).SingleOrDefault();
        }

        public IEnumerable<Good> GetGoodsByUserId(int id)
        {
            Command command = new Command("SELECT * FROM Good G JOIN Users U ON G.[User_Id] = U.[User_Id] WHERE U.[User_Id] = @UserId");
            command.AddParameter("UserId", id);

            return _connection.ExecuteReader(command, dr => dr.ToDAL_Good());
        }

        public int Insert(User user)
        {
            throw new System.NotImplementedException();
        }

        public int Update(int id, User user)
        {
            Command command = new Command("CSP_UpdateUserInfo", true);
            command.AddParameter("UserId", id);
            command.AddParameter("LastName", user.LastName);
            command.AddParameter("FirstName", user.FirstName);
            command.AddParameter("Birthdate", user.Birthdate);
            command.AddParameter("Street", user.Street);
            command.AddParameter("Number", user.Number);
            command.AddParameter("Box", user.Box);
            command.AddParameter("PostCode", user.PostCode);
            command.AddParameter("City", user.City);
            command.AddParameter("Phone1", user.Phone1);
            command.AddParameter("Phone2", user.Phone2);
            command.AddParameter("Picture", user.Picture);

            return _connection.ExecuteNonQuery(command);
        }

        public int UpdatePassword(int id, User user)
        {
            Command command = new Command("CSP_UpdateUserPassword", true);
            command.AddParameter("UserId", id);
            command.AddParameter("Passwd", user.Passwd);

            return _connection.ExecuteNonQuery(command);
        }

        public int Delete(int id)
        {
            Command command = new Command("CSP_DeleteUser", true);
            command.AddParameter("UserId", id);

            return _connection.ExecuteNonQuery(command);
        }
    }
}
