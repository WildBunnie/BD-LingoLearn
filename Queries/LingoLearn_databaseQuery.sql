IF DB_ID('LingoLearn') IS NULL
	CREATE DATABASE LingoLearn;
	GO

USE [LingoLearn]

CREATE TABLE "USER"(
	id							int				IDENTITY(1,1) PRIMARY KEY,
	email						varchar(40)		UNIQUE NOT NULL,
	username					varchar(40)		NOT NULL,
	"password"					varchar(40)		NOT NULL);

CREATE TABLE TEACHER(
	id							int				PRIMARY KEY,	-- Foreign key
	available					bit				NOT NULL,		-- boolean
	teacher_name				varchar(40)		NOT NULL);

CREATE TABLE LEARNER(
	id							int				PRIMARY KEY,	-- Foreign key
	looking_for_teacher			bit				NOT NULL);		-- boolean

CREATE TABLE TEACHES_STUDENTS(
	learner_id					int,
	teacher_id					int,
	designation					VARCHAR(40),
	country_code				int,
	PRIMARY KEY(learner_id, teacher_id));						-- Both foreign keys

CREATE TABLE TEACHES_LANGUAGE(
	designation					VARCHAR(40),
	country_code				int,
	teacher_id					int,
	PRIMARY KEY(designation, country_code, teacher_id));						-- Both foreign keys

CREATE TABLE COUNTRY(
	code						int				IDENTITY(1,1) PRIMARY KEY,
	"name"						VARCHAR(40)		UNIQUE NOT NULL,
	flag						CHAR(2)			UNIQUE NOT NULL);

CREATE TABLE "LANGUAGE"(
	designation					VARCHAR(40)		UNIQUE NOT NULL,							
	country_code				int,							-- Foreign key
	PRIMARY KEY(designation, country_code));

CREATE TABLE LEARNING(
	"user_id"					int,
	designation					VARCHAR(40),
	country_code				int,
	PRIMARY KEY("user_id", designation, country_code));						-- Both foreign keys

CREATE TABLE KNOWS(
	"user_id"					int,
	designation					VARCHAR(40),
	country_code				int,
	PRIMARY KEY("user_id", designation, country_code));						-- Both foreign keys


CREATE TABLE DIFICULTY(
	designation_1				VARCHAR(40),
	country_code_1				int,
	designation_2				VARCHAR(40),
	country_code_2				int,
	"value"						int,							
	PRIMARY KEY(designation_1, designation_2, country_code_1, country_code_2));					-- Both foreign keys

CREATE TABLE QUIZ(
	id							int			IDENTITY(1,1)	PRIMARY KEY,
	"type"						VARCHAR(20)	NOT NULL,			
	designation					VARCHAR(40)			NOT NULL,			-- Foreign key
	country_code				int			NOT NULL,
	creator_id					int);			-- Foreign key

CREATE TABLE QUIZES_ANSWERED(
	"user_id"					int,
	quiz_id						int,
	PRIMARY KEY("user_id", quiz_id));							-- Both foreign keys

CREATE TABLE QUESTION(
	id							int			IDENTITY(1,1) PRIMARY KEY,
	"type"						VARCHAR(20)	NOT NULL,			
	question_text				VARCHAR(300)NOT NULL,			
	designation					VARCHAR(40)			NOT NULL,			-- Foreign key
	country_code				int			NOT NULL,			-- foreign key
	quiz_id						int			NOT NULL);			-- Foreign key

CREATE TABLE ANSWER(
	score						int			NOT NULL,
	"text"						VARCHAR(500),					
	question_id					int,							-- Foreign key
	PRIMARY KEY("text", question_id));

CREATE TABLE ANSWERS(
	"user_id"					int,
	"text"						VARCHAR(500),
	question_id					int,
	PRIMARY KEY("user_id", "text", question_id));							-- Both foreign keys


-- TEACHER TABLE
ALTER TABLE TEACHER
			ADD CONSTRAINT fk_teacher_id
			FOREIGN KEY (id)
			REFERENCES "USER"(id);

-- LEARNER TABLE
ALTER TABLE LEARNER
			ADD CONSTRAINT fk_learner_id
			FOREIGN KEY (id)
			REFERENCES "USER"(id);

-- TEACHES_STUDENTS TABLE
ALTER TABLE TEACHES_STUDENTS
			ADD CONSTRAINT fk_student_id
			FOREIGN KEY (learner_id)
			REFERENCES LEARNER(id);

