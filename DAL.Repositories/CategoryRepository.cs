using DAL.IRepositories;
using DAL.Models;
using DAL.Repositories.Extensions;
using System.Collections.Generic;
using System.Linq;
using Tools.Database;

namespace DAL.Repositories
{
    public class CategoryRepository : ICategoryRepository<Category, Section>
    {
        private static Connection _connection;

        public CategoryRepository(Connection connection)
        {
            _connection = connection;
        }

        public IEnumerable<Category> GetAll()
        {
            Command command = new Command("SELECT * FROM Category");

            return _connection.ExecuteReader(command, dr => dr.ToDAL_Category());
        }

        public Category GetById(int categoryId)
        {
            Command command = new Command("SELECT * FROM Category WHERE Category_Id = @CategoryId");
            command.AddParameter("CategoryId", categoryId);

            return _connection.ExecuteReader(command, dr => dr.ToDAL_Category()).SingleOrDefault();
        }

        public Section GetSectionByCategoryId(int categoryId)
        {
            Command command = new Command("SELECT * FROM Category C JOIN Section S ON C.Section_Id = S.Section_Id WHERE C.Category_Id = @CategoryId");
            command.AddParameter("CategoryId", categoryId);

            return _connection.ExecuteReader(command, dr => dr.ToDAL_Section()).SingleOrDefault();
        }

        public int Insert(Category category)
        {
            Command command = new Command("CSP_InsertCategory", true);
            command.AddParameter("CategoryName", category.Name);
            command.AddParameter("SectionId", category.SectionId);

            return _connection.ExecuteNonQuery(command);
        }

        public int Update(int categoryId, Category category)
        {
            Command command = new Command("CSP_UpdateCategory", true);
            command.AddParameter("CategoryId", categoryId);
            command.AddParameter("CategoryName", category.Name);
            command.AddParameter("SectionId", category.SectionId);

            return _connection.ExecuteNonQuery(command);
        }

        public int Delete(int categoryId)
        {
            Command command = new Command("CSP_DeleteCategory", true);
            command.AddParameter("CategoryId", categoryId);

            return _connection.ExecuteNonQuery(command);
        }
    }
}
