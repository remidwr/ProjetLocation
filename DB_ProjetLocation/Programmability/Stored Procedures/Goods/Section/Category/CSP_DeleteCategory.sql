CREATE PROCEDURE [dbo].[CSP_DeleteCategory]
	@CategoryId INT
AS
BEGIN
	IF NOT EXISTS(SELECT Good_Id FROM Good WHERE Category_Id = @CategoryId)
		BEGIN
			DELETE FROM Category
			WHERE Category_Id = @CategoryId;
		END
	ELSE
		RAISERROR('Unable to delete category', 16, 1);
END