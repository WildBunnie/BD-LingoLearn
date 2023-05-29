DROP PROC IF EXISTS removeLanguage
USE [LingoLearn]
GO

CREATE PROCEDURE removeLanguage (@id int, @designation VARCHAR(40))
AS
	INSERT INTO TEACHES_LANGUAGE
	VALUES (@designation, (SELECT country_code FROM LANGUAGE WHERE designation = @designation), @id)
GO