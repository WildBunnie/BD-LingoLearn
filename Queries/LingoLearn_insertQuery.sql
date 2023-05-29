USE LingoLearn
GO


-- User inserts
INSERT INTO "USER"
VALUES
-- email, username, password
('pd.pinho@ua.pt', 'Pedro Pinho', 'pedro'),
('joaoandrade@ua.pt', 'João Andrade', 'joão'),
('estudante@ua.pt', 'Estudante', 'estudante'),
('professor@ua.pt', 'Professor', 'professor');


INSERT INTO LEARNER
VALUES
-- id, looking_for_teacher
(1, 0),
(2, 0),
(3, 1);


INSERT INTO TEACHER
VALUES
-- id, available, teacher_name
(4, 1, 'Professor XPTO');


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
(1, 4, 'Portuguese'),
(2, 4, 'Spanish');


INSERT INTO TEACHES_LANGUAGE
VALUES
-- designation, teacher_id
('Portuguese', 4),
('Spanish', 4);


INSERT INTO LEARNING
VALUES
-- user_id, designation
(1, 'Portuguese'),
(2, 'Spanish');


INSERT INTO KNOWS
VALUES
-- user_id, designation
(1, 'English'),
(1, 'Spanish'),
(2, 'Portuguese'),
(2, 'English'),
(2, 'Spanish'),
(3, 'Portuguese'),
(3, 'Spanish'),
(3, 'English'),
(4, 'Portuguese'),
(4, 'Spanish');


INSERT INTO DIFICULTY
VALUES
-- designation_1, designation_2, value
('Portuguese', 'Spanish', 1),
('Portuguese', 'English', 2);


INSERT INTO QUIZ
VALUES
-- name, id, type, flag, creator_id(teacherid) (can be null)
('Verbos Básicos', 'Verbos', 'Portuguese', NULL),
('Tradução Básica', 'Gramática', 'Portuguese', NULL),
('Verbos Avançados', 'Verbos', 'Portuguese', 4),
('Verbos intermédios', 'Verbos', 'Portuguese', 4);


INSERT INTO QUIZES_ANSWERED
VALUES
-- user_id, quiz_id
(1, 1),
(1, 2),
(2, 4);


INSERT INTO QUESTION
VALUES
-- id, type, question_text, designation, quiz_id
('Multi-choice', 'Uma das seguintes opções não pertence à conjugação do verbo "Saber", selecione a opção errada', 'Portuguese', 1),
('Translation', 'Traduza para Português a seguinte frase "I don''t know"', 'Portuguese', 2),
('Multi-choice', 'Escolha a conjugação correta do verbo "Poder"', 'Portuguese', 4),
('Multi-choice', 'Escolha a conjugação correta do verbo "Cair"', 'Portuguese', 4),
('Multi-choice', 'Escolha a conjugação correta do verbo "Saber"', 'Portuguese', 3);


INSERT INTO ANSWER
VALUES
-- score, text, question_id
(100, 'soubémos', 1),
(0, 'sei', 1),
(0, 'saberíeis', 1),
(0, 'soubéramos', 1),
(100, 'Eu não sei', 2),
(50, 'podes', 3),
(50, 'podereis', 3),
(0, 'podereis-mos', 3),
(0, 'poderás-te', 3);


INSERT INTO ANSWERS
VALUES
-- user_id, answer_id(text, question_id)
(1, 'sei', 1),
(1, 'Eu não sei', 2),
(2, 'podes', 3),
(2, 'podereis', 3);