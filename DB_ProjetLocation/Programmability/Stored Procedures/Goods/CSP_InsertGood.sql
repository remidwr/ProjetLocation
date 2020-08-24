CREATE PROCEDURE [dbo].[CSP_InsertGood]
	@GoodName NVARCHAR(50),
	@Description NVARCHAR(MAX),
	@State NVARCHAR(50),
    @AmountPerDay FLOAT, 
    @AmountPerWeek FLOAT, 
    @AmoutPerMonth FLOAT, 
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
	INSERT INTO Good ([Good_Name], [Description], [State], [AmountPerDay], [AmountPerWeek], [AmoutPerMonth], [Street], [Number], [Box], [PostCode], [City], [Picture], [User_Id], [Section_Id])
	VALUES (@GoodName, @Description, @State, @AmountPerDay, @AmountPerWeek, @AmoutPerMonth, @Street, @Number, @Box, @PostCode, @City, @Picture, @UserId, @SectionId);
END