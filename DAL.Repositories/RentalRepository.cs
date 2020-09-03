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
    public class RentalRepository : IGenericRepository<Rental>
    {
        Connection _connection;

        public RentalRepository(Connection connection)
        {
            _connection = connection;
        }

        public IEnumerable<Rental> GetAll()
        {
            Command command = new Command("SELECT * FROM V_Rental");

            return _connection.ExecuteReader(command, dr => dr.ToDAL_Rental());
        }

        public Rental Get(int id)
        {
            Command command = new Command("SELECT * FROM V_Rental WHERE Rental_Id = @RentalId");
            command.AddParameter("RentalId", id);

            return _connection.ExecuteReader(command, dr => dr.ToDAL_Rental()).SingleOrDefault();
        }

        public int Insert(Rental rental)
        {
            Command command = new Command("CSP_InsertRental", true);
            command.AddParameter("GoodId", rental.GoodId);
            command.AddParameter("OwnerId", rental.OwnerId);
            command.AddParameter("TenantId", rental.TenantId);
            command.AddParameter("RentedFrom", rental.RentedFrom);
            command.AddParameter("RentedTo", rental.RentedTo);
            command.AddParameter("Deposit", rental.Deposit);

            return _connection.ExecuteNonQuery(command);
        }

        public int Update(int id, Rental rental)
        {
            Command command = new Command("CSP_UpdateRental", true);
            command.AddParameter("RentalId", id);
            command.AddParameter("RentedFrom", rental.RentedFrom);
            command.AddParameter("RentedTo", rental.RentedTo);
            command.AddParameter("Amount", rental.Amount);
            command.AddParameter("Deposit", rental.Deposit);

            return _connection.ExecuteNonQuery(command);
        }

        public int Delete(int id)
        {
            int Successful = 0;

            Command command = new Command("CSP_DeleteRental", true);
            command.AddParameter("RentalId", id);

            try
            {
                Successful = _connection.ExecuteNonQuery(command);
            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("UnableToDelete"))
                    throw new Exception(ex.Message);
            }

            return Successful;
        }
    }
}
