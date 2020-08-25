CREATE PROCEDURE [dbo].[CSP_UpdateRental]
	@RentalId INT,
	@RentedFrom DATETIME,
	@RentedTo DATETIME,
	@Amount FLOAT,
	@Deposit FLOAT
AS
BEGIN
	UPDATE Rental
	SET RentedFrom = @RentedFrom,
		RentedTo = @RentedTo,
		Amount = @Amount,
		Deposit = @Deposit
	WHERE Rental_Id = @RentalId;
END