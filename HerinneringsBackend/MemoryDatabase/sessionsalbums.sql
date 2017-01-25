CREATE TABLE [dbo].[sessionsalbums]
(
	[SASession] VARCHAR(36) NOT NULL,
	[SAAlbum] VARCHAR(36) NOT NULL,
	CONSTRAINT PK_sessionsalbums PRIMARY KEY NONCLUSTERED (SASession, SAAlbum),
	CONSTRAINT FK_session_albums FOREIGN KEY (SASession)
		REFERENCES [dbo].[sessions] (SessionUuid),
	CONSTRAINT FK_album_sessions FOREIGN KEY (SAAlbum)
		REFERENCES [dbo].[albums] (AlbumUuid),
)
