CREATE PROCEDURE [dbo].[CSP_DeleteRental]
	@RentalId INT
AS
BEGIN
	DELETE FROM Rental
	WHERE Rental_Id = @RentalId;
END