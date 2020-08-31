CREATE PROCEDURE [dbo].[CSP_UpdateRole]
	@RoleId INT,
	@RoleName NVARCHAR(50)
AS
BEGIN
	IF EXISTS(SELECT Role_Id FROM Roles WHERE Role_Id = @RoleId)
		BEGIN
			UPDATE Roles
			SET RoleName = @RoleName
			WHERE Role_Id = @RoleId;
		END
	ELSE
		BEGIN
			RAISERROR('RoleNotFound', 16, 1);
		END
END