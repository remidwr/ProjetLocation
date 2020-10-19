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
    public class RentalRepository : IRentalRepository<Rental, User, Good>
    {
        private static Connection _connection;

        public RentalRepository(Connection connection)
        {
            _connection = connection;
        }

        public IEnumerable<Rental> GetAll()
        {
            Command command = new Command("SELECT * FROM Rental");

            return _connection.ExecuteReader(command, dr => dr.ToDAL_Rental());
        }

        public Rental GetById(int rentalId)
        {
            Command command = new Command("SELECT * FROM Rental WHERE Rental_Id = @RentalId");
            command.AddParameter("RentalId", rentalId);

            return _connection.ExecuteReader(command, dr => dr.ToDAL_Rental()).SingleOrDefault();
        }

        public User GetOwnerByRentalId(int rentalId)
        {
            Command command = new Command("SELECT * FROM Rental R JOIN Users U ON R.Owner_Id = U.[User_Id] WHERE R.Rental_Id = @RentalId");
            command.AddParameter("RentalId", rentalId);

            return _connection.ExecuteReader(command, dr => dr.ToDAL_User()).SingleOrDefault();
        }

        public User GetTenantByRentalId(int rentalId)
        {
            Command command = new Command("SELECT * FROM Rental R JOIN Users U ON R.Tenant_Id = U.[User_Id] WHERE R.Rental_Id = @RentalId");
            command.AddParameter("RentalId", rentalId);

            return _connection.ExecuteReader(command, dr => dr.ToDAL_User()).SingleOrDefault();
        }

        public Good GetGoodByRentalId(int rentalId)
        {
            Command command = new Command("SELECT * FROM Rental R JOIN Good G ON R.Good_Id = G.Good_Id WHERE R.Rental_Id = @RentalId");
            command.AddParameter("RentalId", rentalId);

            return _connection.ExecuteReader(command, dr => dr.ToDAL_Good()).SingleOrDefault();
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

        public int Update(int rentalId, Rental rental)
        {
            Command command = new Command("CSP_UpdateRental", true);
            command.AddParameter("RentalId", rentalId);
            command.AddParameter("RentedFrom", rental.RentedFrom);
            command.AddParameter("RentedTo", rental.RentedTo);
            command.AddParameter("Amount", rental.Amount);
            command.AddParameter("Deposit", rental.Deposit);

            return _connection.ExecuteNonQuery(command);
        }

        public int UpdateRating(int rentalId, Rental rental)
        {
            int Successful = 0;

            Command command = new Command("CSP_UpdateRentalRating", true);
            command.AddParameter("RentalId", rentalId);
            command.AddParameter("Rating", rental.Rating);
            command.AddParameter("Review", rental.Review);

            try
            {
                Successful = _connection.ExecuteNonQuery(command);
            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("UnableToAddRating"))
                    throw new Exception(ex.Message);
            }

            return Successful;
        }

        public int Delete(int rentalId)
        {
            int Successful = 0;

            Command command = new Command("CSP_DeleteRental", true);
            command.AddParameter("RentalId", rentalId);

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
