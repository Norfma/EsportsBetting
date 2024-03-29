﻿CREATE PROCEDURE [dbo].[InsertMatch]
	@Id int,
	@Team1Id INT, 
    @Team2Id INT, 
    @TournamentId INT, 
    @BeginAt DATETIME2 NULL, 
    @EndAt DATETIME2 NULL, 
    @Draw BIT, 
    @Forfeit BIT, 
    @MatchType NVARCHAR(50) NULL, 
    @NumberOfGames int NULL 
AS
	begin transaction
	set transaction isolation level read committed
		if (not Exists(Select * from [Match] where Id = @Id))
			begin
				INSERT INTO [Match] 
				VALUES(@Id, @Team1Id, @Team2Id, @TournamentId, @BeginAt, @EndAt, @Draw, @Forfeit, @MatchType, @NumberOfGames)
			end
		else
			begin
				exec UpdateMatch @Id, @BeginAt, @EndAt, @Draw, @Forfeit, @MatchType, @NumberOfGames
			end
	commit
RETURN 0
