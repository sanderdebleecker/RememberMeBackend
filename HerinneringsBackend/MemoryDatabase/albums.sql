CREATE TABLE [dbo].[albums]
(
	[AlbumUuid] VARCHAR(36) NOT NULL PRIMARY KEY NONCLUSTERED,
	[AlbumName] VARCHAR(100) NOT NULL,
	[AlbumThumbnail] VARCHAR(36),
	[AlbumCreator] VARCHAR(36) NOT NULL,
	[AlbumTarget] VARCHAR(36),
	[AlbumLastModified] BIGINT,
	CONSTRAINT FK_album_creator FOREIGN KEY (AlbumCreator)
		REFERENCES [dbo].[users] (UserUuid)
)
