﻿CREATE PROCEDURE [dbo].[CSP_UpdateRentalRating]
	@RentalId INT,
	@Rating INT,
	@Review NVARCHAR(MAX)
AS
BEGIN
	UPDATE Rental
	SET Rating = @Rating,
		Review = @Review
	WHERE Rental_Id = @RentalId;
END