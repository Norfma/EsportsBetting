CREATE PROCEDURE [dbo].[GetAvailableMatchesFromTournament]
(
	@UserId int,
	@TournamentId int,
	@Date datetime2
)
AS
begin transaction
	set transaction isolation level read committed
		select COUNT(*) 
			from Tournament 
			join Match on Tournament.Id = Match.TournamentId 
			where Tournament.Id = @TournamentId and Match.EndAt > @Date
		- (select count(*) from Bet 
			join Match on Bet.MatchId = Match.Id
			where Match.TournamentId = @TournamentId and Bet.UserId = @UserId and Match.EndAt > @Date)
commit
RETURN 0
