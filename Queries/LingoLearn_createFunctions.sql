-- Query to create all Stored Procedures, Indexes and UFD's


DROP PROC IF EXISTS userFromCredentials
USE [LingoLearn]
GO
CREATE PROC userFromCredentials (@email varchar(40), @password varchar(40), @id int OUTPUT, @username varchar(40) OUTPUT, @role int OUTPUT)
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

	-- set the role
	-- 1 for learner or 2 for teacher
	IF (SELECT count(*) FROM LEARNER WHERE id = @id) >= 1
	BEGIN
		SET @role = 1
	END
	ELSE IF (SELECT count(*) FROM TEACHER WHERE id = @id) >= 1
	BEGIN
		SET @role = 2
	END

	-- return 1 if everything is ok
	RETURN 1
GO


DROP PROC IF EXISTS addUser
USE [LingoLearn]
GO
CREATE PROC addUser (@username varchar(40), @email varchar(40), @password varchar(40), @isLearner bit, @isTeacher bit)
AS
	BEGIN TRY
		INSERT INTO "USER" VALUES (@email, @username, @password)

		-- get the id that was given to
		-- the user when it was added
		DECLARE @id int;
		SELECT @id = id
			FROM "USER"
			WHERE email=@email

		IF @isLearner = 1
		BEGIN
			INSERT INTO LEARNER VALUES (@id, 0)
		END

		ELSE IF @isTeacher = 1
		BEGIN
			INSERT INTO TEACHER VALUES (@id, 0, @username)
		END

		RETURN 1
	END TRY
	BEGIN CATCH
		RETURN 0
	END CATCH
GO

DROP FUNCTION IF EXISTS isStudentOf
USE [LingoLearn]
GO
CREATE FUNCTION dbo.isStudentOf (@student_id int, @teacher_id int, @designation varchar(40))
RETURNS int
AS
BEGIN
    IF (SELECT COUNT(*) FROM TEACHES_STUDENTS WHERE learner_id = @student_id AND teacher_id=@teacher_id AND designation=@designation) >= 1
	BEGIN
		RETURN 1
	END

	RETURN 0
END
GO

DROP FUNCTION IF EXISTS isLearningLanguage
USE [LingoLearn]
GO
CREATE FUNCTION dbo.isLearningLanguage (@student_id int, @designation varchar(40))
RETURNS int
AS
BEGIN
    IF (SELECT COUNT(*) FROM LEARNING WHERE LEARNING.user_id = @student_id AND LEARNING.designation = @designation) >= 1
	BEGIN
		RETURN 1
	END

	RETURN 0
END
GO

DROP PROC IF EXISTS getUserQuizes
USE [LingoLearn]
GO
CREATE PROC getUserQuizes (@user_id int)
AS
	DROP TABLE IF EXISTS #temp
	DROP TABLE IF EXISTS #temp_score
	SELECT QUIZ.id, QUIZ.name, MAX(CASE user_id  WHEN @user_id THEN 'True' ELSE 'False' END) as answered, QUIZ.type, ISNULL(TEACHER.teacher_name,'LingoLearn') as creator, designation as "language"
		INTO #temp
		FROM (QUIZES_ANSWERED RIGHT OUTER JOIN QUIZ ON QUIZ.id = QUIZES_ANSWERED.quiz_id) LEFT OUTER JOIN TEACHER ON TEACHER.id = creator_id
		WHERE (dbo.isStudentOf(@user_id, TEACHER.id, designation) = 1 OR TEACHER.id IS NULL) AND dbo.isLearningLanguage(@user_id, QUIZ.designation) = 1
		GROUP BY QUIZ.id, QUIZ.name, QUIZ.type, TEACHER.teacher_name, designation

	SELECT user_id, quiz_id, sum(score) as score
		INTO #temp_score
		FROM (ANSWERS JOIN ANSWER ON ANSWERS.question_id = ANSWER.question_id AND ANSWERS.text = ANSWER.text) JOIN QUESTION ON QUESTION.id=ANSWER.question_id
		GROUP BY ANSWERS.user_id, QUESTION.quiz_id
		HAVING user_id=@user_id

	SELECT id, name, answered, type, creator, language, ISNULL(score,0) as score FROM
		#temp LEFT OUTER JOIN #temp_score on #temp.id=#temp_score.quiz_id
GO

DROP PROC IF EXISTS getPossibleTeachers
USE [LingoLearn]
GO
CREATE PROC getPossibleTeachers (@user_id int)
AS
	SELECT id, teacher_name, designation as "language", MAX(CASE dbo.isStudentOf(@user_id, id, designation)  WHEN 1 THEN 'True' ELSE 'False' END) as teaches_you
		FROM TEACHER JOIN TEACHES_LANGUAGE ON TEACHER.id = TEACHES_LANGUAGE.teacher_id
		WHERE available=1 AND dbo.isLearningLanguage(@user_id, designation)=1
		GROUP BY id, teacher_name, designation
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

DROP PROC IF EXISTS getQuizQuestions
USE [LingoLearn]
GO
CREATE PROC getQuizQuestions (@quiz_id int)
AS
	SELECT quiz_id, id as question_id, question_text, text as answer, type, designation, score
		FROM QUESTION JOIN ANSWER ON QUESTION.id=ANSWER.question_id
		WHERE quiz_id=@quiz_id
GO

