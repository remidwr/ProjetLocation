CREATE TABLE [dbo].[MTM_Group_Role]
(
	[Group_Id] INT NOT NULL, 
    [Role_Id] INT NOT NULL, 
    CONSTRAINT [PK_MTM_Group_Role] PRIMARY KEY ([Group_Id], [Role_Id]), 
    CONSTRAINT [FK_MTM_Group_Role_ToGroup] FOREIGN KEY ([Group_Id]) REFERENCES [Group]([Group_Id]), 
    CONSTRAINT [FK_MTM_Group_Role_ToRole] FOREIGN KEY ([Role_Id]) REFERENCES [Role]([Role_Id]) 
)
