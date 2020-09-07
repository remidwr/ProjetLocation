CREATE VIEW [dbo].[V_Good]
	AS 
	SELECT Good_Id,
		   Good_Name,
		   [Description],
		   [State],
		   AmountPerDay,
		   AmountPerWeek,
		   AmountPerMonth,
		   Street,
		   Number,
		   Box,
		   PostCode,
		   City,
		   Picture,
		   [User_Id],
		   Section_Id,
		   Category_Id
	FROM Good
