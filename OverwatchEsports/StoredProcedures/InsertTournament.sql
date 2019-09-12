CREATE PROCEDURE [dbo].[InsertTournament]
	@Id INT, 
    @LeagueName NVARCHAR(50), 
    @SeriesFullName NVARCHAR(50), 
    @Name NVARCHAR(50), 
    @ImageURL NVARCHAR(MAX) NULL, 
    @BeginAt DATETIME2 NULL, 
    @EndAt DATETIME2 NULL, 
    @Prizepool INT NULL
AS
	begin transaction
	set transaction isolation level read committed
		if (not Exists(Select * from Tournament where Id = @Id))
			begin
				INSERT INTO Tournament 
				VALUES(@Id, @LeagueName, @SeriesFullName, @Name, @ImageURL, @BeginAt, @EndAt, @Prizepool)
			end
		else
			begin
				exec UpdateTournament @Id, @ImageURL, @BeginAt, @EndAt, @Prizepool
			end
	commit
RETURN 0
