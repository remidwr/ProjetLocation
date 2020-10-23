CREATE PROCEDURE [dbo].[CSP_Register]
	@LastName NVARCHAR(50), 
    @FirstName NVARCHAR(50), 
    @BirthDate DATE, 
    @Email NVARCHAR(320), 
    @Passwd NVARCHAR(20)
AS
BEGIN
    IF EXISTS(SELECT Email FROM Users WHERE Email = @Email AND IsActive = 0 AND IsBanned = 0)
        BEGIN
            UPDATE Users
            SET IsActive = 1
            WHERE [User_Id] = (SELECT [User_Id] FROM Users WHERE Email = @Email);
            UPDATE Good
            SET IsActive = 1
            WHERE [User_Id] = (SELECT [User_id] FROM Users WHERE Email = @Email);
        END
    ELSE IF EXISTS(SELECT Email FROM Users WHERE Email = @Email AND IsActive = 0 AND IsBanned = 1)
        BEGIN
            RAISERROR('User_Banned', 16, 1);
        END
    ELSE
        BEGIN
	        INSERT INTO [Users] ([LastName], [FirstName], [BirthDate], [Email], [Passwd])
            VALUES (@LastName, @FirstName, @BirthDate, @Email, HASHBYTES('SHA2_512', dbo.GetPreSalt() + @Passwd + dbo.GetPostSalt()));
        END
END