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
        Connection _connection;

        public GoodRepository(Connection connection)
        {
            _connection = connection;
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
