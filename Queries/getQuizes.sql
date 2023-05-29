DROP PROC IF EXISTS getQuizes
USE [LingoLearn]
GO
CREATE PROC getQuizes (@user_id int)
AS
	SELECT QUIZ.id, QUIZ.name, user_id, type, TEACHER.id as teacher_id,TEACHER.teacher_name, designation
			FROM (QUIZES_ANSWERED RIGHT OUTER JOIN QUIZ ON QUIZ.id = QUIZES_ANSWERED.quiz_id) LEFT OUTER JOIN TEACHER ON TEACHER.id = creator_id
			WHERE EXISTS (SELECT * FROM TEACHES_STUDENTS WHERE learner_id = @user_id AND TEACHES_STUDENTS.teacher_id=TEACHER.id) OR TEACHER.id IS NULL
GO