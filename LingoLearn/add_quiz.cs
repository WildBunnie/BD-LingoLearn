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
        IDictionary<string, string> questions = new Dictionary<string, string>();
        bool multi = false;
        bool translation = false;
        int quiz_id;
        int question_id;
        String designation;

        public add_quiz(int quiz_id, String designation)
        {
            this.quiz_id = quiz_id;
            this.designation = designation;
            InitializeComponent();
        }

        private void create_quiz_button_Click(object sender, EventArgs e)
        {
            add_new_question_button_Click(this, e);

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
                    SqlConnection cn = homepage.cn;

                    // Insert question and answer onto quiz

                    try
                    {
                        cn.Open();
                        // Question Part 
                        using (SqlCommand cmd = new SqlCommand("addQuestion", cn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.Add("@question_type", SqlDbType.VarChar, 20).Value = "Translation";
                            cmd.Parameters.Add("@question_text", SqlDbType.VarChar, 300).Value = question_text.Text;
                            cmd.Parameters.Add("@designation", SqlDbType.VarChar, 40).Value = this.designation;
                            cmd.Parameters.Add("@quiz_id", SqlDbType.Int).Value = this.quiz_id;

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    this.question_id = int.Parse(reader["id"].ToString());
                                }
                            }
                        }

                        // Answer Part
                        using (SqlCommand cmd = new SqlCommand("addAnswer", cn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.Add("@score", SqlDbType.Int).Value = 100;
                            cmd.Parameters.Add("@answer_text", SqlDbType.VarChar, 500).Value = answer_text.Text;
                            cmd.Parameters.Add("@question_id", SqlDbType.Int).Value = this.question_id;

                            cmd.ExecuteNonQuery();
                        }
                    }
                    finally
                    {
                        if (cn.State != ConnectionState.Closed)
                        {
                            cn.Close();
                        }
                    }
                    cleanUP();
                }
            }
            else if (multi)
            {
                if(question_text.Text != "")
                {

                }
                cleanUP();
            }


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
