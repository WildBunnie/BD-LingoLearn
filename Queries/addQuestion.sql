DROP PROC IF EXISTS addQuestion
USE [LingoLearn]
GO

CREATE PROCEDURE addQuestion (@question_type VARCHAR(20), @question_text VARCHAR(300), @designation VARCHAR(40), @quiz_id int)
AS
	DECLARE @country_code int
	SELECT @country_code = country_code FROM "LANGUAGE" WHERE designation = @designation

	INSERT INTO QUESTION VALUES
	-- type, text, designation, country_code, quiz_id
	(@question_type, @question_text, @designation, @country_code, @quiz_id)

	SELECT SCOPE_IDENTITY() as id
GO