CREATE TABLE [dbo].[Game]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [MatchId] INT NULL, 
    [WinnerId] INT NULL, 
    [BeginAt] DATETIME NULL, 
    [EndAt] DATETIME NULL, 
    [Forfeit] BIT NOT NULL DEFAULT 1, 
    [Finished] BIT NOT NULL DEFAULT 1, 
    [MapId] INT NOT NULL, 
    [length] INT NULL, 
    [position] INT NOT NULL, 
    [status] NVARCHAR(50) NOT NULL
, 
    CONSTRAINT [FK_Game_ToMap] FOREIGN KEY (MapId) REFERENCES Map(Id), 
    CONSTRAINT [FK_Game_ToMatch] FOREIGN KEY (MatchId) REFERENCES [Match](Id), 
    CONSTRAINT [FK_Game_ToTeam] FOREIGN KEY (WinnerId) REFERENCES Team(Id))
