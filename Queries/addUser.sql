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