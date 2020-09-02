CREATE PROCEDURE [dbo].[CSP_UpdateUserActive]
	@UserId INT,
	@IsActive BIT
AS
BEGIN
	UPDATE Users
	SET IsActive = @IsActive
	WHERE [User_Id] = @UserId;
END