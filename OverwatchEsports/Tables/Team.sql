CREATE TABLE [dbo].[Team]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Acronym] NVARCHAR(10) NOT NULL, 
    [Image_url] NVARCHAR(MAX) NULL
)
