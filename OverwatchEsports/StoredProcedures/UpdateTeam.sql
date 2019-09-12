CREATE PROCEDURE [dbo].[UpdateTeam]
	@Id int = 0,
	@Name nvarchar(50),
	@Acronym nvarchar(10),
	@ImageURL nvarchar(max)
AS
begin transaction
set transaction isolation level read committed
	Update Team set [Name] = @Name, Acronym = @Acronym, ImageURL = @ImageURL where Id = @Id
RETURN 0