ALTER TABLE TEACHES_STUDENTS
			ADD CONSTRAINT fk_teach_students_id
			FOREIGN KEY (teacher_id)
			REFERENCES TEACHER(id);

ALTER TABLE TEACHES_STUDENTS
			ADD CONSTRAINT fk_teach_students_language
			FOREIGN KEY (designation, country_code)
			REFERENCES "LANGUAGE"(designation, country_code);

-- TEACHES_LANGUAGE TABLE
ALTER TABLE TEACHES_LANGUAGE
			ADD CONSTRAINT fk_language_id
			FOREIGN KEY (designation, country_code) -- changed
			REFERENCES "LANGUAGE"(designation, country_code);

ALTER TABLE TEACHES_LANGUAGE
			ADD CONSTRAINT fk_teach_id
			FOREIGN KEY (teacher_id)
			REFERENCES TEACHER(id);

-- LANGUAGE TABLE
ALTER TABLE "LANGUAGE"
			ADD CONSTRAINT fk_country_id
			FOREIGN KEY (country_code)
			REFERENCES COUNTRY(code);

-- LEARNING TABLE
ALTER TABLE LEARNING
			ADD CONSTRAINT fk_user_learning_id
			FOREIGN KEY ("user_id")
			REFERENCES "USER"(id);

ALTER TABLE LEARNING
			ADD CONSTRAINT fk_language_learning_id
			FOREIGN KEY (designation, country_code) -- changed
			REFERENCES "LANGUAGE"(designation, country_code);

-- KNOWS TABLE
ALTER TABLE KNOWS
			ADD CONSTRAINT fk_user_knows_id
			FOREIGN KEY ("user_id")
			REFERENCES "USER"(id);

ALTER TABLE KNOWS
			ADD CONSTRAINT fk_language_knows_id
			FOREIGN KEY (designation, country_code) -- changed
			REFERENCES "LANGUAGE"(designation, country_code);

-- DIFICULTY TABLE
ALTER TABLE DIFICULTY
			ADD CONSTRAINT fk_language_1_id
			FOREIGN KEY (designation_1, country_code_1) -- changed
			REFERENCES "LANGUAGE"(designation, country_code);

ALTER TABLE DIFICULTY
			ADD CONSTRAINT fk_language_2_id
			FOREIGN KEY (designation_2, country_code_2) -- changed
			REFERENCES "LANGUAGE"(designation, country_code);

-- QUIZ TABLE
ALTER TABLE QUIZ
			ADD CONSTRAINT fk_quiz_language_id
			FOREIGN KEY (designation, country_code) -- changed
			REFERENCES "LANGUAGE"(designation, country_code);

ALTER TABLE QUIZ
			ADD CONSTRAINT fk_quiz_creator_id
			FOREIGN KEY (creator_id)
			REFERENCES TEACHER(id);

-- QUIZESANSWERED TABLE
ALTER TABLE QUIZES_ANSWERED
			ADD CONSTRAINT fk_quizanswer_user_id
			FOREIGN KEY ("user_id")
			REFERENCES "USER"(id);

ALTER TABLE QUIZES_ANSWERED
			ADD CONSTRAINT fk_quizanswer_quiz_id
			FOREIGN KEY (quiz_id)
			REFERENCES QUIZ(id);

-- QUESTION TABLE
ALTER TABLE QUESTION
			ADD CONSTRAINT fk_question_language_id
			FOREIGN KEY (designation, country_code) -- changed
			REFERENCES "LANGUAGE"(designation, country_code);

ALTER TABLE QUESTION
			ADD CONSTRAINT fk_question_quiz_id
			FOREIGN KEY (quiz_id)
			REFERENCES QUIZ(id);


-- ANSWER TABLE
ALTER TABLE ANSWER
			ADD CONSTRAINT fk_answer_question_id
			FOREIGN KEY (question_id)
			REFERENCES QUESTION(id);

-- ANSWERS TABLE 
ALTER TABLE ANSWERS
			ADD CONSTRAINT fk_answers_user_id
			FOREIGN KEY ("user_id")
			REFERENCES "USER"(id);

ALTER TABLE ANSWERS
			ADD CONSTRAINT fk_answers_question_id
			FOREIGN KEY ("text", question_id)
			REFERENCES ANSWER("text", question_id);