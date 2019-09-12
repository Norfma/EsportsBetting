CREATE PROCEDURE [dbo].[UpdatePlayer]
	@Id int = 0,
	@Name nvarchar(50),
	@TeamId int,
	@ImageURL nvarchar(max)
AS
	begin transaction
	set transaction isolation level read committed
		Update Player set [Name] = @Name, [TeamId] = @TeamId, [ImageURL] = @ImageURL where Id = @Id
	commit
RETURN 0
