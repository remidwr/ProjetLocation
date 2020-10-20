CREATE PROCEDURE [dbo].[CSP_UpdateGood]
	@GoodId INT,
	@GoodName NVARCHAR(50),
	@Description NVARCHAR(MAX),
	@State NVARCHAR(50),
    @Amount FLOAT,
	@Street NVARCHAR(120),
	@Number NVARCHAR(10),
	@Box NVARCHAR(10),
	@PostCode INT,
	@City NVARCHAR(120),
	@Picture NVARCHAR(320),
	@UserId INT,
	@SectionId INT,
	@CategoryId INT
AS
BEGIN
	UPDATE Good
	SET Good_Name = @GoodName,
		[Description] = @Description,
		[State] = @State,
		Amount = @Amount,
		Street = @Street,
		Number = @Number,
		Box = @Box,
		PostCode = @PostCode,
		City = @City,
		Picture = @Picture,
		Section_Id = @SectionId,
		Category_Id = @CategoryId
	WHERE Good_Id = @GoodId AND [User_Id] = @UserId;
END