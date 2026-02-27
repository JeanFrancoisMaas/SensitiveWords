USE [SensitiveWords.SanitizerDb]
GO

/****** Object:  Table [dbo].[ClientMessages]    Script Date: 27 Feb 2026 08:58:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'ClientMessages')
BEGIN
	CREATE TABLE [dbo].[ClientMessages](
		[ClientMessageId] [bigint] IDENTITY(1,1) NOT NULL,
		[Message] [nvarchar](max) NOT NULL,
		[CreatedDate] [datetime] NOT NULL,
		[Active] [bit] NOT NULL,
		[SanitizedMessage] [nvarchar](max) NULL,
	 CONSTRAINT [PK_ClientMessages] PRIMARY KEY CLUSTERED 
	(
		[ClientMessageId] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
	) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

	ALTER TABLE [dbo].[ClientMessages] ADD  CONSTRAINT [DF_ClientMessages_Active]  DEFAULT ((0)) FOR [Active]

	INSERT INTO ClientMessages([Message], CreatedDate, Active, SanitizedMessage)
	VALUES ('Create a string', GETDATE(), 1, '***** a string')
END


