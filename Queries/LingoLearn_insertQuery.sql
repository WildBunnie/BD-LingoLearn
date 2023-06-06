USE LingoLearn
GO


-- User inserts
INSERT INTO "USER"
VALUES
-- email, username, password
('student@ua.pt', 'student', 'student'),
('teacher@ua.pt', 'teacher', 'teacher'),
('john@ua.pt', 'john', 'john'),
('peter@ua.pt', 'peter', 'peter'),
('james@ua.pt', 'james', 'james');


INSERT INTO LEARNER
VALUES
-- id, looking_for_teacher
(1, 0),
(3, 1),
(4, 1);


INSERT INTO TEACHER
VALUES
-- id, available, teacher_name
(2, 1, 'Best Teacher'),
(5, 1, 'BD Teacher');


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
(1, 2, 'Spanish'),
(3, 5, 'English'),
(4, 5, 'English');


INSERT INTO TEACHES_LANGUAGE
VALUES
-- designation, teacher_id
('Portuguese', 2),
('Spanish', 2),
('Korean', 5),
('English', 5),
('Portuguese', 5);


INSERT INTO LEARNING
VALUES
-- user_id, designation
(1, 'Portuguese'),
(1, 'Spanish'),
(3, 'English'),
(3,'Italian'),
(4,'English'),
(4, 'Korean');

INSERT INTO DIFICULTY
VALUES
-- designation_1, designation_2, value
('Portuguese', 'Spanish', 1),
('Portuguese', 'English', 2),
('English', 'Portuguese', 3),
('Portuguese', 'Korean', 5),
('Korean', 'Portuguese', 5);


INSERT INTO QUIZ
VALUES
-- name, id, type, flag, creator_id(teacherid) (can be null)
('Verbs Quiz', 'Verbs', 'Portuguese', NULL),
('Grammar Quiz', 'Grammar', 'Portuguese', 2),
('Grammar Quiz', 'Grammar', 'English', 5);

INSERT INTO QUESTION
VALUES
-- id, type, question_text, designation, quiz_id
('Multi-choice', 'Which one of the following options is not a conjugation of the verb "Saber"?','Portuguese', 1),
('Translation', 'How do you say "I ate" in Portuguese?','Portuguese', 1),
('Multi-choice', 'What is the correct way of spelling the word?','Portuguese', 2),
('Translation', 'Conjugate the first person of verb "To be"', 'English', 3),
('Translation', 'What is another word for beautiful?', 'English', 3),
('Multi-choice', 'What is the correct way of spelling following word?', 'English', 3);

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
(0, 'nínguem', 3),
(100, 'i am', 4),
(100, 'gorgeous', 5),
(100, 'outrageous', 6),
(0, 'outregeous', 6),
(0, 'outeragous', 6),
(0, 'outragous', 6);