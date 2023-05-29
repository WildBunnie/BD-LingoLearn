DROP PROC IF EXISTS getDesignations
USE [LingoLearn]
GO
CREATE PROCEDURE getDesignations (@id int)
AS
	SELECT designation FROM TEACHER 
	JOIN TEACHES_LANGUAGE ON id = teacher_id
	WHERE id = @id
GO