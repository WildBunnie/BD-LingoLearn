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