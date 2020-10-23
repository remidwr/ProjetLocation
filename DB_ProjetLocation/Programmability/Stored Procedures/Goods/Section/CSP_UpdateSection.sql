CREATE PROCEDURE [dbo].[CSP_UpdateSection]
	@SectionId INT,
	@SectionName NVARCHAR(50)
AS
BEGIN
	IF EXISTS(SELECT Section_Id FROM Section WHERE Section_Id = @SectionId)
		BEGIN
			UPDATE Section
			SET Section_Name = @SectionName
			WHERE Section_Id = @SectionId;
		END
	ELSE
		RAISERROR('Section doesn''t exist', 16, 1);
END