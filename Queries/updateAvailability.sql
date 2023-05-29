DROP PROC IF EXISTS updateAvailability
USE [LingoLearn]
GO

CREATE PROCEDURE updateAvailability (@id int, @bool bit)
AS
	UPDATE "TEACHER"
	SET available = @bool
	WHERE id = @id
GO