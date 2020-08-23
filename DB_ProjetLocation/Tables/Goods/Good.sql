﻿CREATE TABLE [dbo].[Good]
(
	[Good_Id] INT NOT NULL IDENTITY, 
    [Good_Name] NVARCHAR(50) NOT NULL, 
    [Description] NVARCHAR(MAX) NOT NULL, 
    [State] NVARCHAR(50) NOT NULL, 
    [Picture] NVARCHAR(320) NOT NULL, 
    [User_Id] INT NOT NULL, 
    [Address_Id] INT NOT NULL, 
    [Section_Id] INT NOT NULL, 
    CONSTRAINT [PK_Good] PRIMARY KEY ([Good_Id]), 
    CONSTRAINT [FK_Good_ToUsers] FOREIGN KEY ([User_Id]) REFERENCES [Users]([User_Id]), 
    CONSTRAINT [FK_Good_ToAddress] FOREIGN KEY ([Address_Id]) REFERENCES [Address]([Address_Id]), 
    CONSTRAINT [FK_Good_ToSection] FOREIGN KEY ([Section_Id]) REFERENCES [Section]([Section_Id]) 
)