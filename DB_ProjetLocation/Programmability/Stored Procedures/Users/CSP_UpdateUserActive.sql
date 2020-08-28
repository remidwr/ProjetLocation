CREATE PROCEDURE [dbo].[CSP_UpdateUserActive]
	@UserId INT,
	@IsActive BIT
AS
BEGIN
	IF (@IsActive != (SELECT IsActive FROM Users WHERE [User_Id] = @UserId))
		BEGIN
			UPDATE Users
			SET IsActive = @IsActive
			WHERE [User_Id] = @UserId;
		END
	ELSE
		BEGIN
			RAISERROR('SameActiveStatus', 16, 1);
		END
END