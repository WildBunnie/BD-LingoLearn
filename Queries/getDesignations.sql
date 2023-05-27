DROP PROC IF EXISTS getDesignations
USE [LingoLearn]
GO
CREATE PROCEDURE getDesignations (@id int)
AS
	SELECT designation FROM TEACHER 
	JOIN KNOWS ON id = user_id 
	WHERE id = @id
GO