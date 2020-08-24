CREATE PROCEDURE [dbo].[CSP_UpdateCategory]
	@CategoryId INT,
	@CategoryName NVARCHAR(50),
	@SectionId INT
AS
BEGIN
	UPDATE Category
	SET Category_Name = @CategoryName,
		Section_Id = @SectionId
	WHERE Category_Id = @CategoryId;
END