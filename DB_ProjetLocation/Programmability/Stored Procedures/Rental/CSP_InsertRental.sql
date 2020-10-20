CREATE PROCEDURE [dbo].[CSP_InsertRental]
	@GoodId INT,
	@OwnerId INT,
	@TenantId INT,
	@RentedFrom DATETIME,
	@RentedTo DATETIME,
	@Deposit FLOAT
AS
BEGIN
	DECLARE @Amount FLOAT;
	DECLARE @Day INT;

	IF ((SELECT Amount FROM Good WHERE Good_Id = @GoodId) IS NOT NULL)
		BEGIN
			SET @Day = DATEDIFF(DAY, @RentedFrom, @RentedTo);
			SET @Amount = @Day * (SELECT Amount FROM Good WHERE Good_Id = @GoodId);
		END

	INSERT INTO Rental ([Good_Id], [Owner_Id], [Tenant_Id], [CreationDate], [RentedFrom], [RentedTo], [Amount], [Deposit])
	VALUES (@GoodId, @OwnerId, @TenantId, GETDATE(), @RentedFrom, @RentedTo, @Amount, @Deposit);
END