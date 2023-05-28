DROP PROC IF EXISTS setUserAnsweredQuiz
USE [LingoLearn]
GO
CREATE PROC setUserAnsweredQuiz (@user_id int, @quiz_id int)
AS
	INSERT INTO QUIZES_ANSWERED VALUES
	(@user_id, @quiz_id)
GO
