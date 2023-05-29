DROP PROC IF EXISTS getProfessorQuizzes
USE [LingoLearn]
GO
CREATE PROCEDURE getProfessorQuizzes (@id int)
AS
	SELECT QUIZ.name, Quiz."type", Quiz.designation, quiz_id, count(QUESTION.id) as n_questions FROM QUESTION 
		JOIN QUIZ ON QUIZ.id = quiz_id 
		WHERE creator_id = @id 
		GROUP BY quiz.name, quiz_id, Quiz."type", Quiz.designation
GO