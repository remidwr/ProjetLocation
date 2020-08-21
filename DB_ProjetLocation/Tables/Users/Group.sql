CREATE TABLE [dbo].[Group]
(
	[Group_Id] INT NOT NULL IDENTITY, 
    [Group_Name] NVARCHAR(50) NOT NULL, 
    CONSTRAINT [PK_Group] PRIMARY KEY ([Group_Id]), 
    CONSTRAINT [UK_Group_Name] UNIQUE ([Group_Name]) 
)
