﻿CREATE PROCEDURE [dbo].[CSP_DeleteGood]
	@GoodId INT
AS
BEGIN
	DELETE FROM Good
	WHERE Good_Id = @GoodId;
END