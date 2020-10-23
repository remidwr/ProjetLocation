CREATE PROCEDURE [dbo].[CSP_UpdateUserBanned]
	@UserId INT,
	@IsBanned BIT
AS
BEGIN
	IF (@IsBanned = 1)
		BEGIN
			UPDATE Users
			SET IsBanned = @IsBanned,
				IsActive = 0
			WHERE [User_Id] = @UserId;
		END
	ELSE IF (@IsBanned = 0)
		BEGIN
			UPDATE Users
			SET IsBanned = @IsBanned,
				IsActive = 1
			WHERE [User_Id] = @UserId;
		END
END