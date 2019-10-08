CREATE PROCEDURE [dbo].[InsertBet]
	@userId int,
	@matchId int,
	@bettedWinner int
AS
	insert into Bet values(@userId, @matchId, @bettedWinner)
RETURN 0
