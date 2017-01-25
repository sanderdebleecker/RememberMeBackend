CREATE TABLE [dbo].[albums]
(
	[AlbumUuid] VARCHAR(36) NOT NULL PRIMARY KEY NONCLUSTERED,
	[AlbumName] VARCHAR(100) NOT NULL,
	[AlbumCreator] VARCHAR(36) NOT NULL,
	[AlbumThumbnail] VARCHAR(36),
	CONSTRAINT FK_album_creator FOREIGN KEY (AlbumCreator)
		REFERENCES [dbo].[users] (UserUuid)
)
