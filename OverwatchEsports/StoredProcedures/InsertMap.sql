CREATE PROCEDURE [dbo].[InsertMap]
	@Id int,
	@Name nvarchar(50),
	@GameMode nvarchar(50),
	@ImageURL nvarchar(max)
AS
	if (not Exists(Select * from Map where Id = @Id))
		begin
			INSERT INTO Map
			VALUES(@Id, @Name, @GameMode, @ImageURL)
		end
	else
		begin
			exec UpdateMap @Id, @Name, @GameMode, @ImageURL
		end
RETURN 0
