CREATE PROCEDURE [dbo].[CSP_DeleteGood]
	@GoodId INT,
	@UserId INT
AS
BEGIN
	DELETE FROM Good
	WHERE Good_Id = @GoodId AND [User_Id] = @UserId;
END