using DAL.IRepositories;
using DAL.Models;
using DAL.Repositories.Extensions;
using System.Collections.Generic;
using System.Linq;
using Tools.Database;

namespace DAL.Repositories
{
    public class CategoryRepository : IGenericRepository<Category>
    {
        Connection _connection;

        public CategoryRepository(Connection connection)
        {
            _connection = connection;
        }

        public IEnumerable<Category> GetAll()
        {
            Command command = new Command("SELECT * FROM V_Category");

            return _connection.ExecuteReader(command, dr => dr.ToDAL_Category());
        }

        public Category GetById(int id)
        {
            Command command = new Command("SELECT * FROM V_Category WHERE Category_Id = @CategoryId");
            command.AddParameter("CategoryId", id);

            return _connection.ExecuteReader(command, dr => dr.ToDAL_Category()).SingleOrDefault();
        }

        public int Insert(Category category)
        {
            Command command = new Command("CSP_InsertCategory", true);
            command.AddParameter("CategoryName", category.Name);
            command.AddParameter("SectionId", category.SectionId);

            return _connection.ExecuteNonQuery(command);
        }

        public int Update(int id, Category category)
        {
            Command command = new Command("CSP_UpdateCategory", true);
            command.AddParameter("CategoryId", id);
            command.AddParameter("CategoryName", category.Name);
            command.AddParameter("SectionId", category.SectionId);

            return _connection.ExecuteNonQuery(command);
        }

        public int Delete(int id)
        {
            Command command = new Command("CSP_DeleteCategory", true);
            command.AddParameter("CategoryId", id);

            return _connection.ExecuteNonQuery(command);
        }
    }
}
