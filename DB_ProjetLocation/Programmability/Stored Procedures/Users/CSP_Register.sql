CREATE PROCEDURE [dbo].[Register]
	@LastName NVARCHAR(50), 
    @FirstName NVARCHAR(50), 
    @Birthdate DATE, 
    @Email NVARCHAR(320), 
    @Passwd NVARCHAR(20)
AS
BEGIN
	INSERT INTO [Users] ([LastName], [FirstName], [Birthdate], [Email], [Passwd])
    VALUES (@LastName, @FirstName, @Birthdate, @Email, HASHBYTES('SHA2_512', dbo.GetPreSalt() + @Passwd + dbo.GetPostSalt()));
END