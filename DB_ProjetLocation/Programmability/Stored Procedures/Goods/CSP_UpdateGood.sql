CREATE PROCEDURE [dbo].[CSP_UpdateGood]
	@GoodId INT,
	@GoodName NVARCHAR(50),
	@Description NVARCHAR(MAX),
	@State NVARCHAR(50),
    @AmountPerDay FLOAT, 
    @AmountPerWeek FLOAT, 
    @AmountPerMonth FLOAT, 
	@Street NVARCHAR(120),
	@Number NVARCHAR(10),
	@Box NVARCHAR(10),
	@PostCode INT,
	@City NVARCHAR(120),
	@Picture NVARCHAR(320),
	@UserId INT,
	@SectionId INT
AS
BEGIN
	UPDATE Good
	SET Good_Name = @GoodName,
		[Description] = @Description,
		[State] = @State,
		AmountPerDay = @AmountPerDay,
		AmountPerWeek = @AmountPerWeek,
		AmountPerMonth = @AmountPerMonth,
		Street = @Street,
		Number = @Number,
		Box = @Box,
		PostCode = @PostCode,
		City = @City,
		Picture = @Picture,
		Section_Id = @SectionId
	WHERE Good_Id = @GoodId AND [User_Id] = @UserId;
END