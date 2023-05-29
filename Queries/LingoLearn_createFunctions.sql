-- Query to create all Stored Procedures, Indexes and UFD's


DROP PROC IF EXISTS userFromCredentials
USE [LingoLearn]
GO
CREATE PROC userFromCredentials (@email varchar(40), @password varchar(40), @id int OUTPUT, @username varchar(40) OUTPUT)
AS
	SELECT @id = id, @username = username
		FROM "USER"
		WHERE email=@email AND "password"=@password

	-- return -1 if wrong email
	IF (SELECT count(*) FROM "USER" WHERE email = @email) < 1
	BEGIN
		RETURN -1
	END

	-- return -2 if wrong password
	-- if the email is corrent but id is null, then password is wrong
	IF @id IS NULL
	BEGIN
		RETURN -2
	END

	RETURN 1
GO


DROP PROC IF EXISTS setUserAnsweredQuiz
USE [LingoLearn]
GO
CREATE PROC setUserAnsweredQuiz (@user_id int, @quiz_id int)
AS
	INSERT INTO QUIZES_ANSWERED VALUES
	(@user_id, @quiz_id)
GO


DROP PROC IF EXISTS setUserAnswer
USE [LingoLearn]
GO
CREATE PROC setUserAnswer (@user_id int, @question_id int, @text varchar(500))
AS
	INSERT INTO ANSWERS VALUES
	(@user_id, @text, @question_id)
GO


DROP PROC IF EXISTS isTeacherOrStudent
USE [LingoLearn]
GO
CREATE PROC isTeacherOrStudent (@id int)
AS
	DECLARE @res int = 0

	IF (SELECT count(*) FROM LEARNER WHERE id = @id) >= 1
	BEGIN
		SET @res = 1
	END

	IF (SELECT count(*) FROM TEACHER WHERE id = @id) >= 1
	BEGIN
		IF @res = 1
		BEGIN
			SET @res = 3
		END
		ELSE
		BEGIN
			SET @res = 2
		END
	END

	-- 0 means neither, 1 means	learner, 2 means teacher, 3 means both
	RETURN @res
GO


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


DROP PROC IF EXISTS getQuizes
USE [LingoLearn]
GO
CREATE PROC getQuizes
AS
	SELECT QUIZ.id, user_id, type, TEACHER.teacher_name, designation
		FROM (QUIZES_ANSWERED RIGHT OUTER JOIN QUIZ ON QUIZ.id = QUIZES_ANSWERED.quiz_id) LEFT OUTER JOIN TEACHER ON TEACHER.id = creator_id
GO


DROP PROC IF EXISTS getQuestions
USE [LingoLearn]
GO
CREATE PROC getQuestions (@quiz_id int)
AS
	SELECT quiz_id, id as question_id, question_text, text as answer, type, country_code, designation, score
		FROM QUESTION JOIN ANSWER ON QUESTION.id=ANSWER.question_id
		WHERE quiz_id=@quiz_id
GO



DROP PROC IF EXISTS getProfessorQuizzes
USE [LingoLearn]
GO
CREATE PROCEDURE getProfessorQuizzes (@id int)
AS
	SELECT Quiz."name", Quiz."type", Quiz.designation, quiz_id, count(QUESTION.id) as n_questions FROM QUESTION 
		JOIN QUIZ ON QUIZ.id = quiz_id 
		WHERE creator_id = @id
		GROUP BY quiz_id, Quiz."type", Quiz.designation, Quiz."name"
GO


DROP PROC IF EXISTS getDesignations
USE [LingoLearn]
GO
CREATE PROCEDURE getDesignations (@id int)
AS
	SELECT designation FROM TEACHER 
	JOIN KNOWS ON id = user_id 
	WHERE id = @id
GO


DROP PROC IF EXISTS addUser
USE [LingoLearn]
GO
CREATE PROC addUser (@username varchar(40), @email varchar(40), @password varchar(40), @isLearner bit, @isTeacher bit)
AS
	BEGIN TRY
		INSERT INTO "USER" VALUES (@email, @username, @password)

		DECLARE @id int;
		SELECT @id = id
			FROM "USER"
			WHERE email=@email

		IF @isLearner = 1
		BEGIN
			INSERT INTO LEARNER VALUES (@id, 0)
		END

		IF @isTeacher = 1
		BEGIN
			INSERT INTO TEACHER VALUES (@id, 0, @username)
		END

		RETURN 1
	END TRY
	BEGIN CATCH
		RETURN 0
	END CATCH
GO



DROP PROC IF EXISTS addQuiz
USE [LingoLearn]
GO

CREATE PROCEDURE addQuiz (@quizName VARCHAR(20), @quizType VARCHAR(20), @designation VARCHAR(40), @creator_id int)
AS
	DECLARE @country_code int
	SELECT @country_code = country_code FROM "LANGUAGE" WHERE designation = @designation

	INSERT INTO QUIZ VALUES
	(@quizName, @quizType, @designation, @country_code, @creator_id)

	SELECT SCOPE_IDENTITY() as id
GO



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




DROP PROC IF EXISTS addAnswer
USE [LingoLearn]
GO

CREATE PROCEDURE addAnswer (@score int, @answer_text VARCHAR(500), @question_id int)
AS
	INSERT INTO ANSWER VALUES
	-- score, text, question_id
	(@score, @answer_text, @question_id)

GO