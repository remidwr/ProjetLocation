CREATE PROCEDURE [dbo].[CSP_DeleteCategory]
	@CategoryId INT
AS
BEGIN
	DELETE FROM Category
	WHERE Category_Id = @CategoryId;
END