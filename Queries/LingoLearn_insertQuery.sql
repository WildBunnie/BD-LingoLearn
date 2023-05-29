USE LingoLearn
GO


-- User inserts
INSERT INTO "USER"
VALUES
-- email, username, password
('student@ua.pt', 'student', 'student'),
('teacher@ua.pt', 'teacher', 'teacher');


INSERT INTO LEARNER
VALUES
-- id, looking_for_teacher
(1, 0);


INSERT INTO TEACHER
VALUES
-- id, available, teacher_name
(2, 1, 'Best Teacher');


INSERT INTO "LANGUAGE"
VALUES
-- designation
('Portuguese'),
('Spanish'),
('English'),
('Italian'),
('French'),
('Korean');


INSERT INTO TEACHES_STUDENTS
VALUES
-- learner_id, teacher_id, designation
(1, 2, 'Portuguese'),
(1, 2, 'Spanish');


INSERT INTO TEACHES_LANGUAGE
VALUES
-- designation, teacher_id
('Portuguese', 2),
('Spanish', 2);


INSERT INTO LEARNING
VALUES
-- user_id, designation
(1, 'Portuguese'),
(1, 'Spanish');

INSERT INTO DIFICULTY
VALUES
-- designation_1, designation_2, value
('Portuguese', 'Spanish', 1),
('Portuguese', 'English', 2);


INSERT INTO QUIZ
VALUES
-- name, id, type, flag, creator_id(teacherid) (can be null)
('Verbs Quiz', 'Verbs', 'Portuguese', NULL),
('Grammar Quiz', 'Grammar', 'Portuguese', 2);

INSERT INTO QUESTION
VALUES
-- id, type, question_text, designation, quiz_id
('Multi-choice', 'Which one of the following options is not a conjugation of the verb "Saber"?','Portuguese', 1),
('Translation', 'How do you say "I ate" in Portuguese?','Portuguese', 1),
('Multi-choice', 'What is the correct way of spelling the word?','Portuguese', 2);

INSERT INTO ANSWER
VALUES
-- score, text, question_id
(100, 'soubereides', 1),
(0, 'sei', 1),
(0, 'saberíeis', 1),
(0, 'soubéramos', 1),
(100, 'eu comi', 2),
(100, 'ninguém', 3),
(0, 'ninguêm', 3),
(0, 'ninguem', 3),
(0, 'nínguem', 3);