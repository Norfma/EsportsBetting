﻿CREATE TABLE [dbo].[Map]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [GameMode] NVARCHAR(50) NOT NULL, 
    [image_url] NVARCHAR(MAX) NOT NULL
)
