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
    public partial class answer_quiz : Form
    {
        int current = -1;
        List<Question> questions;
        List<UserAnswer> user_answers = new List<UserAnswer>();
        int score = 0;
        int quiz_id;
        public answer_quiz(List<Question> questions, int quiz_id)
        {
            InitializeComponent();
            this.questions = questions;
            this.quiz_id = quiz_id;
        }

        private void answer_quiz_Load(object sender, EventArgs e)
        {
            next();
        }

        private void next()
        {
            current += 1;

            if(current >= questions.Count)
            {
                finish();
                return;
            }

            Question q = questions[current];
            question_label.Text = q.text;
            if (q.type.Equals("Multi-choice"))
            {
                hide_textbox();
                next_question_button.Visible = true;

                checkBox1.Text = q.answers[0].text;
                checkBox2.Text = q.answers[1].text;
                checkBox3.Text = q.answers[2].text;
                checkBox4.Text = q.answers[3].text;
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
            }
            else
            {
                answer_translate_text_box.Clear();
                next_question_button.Visible = true;
                hide_buttons();
            }
            if (current + 1 == questions.Count)
            {
                next_question_button.Text = "End Quiz";
            }
        }

        private void finish()
        {
            MessageBox.Show("finished with a score of " + score.ToString(), "Score", MessageBoxButtons.OK, MessageBoxIcon.Information);

            SqlConnection cn = startpage.cn;
            using (SqlCommand cmd = new SqlCommand("setUserAnsweredQuiz", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@user_id", SqlDbType.Int).Value = login.id;
                cmd.Parameters.Add("@quiz_id", SqlDbType.Int).Value = this.quiz_id;

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }

            foreach (UserAnswer ua in user_answers)
            {
                using (SqlCommand cmd = new SqlCommand("setUserAnswer", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@user_id", SqlDbType.Int).Value = login.id;
                    cmd.Parameters.Add("@answer_id", SqlDbType.Int).Value = ua.AnswerID;

                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }
            }

            utils.loadForm(this, new quizes_to_answer());
        }

        private void hide_buttons()
        {
            checkBox1.Visible = false;
            checkBox2.Visible = false;
            checkBox3.Visible = false;
            checkBox4.Visible = false;
            answer_translate_text_box.Visible = true;
        }

        private void hide_textbox()
        {
            checkBox1.Visible = true;
            checkBox2.Visible = true;
            checkBox3.Visible = true;
            checkBox4.Visible = true;
            answer_translate_text_box.Visible = false;
        }

        private void next_question_button_Click(object sender, EventArgs e)
        {

            List<String> text = new List<String>();
            int q_score = 0;

            if (questions[current].type.Equals("Multi-choice"))
            {
                if (!checkBox1.Checked && !checkBox2.Checked && !checkBox3.Checked && !checkBox4.Checked)
                    return;

                bool done = false;

                if (checkBox1.Checked && !done)
                {
                    int score = questions[current].answers[0].score;
                    if(score == 0)
                    {
                        q_score = 0;
                        done = true;
                        text.Clear();
                    }
                    else
                    {
                        q_score += score;
                    }
                    text.Add(questions[current].answers[0].text);
                }
                if (checkBox2.Checked && !done)
                {
                    int score = questions[current].answers[1].score;
                    if (score == 0)
                    {
                        q_score = 0;
                        done = true;
                        text.Clear();
                    }
                    else
                    {
                        q_score += score;
                    }
                    text.Add(questions[current].answers[1].text);
                }
                if (checkBox3.Checked && !done)
                {
                    int score = questions[current].answers[2].score;
                    if (score == 0)
                    {
                        q_score = 0;
                        done = true;
                        text.Clear();
                    }
                    else
                    {
                        q_score += score;
                    }
                    text.Add(questions[current].answers[2].text);
                }
                if (checkBox4.Checked && !done)
                {
                    int score = questions[current].answers[3].score;
                    if (score == 0)
                    {
                        q_score = 0;
                        done = true;
                        text.Clear();
                    }
                    else
                    {
                        q_score += score;
                    }
                    text.Add(questions[current].answers[3].text);
                }

            }
            else
            {
                if (String.IsNullOrEmpty(answer_translate_text_box.Text))
                    return;

                if (answer_translate_text_box.Text.ToLower().Equals(questions[current].answers[0].text.ToLower()))
                    q_score = questions[current].answers[0].score;
                if (q_score == 100)
                {
                    text.Add(questions[current].answers[0].text);
                }
            }
            score += q_score;
            answer(q_score, text);            
            next();
        }

        private void answer(int q_score, List<String> text)
        {
            MessageBox.Show("You got a score of " + q_score.ToString() + " on this question", "Question Score", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // this is here because we don't add translation answers
            // if the response is incorrect
            if (text.Count == 0)
                return;

            for(int i = 0; i<text.Count; i++)
            {
                String t = text[i];
                UserAnswer ua = new UserAnswer();
                ua.AnswerID = questions[current].answers[i].ID;
                ua.text = t;
                user_answers.Add(ua);
            }

        }

    }

    public class UserAnswer
    {
        public String text { get; set; }
        public int AnswerID { get; set; }
    }
}
