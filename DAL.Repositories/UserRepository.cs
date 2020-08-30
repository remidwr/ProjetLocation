using DAL.IRepositories;
using DAL.Models;
using DAL.Repositories.Mappers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Tools.Database;

namespace DAL.Repositories
{
    public class UserRepository : IUserRepository<User>
    {
        Connection _connection;

        public UserRepository(Connection connection)
        {
            _connection = connection;
        }

        public IEnumerable<User> GetAll()
        {
            Command command = new Command("SELECT * FROM V_ActiveUser");

            return _connection.ExecuteReader(command, dr => dr.ToDAL_User());
        }

        public User Get(int id)
        {
            Command command = new Command("SELECT * FROM V_ActiveUser WHERE [User_Id] = @UserId");
            command.AddParameter("UserId", id);

            return _connection.ExecuteReader(command, dr => dr.ToDAL_User()).SingleOrDefault();
        }

        public int Update(int id, User entity)
        {
            int Successful = 0;

            Command command = new Command("CSP_UpdateUserInfo", true);
            command.AddParameter("UserId", id);
            command.AddParameter("LastName", entity.LastName);
            command.AddParameter("FirstName", entity.FirstName);
            command.AddParameter("Birthdate", entity.Birthdate);
            command.AddParameter("Street", entity.Street);
            command.AddParameter("Number", entity.Number);
            command.AddParameter("Box", entity.Box);
            command.AddParameter("PostCode", entity.PostCode);
            command.AddParameter("City", entity.City);
            command.AddParameter("Phone1", entity.Phone1);
            command.AddParameter("Phone2", entity.Phone2);
            command.AddParameter("Picture", entity.Picture);

            try
            {
                _connection.ExecuteNonQuery(command);
            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("UserNotFound"))
                    throw new Exception(ex.Message);
            }

            return Successful;
        }

        public int Delete(int id)
        {
            int Successful = 0;
            Command command = new Command("CSP_DeleteUser", true);
            command.AddParameter("UserId", id);

            try
            {
                _connection.ExecuteNonQuery(command);
            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("UserNotFound"))
                    throw new Exception(ex.Message);
            }

            return Successful;
        }
    }
}
