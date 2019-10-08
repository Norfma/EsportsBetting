CREATE PROCEDURE [dbo].[InsertUser]
	@Username nvarchar(50),
	@Hash nvarchar(max),
	@Salt nvarchar(50)
AS
	insert into [User](Username, Hashpwd, Salt, Active) values (@Username, @Hash, @Salt, 1)
RETURN 0
