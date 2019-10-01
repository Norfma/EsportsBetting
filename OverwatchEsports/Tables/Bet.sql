CREATE TABLE [dbo].[Bet]
(
	[UserId] INT, 
    [MatchId] NCHAR(10), 
    [BettedWinner] NCHAR(10) NOT NULL,
	constraint [PK_Bet] Primary Key (UserId, MatchId)
)
