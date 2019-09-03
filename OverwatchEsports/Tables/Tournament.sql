CREATE TABLE [dbo].[Tournament]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [LeagueName] NVARCHAR(50) NOT NULL, 
    [SeriesFullName] NVARCHAR(50) NOT NULL, 
    [Name] NVARCHAR(50) NOT NULL, 
    [image_url] NVARCHAR(MAX) NULL, 
    [BeginDate] DATETIME2 NULL, 
    [EndDate] DATETIME2 NULL, 
    [Prizepool] INT NULL
)
