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