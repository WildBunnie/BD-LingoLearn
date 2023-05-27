DROP PROC IF EXISTS addAnswer
USE [LingoLearn]
GO

CREATE PROCEDURE addAnswer (@score int, @answer_text VARCHAR(500), @question_id int)
AS
	INSERT INTO ANSWER VALUES
	-- score, text, question_id
	(@score, @answer_text, @question_id)

GO