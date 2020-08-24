CREATE PROCEDURE [dbo].[CSP_UpdateSection]
	@SectionId INT,
	@SectionName NVARCHAR(50)
AS
BEGIN
	UPDATE Section
	SET Section_Name = @SectionName
	WHERE Section_Id = @SectionId;
END