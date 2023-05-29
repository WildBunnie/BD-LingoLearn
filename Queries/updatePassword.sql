DROP PROC IF EXISTS updatePassword
USE [LingoLearn]
GO
CREATE PROCEDURE updatePassword (@id int, @password varchar(40))
AS
	UPDATE "USER"
	SET "password" = @password
	WHERE id = @id
GO