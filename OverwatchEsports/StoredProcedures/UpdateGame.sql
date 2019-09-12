CREATE PROCEDURE [dbo].[UpdateGame]
	@Id int,
	@WinnerId int null,
	@EndAt datetime2 null,
	@Forfeit bit,
	@Finished bit,
	@MapId int,
	@Length int null,
	@Status nvarchar(50)
AS
begin transaction
set transaction isolation level read committed
	Update Game set WinnerId = @WinnerId, EndAt = @EndAt, Forfeit = @Forfeit, Finished = @Finished, 
	MapId = @MapId, Length = @Length, Status = @Status where Id = @Id
RETURN 0
