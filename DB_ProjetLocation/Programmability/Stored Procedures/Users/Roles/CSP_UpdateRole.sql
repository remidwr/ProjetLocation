CREATE PROCEDURE [dbo].[CSP_UpdateRole]
	@RoleId INT,
	@RoleName NVARCHAR(50)
AS
BEGIN
	UPDATE Roles
	SET RoleName = @RoleName
	WHERE Role_Id = @RoleId;
END