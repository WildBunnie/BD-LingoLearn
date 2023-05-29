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
    public partial class quizes_to_answer : Form
    {

        List<Quiz> quiz_list = new List<Quiz>();
        List<Question> question_list = new List<Question>();
        public quizes_to_answer()
        {
            InitializeComponent();
        }

        private void students_list_Load(object sender, EventArgs e)
        {
            loadQuizes();

            quiz_table.DataSource = quiz_list.Select(o => new
            { Name = o.Name, Type = o.Type, Answered = o.Answered, Language = o.Language, Creator = o.Creator }).ToList();

            quiz_table.Rows[0].Selected = false;
        }

        private void quiz_table_MouseClick(object sender, MouseEventArgs e)
        {
            foreach (DataGridViewRow row in quiz_table.Rows)
            {
                if (row.Selected == true && this.quiz_table.SelectedRows.Count == 1)
                {
                    Quiz quiz = quiz_list[row.Index];

                    if (quiz.Answered.Equals("True"))
                    {
                        MessageBox.Show("Your score on this quiz is " + quiz.Score.ToString(), "Score", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        loadQuestions(quiz);
                        utils.loadForm(this, new answer_quiz(question_list, quiz.ID));
                    }
                }
            }
        }

        private void loadQuizes()
        {
            SqlConnection cn = startpage.cn;

            using (SqlCommand cmd = new SqlCommand("getUserQuizes", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@user_id", SqlDbType.Int).Value = login.id;

                cn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.HasRows && reader.Read())
                    {
                        Quiz quiz = new Quiz();

                        quiz.ID = Convert.ToInt32(reader["id"]);
                        quiz.Type = reader["type"].ToString();
                        quiz.Name = reader["name"].ToString();
                        quiz.Creator = reader["creator"].ToString();
                        quiz.Language = reader["language"].ToString();
                        quiz.Answered = reader["answered"].ToString();
                        quiz.Score = Convert.ToInt32(reader["score"]);

                        quiz_list.Add(quiz);
                    }
                }
                cn.Close();
            }
        }
        private void loadQuestions(Quiz quiz)
        {
            SqlConnection cn = startpage.cn;
            using (SqlCommand cmd = new SqlCommand("getQuizQuestions", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@quiz_id", SqlDbType.Int).Value = quiz.ID;

                cn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.HasRows && reader.Read())
                    {
                        Answer a = new Answer();
                        a.text = reader["answer"].ToString();
                        a.score = Convert.ToInt32(reader["score"]);

                        Question q = null;
                        int question_id = Convert.ToInt32(reader["question_id"]);
                        int q_index = getQuestion(question_id);
                        if (q_index == -1)
                        {
                            q = new Question();
                            q.question_id = question_id;
                            q.quiz_id = Convert.ToInt32(reader["quiz_id"]);
                            q.question_id = Convert.ToInt32(reader["question_id"]);
                            q.text = reader["question_text"].ToString();
                            q.type = reader["type"].ToString();
                            q.language = reader["designation"].ToString();
                            q.answers = new List<Answer>();
                            question_list.Add(q);
                        }
                        else
                        {
                            q = question_list[q_index];
                        }
                        q.answers.Add(a);
                    }
                }
                cn.Close();
            }
        }
        private int getQuestion(int question_id)
        {
            int res = -1;
            for (int i = 0; i < question_list.Count; i++)
            {
                Question q = question_list[i];
                if (q.question_id == question_id)
                    res = i;
            }
            return res;
        }

        private void look_for_teacher_button_Click(object sender, EventArgs e)
        {

        }

        private void leaderboards_button_Click(object sender, EventArgs e)
        {
            utils.loadForm(this, new leaderboards());
        }

        private void homepage_button_Click(object sender, EventArgs e)
        {
            utils.loadForm(this, new student_page());
        }
    }

    public class Question
    {
        public int quiz_id { get; set; }
        public int question_id { get; set; }
        public String text { get; set; }
        public List<Answer> answers { get; set; }
        public String type { get; set; }
        public String language { get; set; }
    }

    public class Answer
    {
        public String text { get; set; }
        public int score { get; set; }
    }

    public class Quiz
    {
        public int ID { get; set; }
        public String Name { get; set; }
        public String Type { get; set; }
        public String Answered { get; set; }
        public String Language { get; set; }
        public String Creator { get; set; }
        public String NumberQuestions { get; set; }
        public int Score { get; set; }
    }
}
