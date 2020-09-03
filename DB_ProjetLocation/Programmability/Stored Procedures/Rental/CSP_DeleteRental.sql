CREATE PROCEDURE [dbo].[CSP_DeleteRental]
	@RentalId INT
AS
BEGIN
	IF ((SELECT RentedTo FROM Rental WHERE Rental_Id = @RentalId) > GETDATE())
		BEGIN
			DELETE FROM Rental
			WHERE Rental_Id = @RentalId;
		END
	ELSE
		BEGIN
			RAISERROR('UnableToDelete', 16, 1);
		END
END