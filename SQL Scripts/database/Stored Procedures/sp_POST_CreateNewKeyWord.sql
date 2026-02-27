USE [SensitiveWords.SanitizerDb]
GO
/****** Object:  StoredProcedure [dbo].[sp_POST_CreateNewKeyWord]    Script Date: 25 Feb 2026 11:35:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create or ALTER   PROCEDURE [dbo].[sp_POST_CreateNewKeyWord](@Description NVARCHAR(100))
AS
BEGIN

    IF NOT EXISTS (
    SELECT 1
    FROM SanitizerKeyWords
    WHERE [Description] = @Description
	)
	BEGIN
		INSERT INTO SanitizerKeyWords ([Description], Active)
		VALUES (@Description, 1);
	END;

	SELECT * FROM SanitizerKeyWords WHERE [Description] = @Description;

END;
