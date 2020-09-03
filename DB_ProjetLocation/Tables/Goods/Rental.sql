CREATE TABLE [dbo].[Rental]
(
	[Rental_Id] INT NOT NULL IDENTITY, 
    [Good_Id] INT NOT NULL, 
    [User_Id] INT NOT NULL, 
    [CreationDate] DATETIME NOT NULL,
    [RentedFrom] DATETIME NOT NULL, 
    [RentedTo] DATETIME NOT NULL, 
    [Amount] FLOAT NOT NULL,
    [Deposit] FLOAT NULL,
    [Rating] INT NULL, 
    [Review] NVARCHAR(MAX) NULL, 
    CONSTRAINT [PK_Rental] PRIMARY KEY ([Rental_Id], [Good_Id], [User_Id]), 
    CONSTRAINT [FK_Rental_ToUsers] FOREIGN KEY ([User_Id]) REFERENCES [Users]([User_Id]), 
    CONSTRAINT [FK_Rental_ToGood] FOREIGN KEY ([Good_Id]) REFERENCES [Good]([Good_Id]) 
)