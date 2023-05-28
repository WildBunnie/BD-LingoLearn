DROP PROC IF EXISTS setUserAnswer
USE [LingoLearn]
GO
CREATE PROC setUserAnswer (@user_id int, @question_id int, @text varchar(500))
AS
	INSERT INTO ANSWERS VALUES
	(@user_id, @text, @question_id)
GO
