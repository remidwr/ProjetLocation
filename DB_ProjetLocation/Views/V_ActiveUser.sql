CREATE VIEW [dbo].[V_ActiveUser]
	AS 
	SELECT [User_Id],
		   LastName,
		   FirstName,
		   Birthdate,
		   Email,
		   Passwd,
		   Street,
		   Number,
		   Box,
		   PostCode,
		   City,
		   Phone1,
		   Phone2,
		   Picture,
		   IsAdmin
	FROM Users
	WHERE IsActive = 1;