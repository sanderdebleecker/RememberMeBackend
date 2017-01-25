CREATE TABLE [dbo].[timelines]
(
	[TimelineUuid] VARCHAR(36) NOT NULL PRIMARY KEY NONCLUSTERED,
	[TimelineMemory] VARCHAR(36) NOT NULL,
	[TimelineUser] VARCHAR(36) NOT NULL,
	[TimelineLastModified] BIGINT,
	CONSTRAINT FK_timeline_memories FOREIGN KEY (TimelineMemory)
		REFERENCES [dbo].[memories] (MemoryUuid),
	CONSTRAINT FK_timeline_users FOREIGN KEY (TimelineUser)
		REFERENCES [dbo].[users] (UserUuid),
)
