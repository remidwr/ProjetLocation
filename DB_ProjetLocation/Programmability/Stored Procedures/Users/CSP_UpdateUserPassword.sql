CREATE PROCEDURE [dbo].[CSP_UpdateUserPassword]
	@UserId INT,
	@PreviousPasswd NVARCHAR(20),
	@NewPasswd NVARCHAR(20)
AS
BEGIN
	UPDATE Users
	SET Passwd = HASHBYTES('SHA2_512', dbo.GetPreSalt() + @NewPasswd + dbo.GetPostSalt())
	WHERE [User_Id] = @UserId;
END
