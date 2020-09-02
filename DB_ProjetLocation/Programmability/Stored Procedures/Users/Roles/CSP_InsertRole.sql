CREATE PROCEDURE [dbo].[CSP_InsertRole]
	@RoleName NVARCHAR(50)
AS
BEGIN
	IF NOT EXISTS(SELECT Role_Id FROM Roles WHERE RoleName = @RoleName)
		BEGIN
			INSERT INTO Roles (RoleName)
			VALUES (@RoleName);
		END
	ELSE
		BEGIN
			RAISERROR('UK_Roles_RoleName', 16, 1);
		END
END