CREATE TABLE [dbo].[memories]
(
	[MemoryUuid] VARCHAR(36) NOT NULL PRIMARY KEY NONCLUSTERED,
	[MemoryName] VARCHAR(100) NOT NULL,
	[MemoryDescription] VARCHAR(600),
	[MemoryDate] VARCHAR(10),
	[MemoryRating] INTEGER,
	[MemoryLocationLat] FLOAT,
	[MemoryLocationLong] FLOAT,
	[MemoryLocationName] VARCHAR(100),
	[MemoryPath] VARCHAR(500),
	[MemoryType] VARCHAR(50),
	[MemoryCreator] VARCHAR(36) NOT NULL,
	[MemoryTarget] VARCHAR(36),
	[MemoryLastModified] BIGINT,
	CONSTRAINT FK_memory_creator FOREIGN KEY (MemoryCreator)
		REFERENCES [dbo].[users] (UserUuid)
)
