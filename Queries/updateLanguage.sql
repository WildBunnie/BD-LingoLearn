DROP PROC IF EXISTS updateLanguage
USE [LingoLearn]
GO
-- NOT WORKING YET
CREATE PROCEDURE updateLanguage (@id int, @designation VARCHAR(40))
AS
	UPDATE "USER"
	SET "password" = @password
	WHERE id = @id
GO


