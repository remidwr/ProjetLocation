CREATE PROCEDURE [dbo].[CSP_InsertSection]
	@SectionName NVARCHAR(50)
AS
BEGIN
	IF NOT EXISTS(SELECT Section_Name FROM Section WHERE Section_Name = @SectionName)
		BEGIN
			INSERT INTO Section ([Section_Name])
			VALUES (@SectionName);
		END
	ELSE
		BEGIN
			RAISERROR('UK_Section_Name', 16, 1);
		END
END