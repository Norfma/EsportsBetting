CREATE PROCEDURE [dbo].[GetGamesFromMatch]
	@MatchId int
AS
	SELECT * from Game where MatchId = @MatchId
RETURN 0
