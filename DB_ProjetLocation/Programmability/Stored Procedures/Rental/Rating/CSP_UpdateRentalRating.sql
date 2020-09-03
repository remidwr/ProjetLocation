CREATE PROCEDURE [dbo].[CSP_UpdateRentalRating]
	@RentalId INT,
	@Rating INT,
	@Review NVARCHAR(MAX)
AS
BEGIN
	IF ((SELECT RentedTo FROM Rental WHERE Rental_Id = @RentalId) < GETDATE())
		BEGIN
			UPDATE Rental
			SET Rating = @Rating,
				Review = @Review
			WHERE Rental_Id = @RentalId;
		END
	ELSE
		BEGIN
			RAISERROR('UnableToAddRating', 16, 1);
		END
END