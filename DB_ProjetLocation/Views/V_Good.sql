CREATE VIEW [dbo].[V_Good]
	AS 
	SELECT Good_Id,
		   Good_Name,
		   [Description],
		   [State],
		   AmountPerDay,
		   AmountPerWeek,
		   AmoutPerMonth,
		   Street,
		   Number,
		   Box,
		   PostCode,
		   City,
		   Picture,
		   [User_Id],
		   Section_Id
	FROM Good
