DROP PROC IF EXISTS getScore
USE [LingoLearn]
GO
CREATE PROC getScore (@user_id int, @quiz_id int, @score int OUTPUT)
AS
	SELECT @score=sum(score)
		FROM (ANSWERS JOIN ANSWER ON ANSWERS.question_id = ANSWER.question_id AND ANSWERS.text = ANSWER.text) JOIN QUESTION ON QUESTION.id=ANSWER.question_id
		GROUP BY ANSWERS.user_id, QUESTION.quiz_id
		HAVING user_id=@user_id AND quiz_id=@quiz_id
GO
