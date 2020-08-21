CREATE TABLE [dbo].[Address]
(
	[Address_Id] INT NOT NULL, 
    [Street] NVARCHAR(120) NOT NULL, 
    [Number] NVARCHAR(10) NOT NULL, 
    [Box] NVARCHAR(10) NULL, 
    [PostCode] INT NOT NULL, 
    [City] NVARCHAR(120) NOT NULL, 
    CONSTRAINT [PK_Address] PRIMARY KEY ([Address_Id]) 
)
