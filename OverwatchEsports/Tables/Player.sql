CREATE TABLE [dbo].[Player]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(20) NOT NULL, 
    [TeamId] INT NULL, 
	[ImageURL] NVARCHAR(MAX) NULL, 
    constraint fk_PlayerToTeam foreign key (TeamId) references Team(Id)
)
