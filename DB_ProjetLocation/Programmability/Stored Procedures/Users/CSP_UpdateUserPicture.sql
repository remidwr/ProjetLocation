CREATE PROCEDURE [dbo].[CSP_UpdateUserPicture]
	@UserId INT,
	@Picture NVARCHAR(320)
AS
BEGIN
	UPDATE Users
	SET Picture = @Picture
	WHERE [User_Id] = @UserId;
END