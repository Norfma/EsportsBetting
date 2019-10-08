CREATE PROCEDURE [dbo].[DeleteBet]
	@userId int,
	@matchId int
AS
	delete from v_Bet where UserId = @userId and MatchId = @matchId
RETURN 0
