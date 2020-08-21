CREATE TABLE [dbo].[Section]
(
	[Section_Id] INT NOT NULL IDENTITY, 
    [Section_Name] NVARCHAR(50) NOT NULL, 
    CONSTRAINT [PK_Section] PRIMARY KEY ([Section_Id]), 
    CONSTRAINT [UK_Section_Name] UNIQUE ([Section_Name]) 
)
