CREATE PROCEDURE [dbo].[InsertTeamIntoTournament]
	@TeamId int,
	@TournamentId int
AS
begin transaction
set transaction isolation level read committed
if (not Exists(Select * from TeamTournamentRegister where TeamId = @TeamId and TournamentId = @TournamentId))
		begin
			INSERT INTO TeamTournamentRegister 
			VALUES (@TeamId, @TournamentId)
		end
RETURN 0
