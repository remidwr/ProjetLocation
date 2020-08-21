CREATE TABLE [dbo].[Role]
(
	[Role_Id] INT NOT NULL IDENTITY, 
    [Role_Name] NVARCHAR(50) NOT NULL, 
    CONSTRAINT [PK_Role] PRIMARY KEY ([Role_Id]), 
    CONSTRAINT [AK_Role_Name] UNIQUE ([Role_Name]) 
)
