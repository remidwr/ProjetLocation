CREATE PROCEDURE [dbo].[CSP_Login]
	@Email NVARCHAR(320),
	@Passwd NVARCHAR(20)
AS
BEGIN
	IF EXISTS(SELECT [User_Id] FROM Users WHERE Email = @Email AND IsBanned = 0 AND IsActive = 0)
		BEGIN
			RAISERROR('User_Inactive', 16, 1);
		END
	ELSE IF EXISTS(SELECT [User_Id] FROM Users WHERE Email = @Email AND IsBanned = 1 AND IsActive = 0)
		BEGIN
			RAISERROR('User_Banned', 16, 1);
		END
	ELSE
		BEGIN
			SELECT [User_Id], [LastName], [FirstName], [BirthDate], [Email], [Passwd], [Street], [Number], [Box], [PostCode], [City], [Phone1], [Phone2], [Picture], [IsActive], [IsBanned], [Role_Id]
			FROM Users
			WHERE Email = @Email AND Passwd = HASHBYTES('SHA2_512', dbo.GetPreSalt() + @Passwd + dbo.GetPostSalt());
		END
END