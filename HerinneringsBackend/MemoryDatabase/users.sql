CREATE TABLE [dbo].[users]
(
	[UserUuid] VARCHAR(36) NOT NULL PRIMARY KEY NONCLUSTERED,
	[UserFirstName] VARCHAR(100),
	[UserLastName] VARCHAR(100),
	[UserName] VARCHAR(100),
	[UserPassword] VARCHAR(32),
	[UserQuestion1] VARCHAR(100),
	[UserQuestion2] VARCHAR(100),
	[UserAnswer1] VARCHAR(50),
	[UserAnswer2] VARCHAR(50),

)
