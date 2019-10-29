CREATE TABLE [dbo].[Bet]
(
	[UserId] INT, 
    [MatchId] INT, 
    [BettedWinner] INT NOT NULL,
	constraint [PK_Bet] Primary Key (UserId, MatchId)
)
