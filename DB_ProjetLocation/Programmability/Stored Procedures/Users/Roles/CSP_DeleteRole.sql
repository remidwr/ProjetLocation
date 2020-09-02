CREATE PROCEDURE [dbo].[CSP_DeleteRole]
	@RoleId INT
AS
BEGIN
	DELETE FROM Roles
	WHERE Role_Id = @RoleId;
END