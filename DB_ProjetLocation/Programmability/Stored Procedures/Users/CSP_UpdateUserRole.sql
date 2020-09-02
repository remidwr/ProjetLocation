CREATE PROCEDURE [dbo].[CSP_UpdateUserRole]
	@UserId INT,
	@RoleId INT
AS
BEGIN
	UPDATE Users
	SET Role_Id = @RoleId
	WHERE [User_Id] = @UserId;
END