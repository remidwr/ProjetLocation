CREATE PROCEDURE [dbo].[Login]
	@Email NVARCHAR(320),
	@Passwd NVARCHAR(20)
AS
BEGIN
	SELECT [User_Id], [LastName], [FirstName], [Birthdate], [Email], [Passwd], [Phone1], [Phone2], [Picture], [Admin], [Active] 
	FROM [Users]
	WHERE Email = @Email AND Passwd = HASHBYTES('SHA2_512', dbo.GetPreSalt() + @Passwd + dbo.GetPostSalt());
END