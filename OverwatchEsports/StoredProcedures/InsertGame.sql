CREATE PROCEDURE [dbo].[InsertGame]
	@Id INT, 
    @MatchId INT NULL , 
    @WinnerId INT NULL, 
    @BeginAt DATETIME2 NULL, 
    @EndAt DATETIME2 NULL, 
    @Forfeit BIT, 
    @Finished BIT, 
    @MapId INT, 
    @Length INT NULL, 
    @Position INT, 
    @Status NVARCHAR(50)
AS
	begin transaction
	set transaction isolation level read committed
		if (not Exists(Select * from Game where Id = @Id))
			begin
				INSERT INTO Game(Id, MatchId, WinnerId, BeginAt, EndAt, Forfeit, Finished, MapId, [Length], Position, [Status])
				VALUES(@Id, @MatchId, @WinnerId, @BeginAt, @EndAt, @Forfeit, @Finished, @MapId, @Length, @Position, @Status)
			end
		else
			begin
				exec UpdateGame @Id, @WinnerId, @EndAt, @Forfeit, @Finished, @MapId, @Length, @Status
			end		.
	commit
RETURN 0
