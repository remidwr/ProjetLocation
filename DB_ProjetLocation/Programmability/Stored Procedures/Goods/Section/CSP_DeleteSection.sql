CREATE PROCEDURE [dbo].[CSP_DeleteSection]
	@SectionId INT
AS
BEGIN
	IF NOT EXISTS(SELECT Good_Id FROM Good WHERE Section_Id = @SectionId 
			OR Category_Id IN (SELECT Category_Id FROM Good WHERE Section_Id = @SectionId))
		BEGIN
			DELETE FROM Category
			WHERE Section_Id = @SectionId;
			DELETE FROM Section
			WHERE Section_Id = @SectionId;
		END
	ELSE
		RAISERROR('Unable To Delete Section', 16, 1);
END