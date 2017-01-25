CREATE TABLE [dbo].[sessions]
(
	[SessionUuid] VARCHAR(36) NOT NULL PRIMARY KEY NONCLUSTERED,
	[SessionName] VARCHAR(100),
	[SessionDate] VARCHAR(10),
	[SessionNotes] VARCHAR(500),
	[SessionDuration] INTEGER,
	[SessionCount] INTEGER,
	[SessionIsFinished] BIT,
	[SessionCreator] VARCHAR(36), 
	[SessionTarget] VARCHAR(36),
	[SessionLastModified] BIGINT,
	CONSTRAINT FK_session_creator FOREIGN KEY (SessionCreator)
		REFERENCES [dbo].[users] (UserUuid)
)
