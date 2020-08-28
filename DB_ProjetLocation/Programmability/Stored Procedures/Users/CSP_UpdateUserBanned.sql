CREATE PROCEDURE [dbo].[CSP_UpdateUserBanned]
	@UserId INT,
	@IsBanned BIT
AS
BEGIN
	IF ((SELECT IsBanned FROM Users WHERE [User_Id] = @UserId) = 0)
		BEGIN
			UPDATE Users
			SET IsBanned = @IsBanned,
				IsActive = 0
			WHERE [User_Id] = @UserId;
		END
	ELSE
		BEGIN
			RAISERROR('UserAlreadyBanned', 16, 1);
		END
END