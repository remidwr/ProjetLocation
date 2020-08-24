CREATE PROCEDURE [dbo].[CSP_InsertCategory]
	@CategoryName NVARCHAR(50),
	@SectionId INT
AS
BEGIN
	INSERT INTO Category ([Category_Name], [Section_Id])
	VALUES (@CategoryName, @SectionId);
END