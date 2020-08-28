CREATE PROCEDURE [dbo].[CSP_DeleteUser]
	@UserId INT
AS
BEGIN
	IF EXISTS(SELECT [User_Id] FROM Users WHERE [User_Id] = @UserId)
		BEGIN
			DELETE FROM Users
			WHERE [User_Id] = @UserId;
		END
	ELSE
		BEGIN
			RAISERROR('UserNotFound', 16, 1);
		END
END
