CREATE PROCEDURE [dbo].[UpdateMatch]
	@Id int,
	@BeginAt datetime2 null,
	@EndAt datetime2 null,
	@Draw bit,
	@Forfeit bit,
	@MatchType nvarchar(50) null,
	@NumberOfGames int null
AS
begin transaction
set transaction isolation level read committed
	UPDATE Match SET BeginAt = @BeginAt, EndAt = @EndAt, Draw = @Draw, Forfeit = @Forfeit,
	MatchType = @MatchType, NumberOfGames = @NumberOfGames where Id = @Id
RETURN 0
