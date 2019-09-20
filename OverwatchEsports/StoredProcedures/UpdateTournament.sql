CREATE PROCEDURE [dbo].[UpdateTournament]
	@Id int,
	@ImageURL nvarchar(max) null,
	@BeginAt datetime2 null,
	@EndAt datetime2 null,
	@Prizepool NVARCHAR(50) null
AS
	begin transaction
	set transaction isolation level read committed
		UPDATE Tournament SET ImageURL = @ImageURL, BeginAt = @BeginAt, EndAt = @EndAt, 
		Prizepool = @Prizepool where Id = @Id
	commit
RETURN 0
