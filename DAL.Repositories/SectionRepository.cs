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
    public class SectionRepository : IGenericRepository<Section>
    {
        private static Connection _connection;

        public SectionRepository(Connection connection)
        {
            _connection = connection;
        }

        public SectionRepository() : this(_connection)
        {
        }

        public IEnumerable<Section> GetAll()
        {
            Command command = new Command("SELECT * FROM V_Section");

            return _connection.ExecuteReader(command, dr => dr.ToDAL_Section());
        }

        public Section GetById(int id)
        {
            Command command = new Command("SELECT * FROM V_Section WHERE Section_Id = @SectionId");
            command.AddParameter("SectionId", id);

            return _connection.ExecuteReader(command, dr => dr.ToDAL_Section()).SingleOrDefault();
        }

        public IEnumerable<Category> GetCategoriesBySectionId(int id)
        {
            Command command = new Command("SELECT * FROM Section S JOIN Category C ON S.Section_Id = C.Section_Id WHERE S.Section_Id = @SectionId");
            command.AddParameter("SectionId", id);

            return _connection.ExecuteReader(command, dr => dr.ToDAL_Category());
        }

        public int Insert(Section section)
        {
            int Successful = 0;

            Command command = new Command("CSP_InsertSection", true);
            command.AddParameter("SectionName", section.Name);

            try
            {
                Successful = _connection.ExecuteNonQuery(command);
            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("UK_Section_Name"))
                    throw new Exception(ex.Message);
            }

            return Successful;
        }

        public int Update(int id, Section section)
        {
            int Successful = 0;
            Command command = new Command("CSP_UpdateSection", true);
            command.AddParameter("SectionId", id);
            command.AddParameter("SectionName", section.Name);

            try
            {
                Successful = _connection.ExecuteNonQuery(command);
            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("UK_Section_Name"))
                    throw new Exception(ex.Message);
            }
            return Successful;
        }

        public int Delete(int id)
        {
            Command command = new Command("CSP_DeleteSection", true);
            command.AddParameter("SectionId", id);

            return _connection.ExecuteNonQuery(command);
        }
    }
}
