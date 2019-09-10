CREATE TABLE [dbo].[Game]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [MatchId] INT NULL , 
    [WinnerId] INT NULL, 
    [BeginAt] DATETIME2 NULL, 
    [EndAt] DATETIME2 NULL, 
    [Forfeit] BIT NOT NULL DEFAULT 1, 
    [Finished] BIT NOT NULL DEFAULT 1, 
    [MapId] INT NOT NULL, 
    [Length] INT NULL, 
    [Position] INT NOT NULL, 
    [Status] NVARCHAR(50) NOT NULL
, 
    CONSTRAINT [FK_Game_ToMap] FOREIGN KEY (MapId) REFERENCES Map(Id), 
    CONSTRAINT [FK_Game_ToMatch] FOREIGN KEY (MatchId) REFERENCES [Match](Id), 
    CONSTRAINT [FK_Game_ToTeam] FOREIGN KEY (WinnerId) REFERENCES Team(Id))
