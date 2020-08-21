CREATE TABLE [dbo].[Users]
(
	[User_Id] INT NOT NULL IDENTITY, 
    [LastName] NVARCHAR(50) NOT NULL, 
    [FirstName] NVARCHAR(50) NOT NULL, 
    [Birthdate] DATE NOT NULL, 
    [Email] NVARCHAR(320) NOT NULL, 
    [Passwd] BINARY(64) NOT NULL, 
    [Phone1] NVARCHAR(50) NULL, 
    [Phone2] NVARCHAR(50) NULL, 
    [Picture] NVARCHAR(320) NULL, 
    [Active] BIT NOT NULL DEFAULT 1, 
    [Group_Id] INT NOT NULL, 
    CONSTRAINT [PK_Users] PRIMARY KEY ([User_Id]), 
    CONSTRAINT [UK_Users_Email] UNIQUE ([Email]),
    CONSTRAINT [FK_Users_Group] FOREIGN KEY ([Group_Id]) REFERENCES [Group]([Group_Id])
)

GO

CREATE TRIGGER [dbo].[Trigger_Users_Delete]
    ON [dbo].[Users]
    FOR DELETE
    AS
    BEGIN
        SET NoCount ON
        UPDATE Users
        SET Active = 0
    END
GO
