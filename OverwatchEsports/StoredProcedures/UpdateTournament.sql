CREATE PROCEDURE [dbo].[UpdateTournament]
	@Id int,
	@ImageURL nvarchar(max) null,
	@BeginDate datetime2 null,
	@EndDate datetime2 null,
	@Prizepool int null
AS
	begin transaction
	set transaction isolation level read committed
		UPDATE Tournament SET ImageURL = @ImageURL, BeginDate = @BeginDate, EndDate = @EndDate, 
		Prizepool = @Prizepool where Id = @Id
	commit
RETURN 0
