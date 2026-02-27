USE [SensitiveWords.SanitizerDb]
GO
/****** Object:  StoredProcedure [dbo].[sp_UPDATE_ToggleKeyWord]    Script Date: 25 Feb 2026 11:35:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create or ALTER   PROCEDURE [dbo].[sp_UPDATE_ToggleKeyWord](@sanitizerKeyWordId BIGINT)
AS
BEGIN

    UPDATE dbo.SanitizerKeyWords
    SET Active = ~Active
    WHERE SanitizerKeyWordId = @sanitizerKeyWordId;

	SELECT * FROM SanitizerKeyWords WHERE SanitizerKeyWordId = @sanitizerKeyWordId;

END;
