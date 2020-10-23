CREATE PROCEDURE [dbo].[CSP_UpdateCategory]
	@CategoryId INT,
	@CategoryName NVARCHAR(50),
	@SectionId INT
AS
BEGIN
	IF (EXISTS(SELECT Section_Id FROM Section WHERE Section_Id = @SectionId) 
			AND NOT EXISTS(SELECT Category_Id FROM Category WHERE Category_Name = @CategoryName AND Section_Id = @SectionId))
		BEGIN
			UPDATE Category
			SET Category_Name = @CategoryName,
				Section_Id = @SectionId
			WHERE Category_Id = @CategoryId;
		END
	ELSE
		RAISERROR('Unable to update category', 16, 1);
END