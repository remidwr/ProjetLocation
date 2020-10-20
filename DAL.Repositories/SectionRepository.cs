using DAL.IRepositories;
using DAL.Models;
using DAL.Repositories.Extensions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Tools.Database;

namespace DAL.Repositories
{
    public class SectionRepository : ISectionRepository<Section, Category>
    {
        private static Connection _connection;

        public SectionRepository(Connection connection)
        {
            _connection = connection;
        }

        public IEnumerable<Section> GetAll()
        {
            Command command = new Command("SELECT * FROM Section");

            return _connection.ExecuteReader(command, dr => dr.ToDAL_Section());
        }

        public Section GetById(int sectionId)
        {
            Command command = new Command("SELECT * FROM Section WHERE Section_Id = @SectionId");
            command.AddParameter("SectionId", sectionId);

            return _connection.ExecuteReader(command, dr => dr.ToDAL_Section()).SingleOrDefault();
        }

        public IEnumerable<Category> GetCategoriesBySectionId(int sectionId)
        {
            Command command = new Command("SELECT * FROM Section S JOIN Category C ON S.Section_Id = C.Section_Id WHERE S.Section_Id = @SectionId");
            command.AddParameter("SectionId", sectionId);

            return _connection.ExecuteReader(command, dr => dr.ToDAL_Category());
        }

        public void Insert(Section section)
        {
            int Success;

            Command command = new Command("CSP_InsertSection", true);
            command.AddParameter("SectionName", section.Name);

            try
            {
                Success = _connection.ExecuteNonQuery(command);
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }

            if (Success == 0)
                throw new Exception();
        }

        public void Update(int sectionId, Section section)
        {
            int Success;

            Command command = new Command("CSP_UpdateSection", true);
            command.AddParameter("SectionId", sectionId);
            command.AddParameter("SectionName", section.Name);

            try
            {
                Success = _connection.ExecuteNonQuery(command);
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }

            if (Success == 0)
                throw new Exception();
        }

        public void Delete(int sectionId)
        {
            Command command = new Command("CSP_DeleteSection", true);
            command.AddParameter("SectionId", sectionId);

            int Success = _connection.ExecuteNonQuery(command);

            if (Success == 0)
                throw new Exception();
        }
    }
}
