USE [LingoLearn]
GO

CREATE PROCEDURE getAllQuizzes (@id int, @language VARCHAR(40))
AS
	SELECT id, "type", designation, creator_id
		FROM QUIZ JOIN 
			(SELECT * FROM TEACHES_STUDENTS WHERE learner_id = @id) AS Teach_Students 
				ON creator_id = Teach_Students.teacher_id OR creator_id IS NULL WHERE designation = @language
GO

CREATE PROCEDURE getAnsweredQuizzes (@id int)
AS
	SELECT * FROM QUIZES_ANSWERED WHERE user_id = @id
GO

CREATE PROCEDURE getAnswerOptions (@questionID int)
AS
	SELECT * FROM ANSWER where question_id = @questionID 
GO

CREATE PROCEDURE getQuestions (@quizID int)
AS
	SELECT * FROM QUESTION WHERE quiz_id = @quizID
GO

CREATE PROCEDURE saveAnswer (@id int, @quizID int)
AS
	INSERT INTO QUIZES_ANSWERED
	VALUES (@id, @quizID)
GO