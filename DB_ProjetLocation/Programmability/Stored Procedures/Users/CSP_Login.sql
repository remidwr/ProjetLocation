CREATE PROCEDURE [dbo].[Login]
	@Email NVARCHAR(320),
	@Passwd NVARCHAR(20)
AS
BEGIN
	SELECT [User_Id], [LastName], [FirstName], [Birthdate], [Email], [Passwd], [Street], [Number], [Box], [PostCode], [City], [Phone1], [Phone2], [Picture], [IsActive], [IsAdmin]
	FROM [Users]
	WHERE Email = @Email AND Passwd = HASHBYTES('SHA2_512', dbo.GetPreSalt() + @Passwd + dbo.GetPostSalt());
END