CREATE PROCEDURE [dbo].[CSP_UpdateUserPassword]
	@UserId INT,
	@Passwd NVARCHAR(20)
AS
BEGIN
	UPDATE Users
	SET Passwd = HASHBYTES('SHA2_512', dbo.GetPreSalt() + @Passwd + dbo.GetPostSalt())
	WHERE [User_Id] = @UserId;
END
