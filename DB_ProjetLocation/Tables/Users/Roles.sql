CREATE TABLE [dbo].[Roles]
(
	[Role_Id] INT NOT NULL IDENTITY, 
    [RoleName] NVARCHAR(50) NOT NULL, 
    CONSTRAINT [PK_Roles] PRIMARY KEY ([Role_Id]), 
    CONSTRAINT [UK_Roles_RoleName] UNIQUE ([RoleName]) 
)
