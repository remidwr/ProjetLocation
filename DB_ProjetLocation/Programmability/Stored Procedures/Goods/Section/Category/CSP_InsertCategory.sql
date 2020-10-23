CREATE PROCEDURE [dbo].[CSP_InsertCategory]
	@CategoryName NVARCHAR(50),
	@SectionId INT
AS
BEGIN
	IF (EXISTS(SELECT Section_Id FROM Section WHERE Section_Id = @SectionId) 
		AND NOT EXISTS(SELECT Category_Id FROM Category WHERE Category_Name = @CategoryName AND Section_Id = @SectionId))
		BEGIN
			INSERT INTO Category ([Category_Name], [Section_Id])
			VALUES (@CategoryName, @SectionId);
		END
	ELSE
		RAISERROR('Unable to insert category', 16, 1);
END