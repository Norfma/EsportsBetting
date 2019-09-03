CREATE TABLE [dbo].[TeamTournamentRegister]
(
	[TeamId] INT NOT NULL , 
    [TournamentId] INT NOT NULL, 
    CONSTRAINT [PK_TeamTournamentRegister] PRIMARY KEY (TeamId, TournamentId), 
    CONSTRAINT [FK_TeamTournamentRegister_ToTeam] FOREIGN KEY (TeamId) REFERENCES Team(Id),
    CONSTRAINT [FK_TeamTournamentRegister_ToTournament] FOREIGN KEY (TournamentId) REFERENCES Tournament(Id)
)
