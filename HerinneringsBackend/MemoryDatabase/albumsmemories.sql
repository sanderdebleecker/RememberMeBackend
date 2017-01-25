CREATE TABLE [dbo].[albumsmemories]
(
	[AMAlbum] VARCHAR(36) NOT NULL, 
	[AMMemory] VARCHAR(36) NOT NULL,
	CONSTRAINT PK_albumsmemories PRIMARY KEY NONCLUSTERED (AMAlbum, AMMemory),
	CONSTRAINT FK_album_memories FOREIGN KEY(AMAlbum)
		REFERENCES [dbo].[albums] (AlbumUuid),
	CONSTRAINT FK_memory_albums FOREIGN KEY(AMMemory)
		REFERENCES [dbo].[memories] (MemoryUuid)
)
