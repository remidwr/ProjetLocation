CREATE PROCEDURE [dbo].[CSP_InsertRental]
	@GoodId INT,
	@UserId INT,
	@RentedFrom DATETIME,
	@RentedTo DATETIME,
	@Deposit FLOAT
AS
BEGIN
	DECLARE @Amount FLOAT;
	DECLARE @Day INT;
	DECLARE @Week INT;
	DECLARE @Month INT;

	IF ((SELECT AmountPerDay FROM Good WHERE Good_Id = @GoodId) IS NOT NULL)
		BEGIN
			SET @Day = DATEDIFF(DAY, @RentedFrom, @RentedTo);
			SET @Amount = @Day * (SELECT AmountPerDay FROM Good WHERE Good_Id = @GoodId);
		END
	ELSE IF ((SELECT AmountPerWeek FROM Good WHERE Good_Id = @GoodId) IS NOT NULL)
		BEGIN
			SET @Week = DATEDIFF(WEEK, @RentedFrom, @RentedTo);
			SET @Amount = @Week * (SELECT AmountPerWeek FROM Good WHERE Good_Id = @GoodId);
		END
	ELSE IF ((SELECT AmountPerMonth FROM Good WHERE Good_Id = @GoodId) IS NOT NULL)
		BEGIN
			SET @Month = DATEDIFF(MONTH, @RentedFrom, @RentedTo);
			SET @Amount = @Month * (SELECT AmountPerMonth FROM Good WHERE Good_Id = @GoodId);
		END

	INSERT INTO Rental ([Good_Id], [User_Id], [CreationDate], [RentedFrom], [RentedTo], [Amount], [Deposit])
	VALUES (@GoodId, @UserId, GETDATE(), @RentedFrom, @RentedTo, @Amount, @Deposit);
END