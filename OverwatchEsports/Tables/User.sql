CREATE TABLE [dbo].[User]
(
	[Id] INT IDENTITY, 
    [Username] NVARCHAR(50) NOT NULL, 
    [Hashpwd] NVARCHAR(MAX) NOT NULL, 
    [Salt] NVARCHAR(50) NULL, 
    [Active] BIT NOT NULL DEFAULT 0, 
    CONSTRAINT [PK_User] PRIMARY KEY (Id)
)
