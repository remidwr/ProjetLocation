CREATE TABLE [dbo].[MTM_Users_Address]
(
	[User_Id] INT NOT NULL, 
    [Address_Id] INT NOT NULL, 
    CONSTRAINT [PK_MTM_Users_Address] PRIMARY KEY ([User_Id], [Address_Id]) 
)
