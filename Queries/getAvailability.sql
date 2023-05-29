DROP PROC IF EXISTS getAvailability
USE [LingoLearn]
GO

CREATE PROCEDURE getAvailability (@id int)
AS
	SELECT available FROM TEACHER
	WHERE id = @id
GO