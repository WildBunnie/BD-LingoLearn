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

--DECLARE @count INT = 0;
--DECLARE @email VARCHAR(40) = CONVERT(VARCHAR(40), NEWID());
--DECLARE @username VARCHAR(40);
--DECLARE @password VARCHAR(40) = CONVERT(VARCHAR(40), NEWID());

--WHILE @count < 5000
--BEGIN
	--INSERT INTO "USER"
	--VALUES
	--('', '', '');
	--SET @count = @count + 1;
--END


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


INSERT INTO COUNTRY
VALUES
-- code, name, flag
('Portugal', 'PT'),
('Espanha', 'ES'),
('Estados Unidos', 'US');


INSERT INTO "LANGUAGE"
VALUES
-- designation, country_code
('Português', 1),
('Espanhol', 2),
('Inglês (Americano)', 3);


INSERT INTO TEACHES_STUDENTS
VALUES
-- learner_id, teacher_id, designation, country_code
(1, 4, 'Português', 1),
(2, 4, 'Espanhol', 2);


INSERT INTO TEACHES_LANGUAGE
VALUES
-- language_id(designation, country_code), teacher_id
('Português', 1, 4),
('Espanhol', 2, 4);


INSERT INTO LEARNING
VALUES
-- user_id, language_id(designation, country_code)
(1, 'Português', 1),
(2, 'Espanhol', 2);


INSERT INTO KNOWS
VALUES
-- user_id, language_id(designation, country_code)
(1, 'Inglês (Americano)', 3),
(1, 'Espanhol', 2),
(2, 'Português', 1),
(2, 'Inglês (Americano)', 3),
(2, 'Espanhol', 2),
(3, 'Português', 1),
(3, 'Espanhol', 2),
(3, 'Inglês (Americano)', 3),
(4, 'Português', 1),
(4, 'Espanhol', 2);


INSERT INTO DIFICULTY
VALUES
-- language_id_1(design, code), language_id_2(design, code), value (values are dummy)
('Português', 1, 'Espanhol', 2, 1),
('Português', 1, 'Inglês (Americano)', 3, 2);


INSERT INTO QUIZ
VALUES
-- name, id, type, language(design, code), creator_id(teacherid) (can be null)
('Verbos Básicos', 'Verbos', 'Português', 1, NULL),
('Tradução Básica', 'Gramática', 'Português', 1, NULL),
('Verbos Avançados', 'Verbos', 'Português', 1, 4),
('Verbos intermédios', 'Verbos', 'Português', 1, 4);


INSERT INTO QUIZES_ANSWERED
VALUES
-- user_id, quiz_id
(1, 1),
(1, 2),
(2, 4);


INSERT INTO QUESTION
VALUES
-- id, type, question_text, language_id(design, code), quiz_id
('Escolha Múltipla', 'Uma das seguintes opções não pertence à conjugação do verbo "Saber", selecione a opção errada', 'Português', 1, 1),
('Tradução', 'Traduza para Português a seguinte frase "I don''t know"', 'Português', 1, 2),
('Escolha Múltipla', 'Escolha a conjugação correta do verbo "Poder"', 'Português', 1, 4),
('Escolha Múltipla', 'Escolha a conjugação correta do verbo "Cair"', 'Português', 1, 4),
('Escolha Múltipla', 'Escolha a conjugação correta do verbo "Saber"', 'Português', 1, 3);


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