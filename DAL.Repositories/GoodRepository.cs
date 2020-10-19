using DAL.IRepositories;
using DAL.Models;
using DAL.Repositories.Extensions;
using System.Collections.Generic;
using System.Linq;
using Tools.Database;

namespace DAL.Repositories
{
    public class GoodRepository : IGoodRepository<Good, User, Section, Category>
    {
        private static Connection _connection;

        public GoodRepository(Connection connection)
        {
            _connection = connection;
        }

        public IEnumerable<Good> GetAll()
        {
            Command command = new Command("SELECT * FROM Good");

            return _connection.ExecuteReader(command, dr => dr.ToDAL_Good());
        }

        public Good GetById(int goodId)
        {
            Command command = new Command("SELECT * FROM Good WHERE Good_Id = @GoodId");
            command.AddParameter("GoodId", goodId);

            return _connection.ExecuteReader(command, dr => dr.ToDAL_Good()).SingleOrDefault();
        }

        public User GetUserByGoodId(int goodId)
        {
            Command command = new Command("SELECT * FROM Good G JOIN Users U ON G.[User_Id] = U.[User_Id] WHERE G.Good_Id = @GoodId");
            command.AddParameter("GoodId", goodId);

            return _connection.ExecuteReader(command, dr => dr.ToDAL_User()).SingleOrDefault();
        }

        public Section GetSectionByGoodId(int goodId)
        {
            Command command = new Command("SELECT * FROM Good G JOIN Section S ON G.Section_Id = S.Section_Id WHERE G.Good_Id = @GoodId");
            command.AddParameter("GoodId", goodId);

            return _connection.ExecuteReader(command, dr => dr.ToDAL_Section()).SingleOrDefault();
        }

        public Category GetCategoryByGoodId(int goodId)
        {
            Command command = new Command("SELECT * FROM Good G JOIN Category C ON G.Category_Id = C.Category_Id WHERE G.Good_Id = @GoodId");
            command.AddParameter("GoodId", goodId);

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

        public int Update(int goodId, Good good)
        {
            Command command = new Command("CSP_UpdateGood", true);
            command.AddParameter("GoodId", goodId);
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

        public int Delete(int goodId)
        {
            Command command = new Command("CSP_DeleteGood", true);
            command.AddParameter("GoodId", goodId);

            return _connection.ExecuteNonQuery(command);
        }
    }
}
