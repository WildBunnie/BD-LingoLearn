USE LingoLearn
GO


-- User inserts
INSERT INTO "USER"
VALUES
-- email, username, password
('pd.pinho@ua.pt', 'Pedro Pinho', 'pedro'),
('joaoandrade@ua.pt', 'Jo�o Andrade', 'jo�o'),
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
('Portugu�s', 1),
('Espanhol', 2),
('Ingl�s (Americano)', 3);


INSERT INTO TEACHES_STUDENTS
VALUES
-- learner_id, teacher_id, designation, country_code
(1, 4, 'Portugu�s', 1),
(2, 4, 'Espanhol', 2);


INSERT INTO TEACHES_LANGUAGE
VALUES
-- language_id(designation, country_code), teacher_id
('Portugu�s', 1, 4),
('Espanhol', 2, 4);


INSERT INTO LEARNING
VALUES
-- user_id, language_id(designation, country_code)
(1, 'Portugu�s', 1),
(2, 'Espanhol', 2);


INSERT INTO KNOWS
VALUES
-- user_id, language_id(designation, country_code)
(1, 'Ingl�s (Americano)', 3),
(1, 'Espanhol', 2),
(2, 'Portugu�s', 1),
(2, 'Ingl�s (Americano)', 3),
(2, 'Espanhol', 2),
(3, 'Portugu�s', 1),
(3, 'Espanhol', 2),
(3, 'Ingl�s (Americano)', 3),
(4, 'Portugu�s', 1),
(4, 'Espanhol', 2);


INSERT INTO DIFICULTY
VALUES
-- language_id_1(design, code), language_id_2(design, code), value (values are dummy)
('Portugu�s', 1, 'Espanhol', 2, 1),
('Portugu�s', 1, 'Ingl�s (Americano)', 3, 2);


INSERT INTO QUIZ
VALUES
-- name, id, type, language(design, code), creator_id(teacherid) (can be null)
('Verbos B�sicos', 'Verbos', 'Portugu�s', 1, NULL),
('Tradu��o B�sica', 'Gram�tica', 'Portugu�s', 1, NULL),
('Verbos Avan�ados', 'Verbos', 'Portugu�s', 1, 4),
('Verbos interm�dios', 'Verbos', 'Portugu�s', 1, 4);


INSERT INTO QUIZES_ANSWERED
VALUES
-- user_id, quiz_id
(1, 1),
(1, 2),
(2, 4);


INSERT INTO QUESTION
VALUES
-- id, type, question_text, language_id(design, code), quiz_id
('Escolha M�ltipla', 'Uma das seguintes op��es n�o pertence � conjuga��o do verbo "Saber", selecione a op��o errada', 'Portugu�s', 1, 1),
('Tradu��o', 'Traduza para Portugu�s a seguinte frase "I don''t know"', 'Portugu�s', 1, 2),
('Escolha M�ltipla', 'Escolha a conjuga��o correta do verbo "Poder"', 'Portugu�s', 1, 4),
('Escolha M�ltipla', 'Escolha a conjuga��o correta do verbo "Cair"', 'Portugu�s', 1, 4),
('Escolha M�ltipla', 'Escolha a conjuga��o correta do verbo "Saber"', 'Portugu�s', 1, 3);


INSERT INTO ANSWER
VALUES
-- score, text, question_id
(100, 'soub�mos', 1),
(0, 'sei', 1),
(0, 'saber�eis', 1),
(0, 'soub�ramos', 1),
(100, 'Eu n�o sei', 2),
(50, 'podes', 3),
(50, 'podereis', 3),
(0, 'podereis-mos', 3),
(0, 'poder�s-te', 3);


INSERT INTO ANSWERS
VALUES
-- user_id, answer_id(text, question_id)
(1, 'sei', 1),
(1, 'Eu n�o sei', 2),
(2, 'podes', 3),
(2, 'podereis', 3);