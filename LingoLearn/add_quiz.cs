using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LingoLearn
{
    public partial class add_quiz : Form
    {
        List<Question> questions = new List<Question>();
        List<Answer> answers = new List<Answer>();
        List<String> answersMulti = new List<String>();
        List<int> questions_id = new List<int>();

        bool multi = false;
        bool translation = false;
        int quiz_id;
        int question_id;
        int value;
        String designation;
        String quizType;

        public add_quiz(String quizType, int quiz_id, String designation)
        {
            this.quiz_id = quiz_id;
            this.designation = designation;
            this.quizType = quizType;
            InitializeComponent();
        }

        private void create_quiz_button_Click(object sender, EventArgs e)
        {
            addQuiz(quizType);
            if (translation)
            {
                Question q = new Question();
                
                q.type = "Tradução";
                q.question_text = question_text.Text;

                questions.Add(q);

                Answer a = new Answer();

                a.score = 100;
                a.answer_text = answer_text.Text;

                answers.Add(a);

                addQuestions();
            }
            else
            {
                int checkedBox = 0;
                Question q = new Question();

                q.type = "Escolha Múltipla";
                q.question_text = question_text.Text;

                questions.Add(q);

                if (multi_check_1.Checked)
                    checkedBox++;
                if (multi_check_2.Checked)
                    checkedBox++;
                if (multi_check_3.Checked)
                    checkedBox++;
                if (multi_check_4.Checked)
                    checkedBox++;

                int score = 100 / checkedBox;

                Answer a = new Answer();
                if (multi_check_1.Checked)
                    a.score = score;
                else
                    a.score = 0;
                a.answer_text = multi_text_1.Text;
                answers.Add(a);

                a = new Answer();
                if (multi_check_2.Checked)
                    a.score = score;
                else
                    a.score = 0;
                a.answer_text = multi_text_2.Text;
                answers.Add(a);

                a = new Answer();
                if (multi_check_3.Checked)
                    a.score = score;
                else
                    a.score = 0;
                a.answer_text = multi_text_3.Text;
                answers.Add(a);

                a = new Answer();
                if (multi_check_4.Checked)
                    a.score = score;
                else
                    a.score = 0;
                a.answer_text = multi_text_4.Text;
                answers.Add(a);


                addQuestions();
            }
            // load add_quizzes again
            var show_quizzes = new add_quizes();
            show_quizzes.Show();
            this.Close();
        }

        private void add_new_question_button_Click(object sender, EventArgs e)
        {
            if (translation)
            {
                if (question_text.Text != "" && answer_text.Text != "")
                {
                    Question q = new Question();

                    q.type = "Tradução";
                    q.question_text = question_text.Text;

                    questions.Add(q);

                    Answer a = new Answer();

                    a.score = 100;
                    a.answer_text = answer_text.Text;

                    answers.Add(a);
                    cleanUP();
                }
            }
            else if (multi)
            {
                if(question_text.Text != "")
                {
                    int checkedBox = 0;
                    Question q = new Question();

                    q.type = "Escolha Múltipla";
                    q.question_text = question_text.Text;

                    questions.Add(q);

                    if (multi_check_1.Checked)
                        checkedBox++;
                    if (multi_check_2.Checked)
                        checkedBox++;
                    if (multi_check_3.Checked)
                        checkedBox++;
                    if (multi_check_4.Checked)
                        checkedBox++;

                    int score = 100 / checkedBox;

                    Answer a = new Answer();
                    if (multi_check_1.Checked)
                        a.score = score;
                    else
                        a.score = 0;
                    a.answer_text = multi_text_1.Text;
                    answers.Add(a);

                    a = new Answer();
                    if (multi_check_2.Checked)
                        a.score = score;
                    else
                        a.score = 0;
                    a.answer_text = multi_text_2.Text;
                    answers.Add(a);

                    a = new Answer();
                    if (multi_check_3.Checked)
                        a.score = score;
                    else
                        a.score = 0;
                    a.answer_text = multi_text_3.Text;
                    answers.Add(a);

                    a = new Answer();
                    if (multi_check_4.Checked)
                        a.score = score;
                    else
                        a.score = 0;
                    a.answer_text = multi_text_4.Text;
                    answers.Add(a);
                }
                cleanUP();
            }
        }

        public void addQuestions()
        {
            SqlConnection cn = homepage.cn;

            // Insert question and answer onto quiz

            try
            {
                cn.Open();
                // Question Part 
                foreach (Question question in questions)
                {
                    using (SqlCommand cmd = new SqlCommand("addQuestion", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@question_type", SqlDbType.VarChar, 20).Value = question.type;
                        cmd.Parameters.Add("@question_text", SqlDbType.VarChar, 300).Value = question.question_text;
                        cmd.Parameters.Add("@designation", SqlDbType.VarChar, 40).Value = this.designation;
                        cmd.Parameters.Add("@quiz_id", SqlDbType.Int).Value = this.quiz_id;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                this.question_id = int.Parse(reader["id"].ToString());
                                this.questions_id.Add(question_id);
                            }
                        }
                    }
                }


                // Answer Part
                int count = 0;
                foreach (Answer answer in answers)
                {
                    using (SqlCommand cmd = new SqlCommand("addAnswer", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@score", SqlDbType.Int).Value = answer.score;
                        cmd.Parameters.Add("@answer_text", SqlDbType.VarChar, 500).Value = answer.answer_text;
                        cmd.Parameters.Add("@question_id", SqlDbType.Int).Value = this.questions_id[count];
                        cmd.ExecuteNonQuery();
                    }
                    try
                    {

                        Console.Write(this.questions_id[count + 1]);
                        if (this.questions_id[count] != this.questions_id[count++])
                            count++;
                    }
                    catch
                    {

                    }
                    
                }
            }
            finally
            {
                if (cn.State != ConnectionState.Closed)
                {
                    cn.Close();
                }
            }
        }

        public void addQuiz(String quizType)
        {
            SqlConnection cn = homepage.cn;

            try
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand("addQuiz", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@creator_id", SqlDbType.Int).Value = login.id;
                    cmd.Parameters.Add("@designation", SqlDbType.VarChar, 40).Value = this.designation;
                    cmd.Parameters.Add("@quizType", SqlDbType.VarChar, 20).Value = quizType;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            this.quiz_id = int.Parse(reader["id"].ToString());
                        }
                    }
                }
                cn.Close();
            }
            finally
            {
                if (cn.State != ConnectionState.Closed)
                {
                    cn.Close();
                }
            }
        }

        public class Question
        {
            public String type { get; set; }
            public String question_text { get; set; }
        }

        public class Answer
        {
            public int score { get; set; }
            public String answer_text { get; set; }
        }

        private void translation_radio_CheckedChanged(object sender, EventArgs e)
        {
            if(translation_radio.Checked == true)
            {
                translation = true;
                multi = false;

                question.Visible = true;
                answer.Visible = true;
                question_text.Visible = true;
                answer_text.Visible = true;
                translation_radio.Visible = false;
                multiple_choice_radio.Visible = false;
            }

        }

        private void multiple_choice_radio_CheckedChanged(object sender, EventArgs e)
        {
            if (multiple_choice_radio.Checked == true)
            {
                translation = false;
                multi = true;

                question.Visible = true;
                answer.Visible = true;
                question_text.Visible = true;
                translation_radio.Visible = false;
                multiple_choice_radio.Visible = false;
                multi_check_1.Visible = true;
                multi_check_2.Visible = true;
                multi_check_3.Visible = true;
                multi_check_4.Visible = true;
                multi_text_1.Visible = true;
                multi_text_2.Visible = true;
                multi_text_3.Visible = true;
                multi_text_4.Visible = true;
            }
        }

        public void cleanUP()
        {
            question.Visible = false;
            answer.Visible = false;
            question_text.Visible = false;
            answer_text.Visible = false;
            translation_radio.Visible = true;
            multiple_choice_radio.Visible = true;
            multi_check_1.Visible = false;
            multi_check_2.Visible = false;
            multi_check_3.Visible = false;
            multi_check_4.Visible = false;
            multi_text_1.Visible = false;
            multi_text_2.Visible = false;
            multi_text_3.Visible = false;
            multi_text_4.Visible = false;

            question_text.Clear();
            answer_text.Clear();
            
            translation_radio.Checked = false;
            multiple_choice_radio.Checked = false;
            multi_check_1.Checked = false;
            multi_check_2.Checked = false;
            multi_check_3.Checked = false;
            multi_check_4.Checked = false;

            multi_text_1.Clear();
            multi_text_2.Clear();
            multi_text_3.Clear();
            multi_text_4.Clear();

            translation = false;
            multi = false;
        }

    }
}
