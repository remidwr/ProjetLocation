CREATE PROCEDURE [dbo].[CSP_UpdateSection]
	@SectionId INT,
	@SectionName NVARCHAR(50)
AS
BEGIN
	IF NOT EXISTS(SELECT Section_Name FROM Section WHERE Section_Name = @SectionName)
		BEGIN
			UPDATE Section
			SET Section_Name = @SectionName
			WHERE Section_Id = @SectionId;
		END
	ELSE
		BEGIN
			RAISERROR('UK_Section_Name', 16, 1);
		END
END