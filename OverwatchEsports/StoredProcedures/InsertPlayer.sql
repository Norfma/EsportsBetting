CREATE PROCEDURE [dbo].[InsertPlayer]
	@Id int,
	@Name nvarchar(20),
	@TeamId int null,
	@ImageURL nvarchar(max) null
AS
	if (not Exists(Select * from Player where Id = @Id))
		begin
			INSERT INTO Player 
			VALUES(@Id, @Name, @TeamId, @ImageURL)
		end
	else
		begin
			exec UpdatePlayer @Id, @Name, @TeamId, @ImageURL
		end
RETURN 0
