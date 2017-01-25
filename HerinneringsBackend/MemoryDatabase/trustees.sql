CREATE TABLE [dbo].[trustees]
(
	[TrusteeSource] VARCHAR(36),
	[TrusteeDestination] VARCHAR(36),
	[TrusteeConfirmed] BIT,
	CONSTRAINT PK_trustees PRIMARY KEY NONCLUSTERED (TrusteeSource, TrusteeDestination),

)
