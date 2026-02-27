USE [SensitiveWords.SanitizerDb]
GO

/****** Object:  Table [dbo].[SanitizerKeyWords]    Script Date: 27 Feb 2026 08:59:07 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'SanitizerKeyWords')
BEGIN
	CREATE TABLE [dbo].[SanitizerKeyWords](
		[SanitizerKeyWordId] [bigint] IDENTITY(1,1) NOT NULL,
		[Description] [nvarchar](50) NOT NULL,
		[Active] [bit] NOT NULL
	) ON [PRIMARY]

	ALTER TABLE [dbo].[SanitizerKeyWords] ADD  CONSTRAINT [DF_SanitizerKeyWords_Active]  DEFAULT ((0)) FOR [Active]
END

