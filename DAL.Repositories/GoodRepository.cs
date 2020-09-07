using DAL.IRepositories;
using DAL.Models;
using DAL.Repositories.Extensions;
using System.Collections.Generic;
using System.Linq;
using Tools.Database;

namespace DAL.Repositories
{
    public class GoodRepository : IGenericRepository<Good>
    {
        private static Connection _connection;

        public GoodRepository(Connection connection)
        {
            _connection = connection;
        }

        public GoodRepository() : this(_connection)
        {
        }

        public IEnumerable<Good> GetAll()
        {
            Command command = new Command("SELECT * FROM V_Good");

            return _connection.ExecuteReader(command, dr => dr.ToDAL_Good());
        }

        public Good GetById(int id)
        {
            Command command = new Command("SELECT * FROM V_Good WHERE Good_Id = @GoodId");
            command.AddParameter("GoodId", id);

            return _connection.ExecuteReader(command, dr => dr.ToDAL_Good()).SingleOrDefault();
        }

        public User GetUserByGoodId(int id)
        {
            Command command = new Command("SELECT U.[User_Id], LastName, FirstName, Birthdate, Email, Passwd, U.Street, U.Number, U.Box, U.PostCode, U.City, Phone1, Phone2, U.Picture, IsActive, IsBanned, Role_Id FROM Good G JOIN Users U ON G.[User_Id] = U.[User_Id] WHERE G.Good_Id = @GoodId");
            command.AddParameter("GoodId", id);

            return _connection.ExecuteReader(command, dr => dr.ToDAL_User()).SingleOrDefault();
        }

        public Section GetSectionByGoodId(int id)
        {
            Command command = new Command("SELECT * FROM Good G JOIN Section S ON G.Section_Id = S.Section_Id WHERE G.Good_Id = @GoodId");
            command.AddParameter("GoodId", id);

            return _connection.ExecuteReader(command, dr => dr.ToDAL_Section()).SingleOrDefault();
        }

        public Category GetCategoryByGoodId(int id)
        {
            Command command = new Command("SELECT * FROM Good G JOIN Category C ON G.Category_Id = C.Category_Id WHERE G.Good_Id = @GoodId");
            command.AddParameter("GoodId", id);

            return _connection.ExecuteReader(command, dr => dr.ToDAL_Category()).SingleOrDefault();
        }

        public int Insert(Good good)
        {
            Command command = new Command("CSP_InsertGood", true);
            command.AddParameter("GoodName", good.Name);
            command.AddParameter("Description", good.Description);
            command.AddParameter("State", good.State);
            command.AddParameter("AmountPerDay", good.AmountPerDay);
            command.AddParameter("AmountPerWeek", good.AmountPerWeek);
            command.AddParameter("AmountPerMonth", good.AmountPerMonth);
            command.AddParameter("Street", good.Street);
            command.AddParameter("Number", good.Number);
            command.AddParameter("Box", good.Box);
            command.AddParameter("PostCode", good.PostCode);
            command.AddParameter("City", good.City);
            command.AddParameter("Picture", good.Picture);
            command.AddParameter("UserId", good.UserId);
            command.AddParameter("SectionId", good.SectionId);
            command.AddParameter("CategoryId", good.CategoryId);

            return _connection.ExecuteNonQuery(command);
        }

        public int Update(int id, Good good)
        {
            Command command = new Command("CSP_UpdateGood", true);
            command.AddParameter("GoodId", id);
            command.AddParameter("GoodName", good.Name);
            command.AddParameter("Description", good.Description);
            command.AddParameter("State", good.State);
            command.AddParameter("AmountPerDay", good.AmountPerDay);
            command.AddParameter("AmountPerWeek", good.AmountPerWeek);
            command.AddParameter("AmountPerMonth", good.AmountPerMonth);
            command.AddParameter("Street", good.Street);
            command.AddParameter("Number", good.Number);
            command.AddParameter("Box", good.Box);
            command.AddParameter("PostCode", good.PostCode);
            command.AddParameter("City", good.City);
            command.AddParameter("Picture", good.Picture);
            command.AddParameter("UserId", good.UserId);
            command.AddParameter("SectionId", good.SectionId);
            command.AddParameter("CategoryId", good.CategoryId);

            return _connection.ExecuteNonQuery(command);
        }

        public int Delete(int id)
        {
            Command command = new Command("CSP_DeleteGood", true);
            command.AddParameter("GoodId", id);

            return _connection.ExecuteNonQuery(command);
        }
    }
}
