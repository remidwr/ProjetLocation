CREATE PROCEDURE [dbo].[CSP_UpdateUserBanned]
	@UserId INT,
	@IsBanned BIT
AS
BEGIN
	UPDATE Users
	SET IsBanned = @IsBanned,
		IsActive = 0
	WHERE [User_Id] = @UserId;
END