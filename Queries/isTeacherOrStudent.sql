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