CREATE PROCEDURE [dbo].[UpdateMap]
	@Id int,
	@Name nvarchar(50),
	@GameMode nvarchar(50),
	@ImageURL nvarchar(max)

AS
	Update Map set Name = @Name, GameMode = @GameMode, ImageURL = @ImageURL where Id = @Id
RETURN 0
