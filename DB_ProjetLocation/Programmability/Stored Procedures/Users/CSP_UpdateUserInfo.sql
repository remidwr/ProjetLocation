CREATE PROCEDURE [dbo].[CSP_UpdateUserInfo]
	@UserId INT,
	@Street NVARCHAR(120),
    @Number NVARCHAR(10),
    @Box NVARCHAR(10),
    @PostCode INT,
    @City NVARCHAR(120),
	@Phone1 NVARCHAR(50),
	@Phone2 NVARCHAR(50)
AS
BEGIN
	UPDATE Users
	SET Street = @Street,
		Number = @Number,
		Box = @Box,
		PostCode = @PostCode,
		City = @City,
		Phone1 = @Phone1,
		Phone2 = @Phone2
	WHERE [User_Id] = @UserId;
END