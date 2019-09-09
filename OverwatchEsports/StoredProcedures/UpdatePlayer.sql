CREATE PROCEDURE [dbo].[UpdatePlayer]
	@PlayerId int = 0,
	@Name nvarchar(50),
	@TeamId int,
	@ImageURL nvarchar(max)
AS
	Update Player set [Name] = @Name, [TeamId] = @TeamId, [ImageURL] = @ImageURL where Id = @PlayerId
RETURN 0
