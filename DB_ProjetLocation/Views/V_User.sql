CREATE VIEW [dbo].[V_User]
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
		   IsActive,
		   IsBanned,
		   Role_Id
	FROM Users
