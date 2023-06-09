DROP PROC IF EXISTS addLanguage
USE [LingoLearn]
GO

CREATE PROCEDURE addLanguage (@id int, @designation VARCHAR(40))
AS
	INSERT INTO TEACHES_LANGUAGE
	VALUES (@designation, (SELECT country_code FROM LANGUAGE WHERE designation = @designation), @id)
GO