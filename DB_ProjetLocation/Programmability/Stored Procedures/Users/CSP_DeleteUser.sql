CREATE PROCEDURE [dbo].[CSP_DeleteUser]
	@UserId INT
AS
BEGIN
	IF NOT EXISTS(SELECT Rental_Id FROM Rental WHERE (Owner_Id = @UserId OR Tenant_Id = @UserId) AND RentedTo > GETDATE())
		BEGIN
			DELETE FROM Users
			WHERE [User_Id] = @UserId;
			DELETE FROM Good
			WHERE [User_Id] = @UserId;
		END
	ELSE
		BEGIN
			RAISERROR('User Linked To Current Rental', 16, 1);
		END
END