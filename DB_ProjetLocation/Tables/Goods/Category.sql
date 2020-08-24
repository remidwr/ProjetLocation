CREATE TABLE [dbo].[Category]
(
	[Category_Id] INT NOT NULL IDENTITY, 
    [Category_Name] NVARCHAR(50) NOT NULL, 
    [Section_Id] INT NOT NULL, 
    CONSTRAINT [PK_Category] PRIMARY KEY ([Category_Id]), 
    CONSTRAINT [FK_Category_ToSection] FOREIGN KEY ([Section_Id]) REFERENCES [Section]([Section_Id]), 
    CONSTRAINT [UK_Category_Name] UNIQUE ([Category_Name]) 
)
