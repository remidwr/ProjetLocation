CREATE PROCEDURE [dbo].[CSP_UpdateUserInfo]
	@UserId INT,
	--@LastName NVARCHAR(50),
	--@FirstName NVARCHAR(50),
	--@Birthdate DATE,
	@Street NVARCHAR(120),
    @Number NVARCHAR(10),
    @Box NVARCHAR(10),
    @PostCode INT,
    @City NVARCHAR(120),
	@Phone1 NVARCHAR(50),
	@Phone2 NVARCHAR(50),
	--@Picture NVARCHAR(320)
AS
BEGIN
	UPDATE Users
	SET --LastName = @LastName,
		--FirstName = @FirstName,
		--Birthdate = @Birthdate,
		Street = @Street,
		Number = @Number,
		Box = @Box,
		PostCode = @PostCode,
		City = @City,
		Phone1 = @Phone1,
		Phone2 = @Phone2
		--Picture = @Picture
	WHERE [User_Id] = @UserId;
END