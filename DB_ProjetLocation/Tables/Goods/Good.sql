CREATE TABLE [dbo].[Good]
(
	[Good_Id] INT NOT NULL IDENTITY, 
    [Good_Name] NVARCHAR(50) NOT NULL, 
    [Description] NVARCHAR(MAX) NOT NULL, 
    [State] NVARCHAR(50) NOT NULL, 
    [Amount] FLOAT NOT NULL, 
    [Street] NVARCHAR(120) NOT NULL, 
    [Number] NVARCHAR(10) NOT NULL, 
    [Box] NVARCHAR(10) NULL, 
    [PostCode] INT NOT NULL, 
    [City] NVARCHAR(120) NOT NULL, 
    [Picture] NVARCHAR(320) NOT NULL, 
    [User_Id] INT NOT NULL,
    [Section_Id] INT NOT NULL, 
    [Category_Id] INT NOT NULL, 
    [IsActive] BIT NOT NULL DEFAULT 1, 
    CONSTRAINT [PK_Good] PRIMARY KEY ([Good_Id]), 
    CONSTRAINT [FK_Good_ToUsers] FOREIGN KEY ([User_Id]) REFERENCES [Users]([User_Id]),
    CONSTRAINT [FK_Good_ToSection] FOREIGN KEY ([Section_Id]) REFERENCES [Section]([Section_Id]), 
    CONSTRAINT [FK_Good_ToCategory] FOREIGN KEY ([Category_Id]) REFERENCES [Category]([Category_Id]), 
    CONSTRAINT [CK_Good_Amount] CHECK ([Amount] > 0),
)

GO

CREATE INDEX [IX_Good_UserId] ON [dbo].[Good] ([User_Id])

GO

CREATE TRIGGER [dbo].[Trigger_Good]
    ON [dbo].[Good]
    FOR DELETE, INSERT, UPDATE
    AS
    BEGIN
        SET NoCount ON
    END