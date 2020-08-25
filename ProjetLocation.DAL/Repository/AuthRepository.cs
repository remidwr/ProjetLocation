using ProjetLocation.DAL.IRepository;
using ProjetLocation.DAL.Models;
using ProjetLocation.DAL.Repository.Mappers;
using System.Linq;
using Tools.Database;

namespace ProjetLocation.DAL.Repository
{
    public class AuthRepository : IAuthRepository<User>
    {
        public Connection _connection;

        public AuthRepository(Connection connection)
        {
            _connection = connection;
        }

        public User Login(string email, string passwd)
        {
            Command command = new Command("Login", true);
            command.AddParameter("Email", email);
            command.AddParameter("Passwd", passwd);

            return _connection.ExecuteReader(command, dr => dr.ToDAL_User()).SingleOrDefault();
        }

        public int Register(User user)
        {
            Command command = new Command("Register", true);
            command.AddParameter("LastName", user.LastName);
            command.AddParameter("FirstName", user.FirstName);
            command.AddParameter("Birthdate", user.Birthdate);
            command.AddParameter("Email", user.Email);
            command.AddParameter("Passwd", user.Passwd);

            return _connection.ExecuteNonQuery(command);
        }
    }
}
