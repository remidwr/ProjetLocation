CREATE PROCEDURE [dbo].[CSP_DeleteUser]
	@UserId INT
AS
BEGIN
	DELETE Users
	WHERE [User_Id] = @UserId
END
