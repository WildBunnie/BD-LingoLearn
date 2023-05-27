DROP PROC IF EXISTS addQuiz
USE [LingoLearn]
GO

CREATE PROCEDURE addQuiz (@quizType VARCHAR(20), @designation VARCHAR(40), @creator_id int)
AS
	DECLARE @country_code int
	SELECT @country_code = country_code FROM "LANGUAGE" WHERE designation = @designation

	INSERT INTO QUIZ VALUES
	(@quizType, @designation, @country_code, @creator_id)

	SELECT SCOPE_IDENTITY() as id
GO