CREATE PROCEDURE [dbo].[CSP_UpdateRole]
	@RoleId INT,
	@RoleName NVARCHAR(50)
AS
BEGIN
	IF NOT EXISTS(SELECT Role_Id FROM Roles WHERE RoleName = @RoleName)
		BEGIN
			UPDATE Roles
			SET RoleName = @RoleName
			WHERE Role_Id = @RoleId;
		END
	ELSE
		BEGIN
			RAISERROR('UK_Roles_RoleName', 16, 1);
		END
END