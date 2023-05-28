using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        int score = 0;
        public answer_quiz(List<Question> questions)
        {
            InitializeComponent();
            this.questions = questions;
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
                MessageBox.Show("finished with a score of " + score.ToString(), "Score", MessageBoxButtons.OK, MessageBoxIcon.Information);
                var frm = new quizes_to_answer();
                frm.Location = this.Location;
                frm.StartPosition = FormStartPosition.Manual;
                frm.Show();
                this.Hide();
                return;
            }
            Question q = questions[current];
            question_label.Text = q.text;
            if (q.type.Equals("Escolha Múltipla"))
            {
                hide_textbox();
                next_question_button.Visible = false;
                
                answer1_button.Text = q.answers[0].text;
                answer2_button.Text = q.answers[1].text;
                answer3_button.Text = q.answers[2].text;
                answer4_button.Text = q.answers[3].text;
            }
            else
            {
                answer_translate_text_box.Clear();
                next_question_button.Visible = true;
                if (current + 1 == questions.Count)
                {
                    next_question_button.Text = "End Quiz";
                }
                hide_buttons();
            }
        }

        private void hide_buttons()
        {
            answer1_button.Visible = false;
            answer2_button.Visible = false;
            answer3_button.Visible = false;
            answer4_button.Visible = false;
            answer_translate_text_box.Visible = true;
        }

        private void hide_textbox()
        {
            answer1_button.Visible = true;
            answer2_button.Visible = true;
            answer3_button.Visible = true;
            answer4_button.Visible = true;
            answer_translate_text_box.Visible = false;
        }

        private void next_question_button_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(answer_translate_text_box.Text))
                return;

            int q_score = 0;
            if (answer_translate_text_box.Text.Equals(questions[current].answers[0].text))
                q_score = questions[current].answers[0].score;
            score += q_score;
            MessageBox.Show("You got a score of " + q_score.ToString() + " on this question", "Question Score", MessageBoxButtons.OK, MessageBoxIcon.Information);
            next();
        }

        private void answer1_button_Click(object sender, EventArgs e)
        {
            next();
        }

        private void answer2_button_Click(object sender, EventArgs e)
        {
            next();
        }

        private void answer3_button_Click(object sender, EventArgs e)
        {
            next();
        }

        private void answer4_button_Click(object sender, EventArgs e)
        {
            next();
        }
    }
}
