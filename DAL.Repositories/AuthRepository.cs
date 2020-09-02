using DAL.IRepositories;
using DAL.Models;
using DAL.Repositories.Extensions;
using System;
using System.Data.SqlClient;
using System.Linq;
using Tools.Database;

namespace DAL.Repositories
{
    public class AuthRepository : IAuthRepository<User>
    {
        public Connection _connection;

        public AuthRepository(Connection connection)
        {
            _connection = connection;
        }

        public int Register(User user)
        {
            int Successful = 0;

            Command command = new Command("CSP_Register", true);
            command.AddParameter("LastName", user.LastName);
            command.AddParameter("FirstName", user.FirstName);
            command.AddParameter("Birthdate", user.Birthdate);
            command.AddParameter("Email", user.Email);
            command.AddParameter("Passwd", user.Passwd);

            try
            {
                Successful = _connection.ExecuteNonQuery(command);
            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("UK_Users_Email"))
                    throw new Exception(ex.Message);
                else if (ex.Message.Contains("User_Banned"))
                    throw new Exception(ex.Message);
            }

            return Successful;
        }

        public User Login(string email, string passwd)
        {
            User user = new User();

            Command command = new Command("CSP_Login", true);
            command.AddParameter("Email", email);
            command.AddParameter("Passwd", passwd);

            try
            {
                user = _connection.ExecuteReader(command, dr => dr.ToDAL_User()).SingleOrDefault();
            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("User_Inactive"))
                    throw new Exception(ex.Message);
                else if (ex.Message.Contains("User_Banned"))
                    throw new Exception(ex.Message);
            }

            return user;
        }
    }
}
