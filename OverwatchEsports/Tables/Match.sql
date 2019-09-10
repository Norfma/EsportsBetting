CREATE TABLE [dbo].[Match]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Team1Id] INT NOT NULL, 
    [Team2Id] INT NOT NULL, 
    [TournamentId] INT NOT NULL, 
    [BeginAt] DATETIME2 NULL, 
    [EndAt] DATETIME2 NULL, 
    [Draw] BIT NOT NULL DEFAULT 1, 
    [Forfeit] BIT NOT NULL DEFAULT 1, 
    [MatchType] NVARCHAR(50) NULL DEFAULT 'best_of', 
    [NumberOfGames] int NULL, 
    CONSTRAINT [FK_Match_ToTeam1] FOREIGN KEY (Team1Id) REFERENCES Team(Id),
    CONSTRAINT [FK_Match_ToTeam2] FOREIGN KEY (Team2Id) REFERENCES Team(Id),
    CONSTRAINT [FK_Match_ToTournament] FOREIGN KEY (TournamentId) REFERENCES Tournament(Id)

)
