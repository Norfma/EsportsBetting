CREATE PROCEDURE [dbo].[InsertTeam]
	@Id int,
	@Name nvarchar(50),
	@Acronym nvarchar(10),
	@ImageURL nvarchar(max) null
AS
begin transaction
set transaction isolation level read committed
	if (not Exists(Select * from Team where Id = @Id))
		begin
			INSERT INTO Team 
			VALUES(@Id, @Name, @Acronym, @ImageURL)
		end
	else
		begin
			exec UpdateTeam @Id, @Name, @Acronym, @ImageURL
		end
RETURN 0