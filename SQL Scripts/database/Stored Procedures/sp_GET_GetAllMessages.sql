USE [SensitiveWords.SanitizerDb]
GO
/****** Object:  StoredProcedure [dbo].[sp_GET_GetAllMessages]    Script Date: 25 Feb 2026 11:35:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create or ALTER   PROCEDURE [dbo].[sp_GET_GetAllMessages]
AS
BEGIN

    SELECT * FROM ClientMessages

END;
