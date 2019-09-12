CREATE PROCEDURE [dbo].[UpdateMap]
	@Id int,
	@Name nvarchar(50),
	@GameMode nvarchar(50),
	@ImageURL nvarchar(max)

AS
begin transaction
set transaction isolation level read committed
	Update Map set Name = @Name, GameMode = @GameMode, ImageURL = @ImageURL where Id = @Id
RETURN 0
