CREATE PROCEDURE [dbo].[CSP_InsertSection]
	@SectionName NVARCHAR(50)
AS
BEGIN
	INSERT INTO Section ([Section_Name])
	VALUES (@SectionName);
END