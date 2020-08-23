CREATE TABLE [dbo].[MTM_Users_Address]
(
	[User_Id] INT NOT NULL, 
    [Address_Id] INT NOT NULL, 
    CONSTRAINT [PK_MTM_Users_Address] PRIMARY KEY ([User_Id], [Address_Id]), 
    CONSTRAINT [FK_MTM_Users_Address_ToUsers] FOREIGN KEY ([User_Id]) REFERENCES [Users]([User_Id]), 
    CONSTRAINT [FK_MTM_Users_Address_ToAddress] FOREIGN KEY ([Address_Id]) REFERENCES [Address]([Address_Id]) 
)
