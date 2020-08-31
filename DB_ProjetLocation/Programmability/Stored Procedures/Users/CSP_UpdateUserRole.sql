CREATE PROCEDURE [dbo].[CSP_UpdateUserRole]
	@UserId INT,
	@RoleId INT
AS
BEGIN
	IF EXISTS(SELECT [User_Id] FROM Users WHERE [User_Id] = @UserId)
		BEGIN
			UPDATE Users
			SET Role_Id = @RoleId
			WHERE [User_Id] = @UserId;
		END
	ELSE
		BEGIN
			RAISERROR('UserNotFound', 16, 1);
		END
END