DROP PROC IF EXISTS getQuizes
USE [LingoLearn]
GO
CREATE PROC getQuizes (@user_id int)
AS
	SELECT QUIZ.id, QUIZ.name, user_id, type, TEACHER.id as teacher_id,TEACHER.teacher_name, designation
			FROM (QUIZES_ANSWERED RIGHT OUTER JOIN QUIZ ON QUIZ.id = QUIZES_ANSWERED.quiz_id) LEFT OUTER JOIN TEACHER ON TEACHER.id = creator_id
			WHERE EXISTS (SELECT * FROM TEACHES_STUDENTS WHERE learner_id = @user_id AND TEACHES_STUDENTS.teacher_id=TEACHER.id) OR TEACHER.id IS NULL
GO

DROP PROC IF EXISTS getPossibleTeachers
USE [LingoLearn]
GO
CREATE PROC getPossibleTeachers (@user_id int)
AS
	SELECT id, teacher_name, designation, MAX(CASE dbo.isStudentOf(@user_id, id, designation)  WHEN 1 THEN 'True' ELSE 'False' END) as teaches_you
		FROM TEACHER JOIN TEACHES_LANGUAGE ON TEACHER.id = TEACHES_LANGUAGE.teacher_id
		WHERE available=1 AND dbo.isLearningLanguage(@user_id, designation)=1
		GROUP BY id, teacher_name, designation
GO

DROP PROC IF EXISTS startTeaching
USE [LingoLearn]
GO
CREATE PROC startTeaching (@teacher_id int, @student_id int, @designation varchar(40))
AS
	INSERT INTO TEACHES_STUDENTS VALUES
	(@student_id, @teacher_id, @designation)
GO

DROP PROC IF EXISTS stopTeaching
USE [LingoLearn]
GO
CREATE PROC stopTeaching (@teacher_id int, @student_id int, @designation varchar(40))
AS
	DELETE FROM TEACHES_STUDENTS 
	WHERE learner_id=@student_id and teacher_id=@teacher_id and designation=@designation
GO


DROP PROC IF EXISTS getDesignations
USE [LingoLearn]
GO
CREATE PROCEDURE getDesignations (@id int)
AS
	SELECT designation FROM TEACHER 
	JOIN TEACHES_LANGUAGE ON id = teacher_id 
	WHERE id = @id
GO


DROP PROC IF EXISTS addQuiz
USE [LingoLearn]
GO

CREATE PROCEDURE addQuiz (@quizName VARCHAR(20), @quizType VARCHAR(20), @designation VARCHAR(40), @creator_id int)
AS

	INSERT INTO QUIZ VALUES
	(@quizName, @quizType, @designation, @creator_id)

	SELECT SCOPE_IDENTITY() as id
GO



DROP PROC IF EXISTS addQuestion
USE [LingoLearn]
GO

CREATE PROCEDURE addQuestion (@question_type VARCHAR(20), @question_text VARCHAR(300), @designation VARCHAR(40), @quiz_id int)
AS

	INSERT INTO QUESTION VALUES
	-- type, text, designation, quiz_id
	(@question_type, @question_text, @designation, @quiz_id)

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


DROP PROC IF EXISTS getAvailability
USE [LingoLearn]
GO

CREATE PROCEDURE getAvailability (@id int)
AS
	SELECT available FROM TEACHER
	WHERE id = @id
GO


DROP PROC IF EXISTS updateAvailability
USE [LingoLearn]
GO

CREATE PROCEDURE updateAvailability (@id int, @bool bit)
AS
	UPDATE "TEACHER"
	SET available = @bool
	WHERE id = @id
GO


DROP PROC IF EXISTS deleteUser
USE [LingoLearn]
GO
CREATE PROCEDURE deleteUser (@id int)
AS
	DELETE FROM "USER"
	WHERE id = @id
GO

DROP TRIGGER IF EXISTS deleteUserFromEverything
USE [LingoLearn]
GO
CREATE TRIGGER deleteUserFromEverything
ON "USER" INSTEAD OF DELETE AS
BEGIN
	DECLARE @id int = (SELECT id FROM deleted)

	DELETE FROM TEACHES_STUDENTS
	WHERE teacher_id = @id

	DELETE FROM TEACHES_LANGUAGE
	WHERE teacher_id = @id

	DELETE FROM QUIZ
	WHERE creator_id = @id

	DELETE FROM TEACHER
	WHERE id = @id

	DELETE FROM "USER"
	WHERE id = @id
END
GO

DROP PROC IF EXISTS updatePassword
USE [LingoLearn]
GO
CREATE PROCEDURE updatePassword (@id int, @password varchar(40))
AS
	UPDATE "USER"
	SET "password" = @password
	WHERE id = @id
GO


DROP PROC IF EXISTS getLeaderboard
USE [LingoLearn]
GO
CREATE PROC getLeaderboard
AS
	SELECT "USER".id, "USER".username, ISNULL(SUM(score),0) as score
		FROM "USER" LEFT OUTER JOIN (ANSWERS JOIN ANSWER ON ANSWERS.question_id=ANSWER.question_id) ON "USER".id = ANSWERS.user_id
		WHERE EXISTS (SELECT id FROM LEARNER WHERE LEARNER.id = "USER".id)
		GROUP BY id, "USER".username
		ORDER BY score DESC
GO

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
		
DROP PROC IF EXISTS addLanguage
USE [LingoLearn]
GO

CREATE PROCEDURE addLanguage (@id int, @designation VARCHAR(40))
AS
	INSERT INTO TEACHES_LANGUAGE
	VALUES (@designation, @id)
GO


DROP PROC IF EXISTS removeLanguage
USE [LingoLearn]
GO

CREATE PROCEDURE removeLanguage (@id int, @designation VARCHAR(40))
AS
	INSERT INTO TEACHES_LANGUAGE
	VALUES (@designation, @id)
GO