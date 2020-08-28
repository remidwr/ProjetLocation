CREATE PROCEDURE [dbo].[CSP_UpdateUserPassword]
	@UserId INT,
	@Passwd NVARCHAR(20)
AS
BEGIN
	IF NOT EXISTS(SELECT Passwd FROM Users WHERE Passwd = @Passwd AND [User_Id] = @UserId)
		BEGIN
			UPDATE Users
			SET Passwd = HASHBYTES('SHA2_512', dbo.GetPreSalt() + @Passwd + dbo.GetPostSalt())
			WHERE [User_Id] = @UserId;
		END
	ELSE
		BEGIN
			RAISERROR('SamePasswordThanPrevious', 16, 1);
		END
END
