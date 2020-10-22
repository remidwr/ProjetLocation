CREATE PROCEDURE [dbo].[CSP_InsertRole]
	@RoleName NVARCHAR(50)
AS
BEGIN
	INSERT INTO Roles (RoleName)
	VALUES (@RoleName);
END