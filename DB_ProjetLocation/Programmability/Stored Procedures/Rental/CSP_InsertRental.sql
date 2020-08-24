CREATE PROCEDURE [dbo].[CSP_InsertRental]
	@GoodId INT,
	@UserId INT,
	@RentedFrom DATETIME,
	@RentedTo DATETIME,
	@Amount FLOAT,
	@Deposit FLOAT
AS
BEGIN
	INSERT INTO Rental ([CreationDate], [Good_Id], [User_Id], [RentedFrom], [RentedTo], [Amount], [Deposit])
	VALUES (GETDATE(), @GoodId, @UserId, @RentedFrom, @RentedTo, @Amount, @Deposit);
END