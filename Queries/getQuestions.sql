DROP PROC IF EXISTS getQuestions
USE [LingoLearn]
GO
CREATE PROC getQuestions (@quiz_id int)
AS
	SELECT quiz_id, id as question_id, question_text, text as answer, type, country_code, designation, score
		FROM QUESTION JOIN ANSWER ON QUESTION.id=ANSWER.question_id
		WHERE quiz_id=@quiz_id
GO