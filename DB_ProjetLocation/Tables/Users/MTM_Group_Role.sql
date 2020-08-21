CREATE TABLE [dbo].[MTM_Group_Role]
(
	[Group_Id] INT NOT NULL, 
    [Role_Id] INT NOT NULL, 
    CONSTRAINT [PK_MTM_Group_Role] PRIMARY KEY ([Group_Id], [Role_Id]) 
)
