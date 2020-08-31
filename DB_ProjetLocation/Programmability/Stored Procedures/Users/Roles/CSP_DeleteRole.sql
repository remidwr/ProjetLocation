CREATE PROCEDURE [dbo].[CSP_DeleteRole]
	@RoleId INT
AS
BEGIN
	IF EXISTS(SELECT Role_Id FROM Roles WHERE Role_Id = @RoleId)
		BEGIN
			DELETE FROM Roles
			WHERE Role_Id = @RoleId;
		END
	ELSE
		BEGIN
			RAISERROR('RoleNotFound', 16, 1);
		END
END