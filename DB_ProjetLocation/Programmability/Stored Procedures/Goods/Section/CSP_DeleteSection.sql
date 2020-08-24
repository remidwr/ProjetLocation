CREATE PROCEDURE [dbo].[CSP_DeleteSection]
	@SectionId INT
AS
BEGIN
	DELETE FROM Section
	WHERE Section_Id = @SectionId;
END