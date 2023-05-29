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

        List<Quiz> quizlist = new List<Quiz>();
        List<Question> questionlist = new List<Question>();
        public quizes_to_answer()
        {
            InitializeComponent();
        }

        private void students_list_Load(object sender, EventArgs e)
        {
            loadQuizes();
            dataGridView1.DataSource = quizlist;
            dataGridView1.Columns["NumberQuestions"].Visible = false;
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            dataGridView1.Rows[0].Selected = false;
        }
        private void loadQuizes()
        {
            SqlConnection cn = homepage.cn;
            try
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand("getQuizes", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.Add("@user_id", SqlDbType.Int).Value = login.id;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Quiz q = new Quiz();

                                q.ID = Convert.ToInt32(reader["id"]);
                                q.Answered = "False";

                                q.Type = reader["type"].ToString();

                                if (reader["teacher_name"] != DBNull.Value)
                                    q.Creator = reader["teacher_name"].ToString();
                                else
                                    q.Creator = "LingoLearn";

                                q.Language = reader["designation"].ToString();

                                if (reader["user_id"] != DBNull.Value && reader["user_id"].ToString().Equals(login.id.ToString()))
                                {
                                    q.Answered = "True";
                                }

                                Boolean found = false;
                                int index = -1;
                                for(int i = 0; i < quizlist.Count; i++)
                                {
                                    Quiz quiz = quizlist[i];
                                    if(quiz.ID == q.ID)
                                    {
                                        found = true;
                                        index = i;
                                    }
                                }
                                if(!found)
                                    quizlist.Add(q);
                                else if(found && quizlist[index].Answered.Equals("False") && q.Answered.Equals("True"))
                                {
                                    quizlist.RemoveAt(index);
                                    quizlist.Insert(index, q);
                                }
                            }
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

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Selected == true && this.dataGridView1.SelectedRows.Count == 1)
                {
                    int index = row.Index;
                    SqlConnection cn = homepage.cn;
                    if (dataGridView1.Rows[index].Cells[2].Value.ToString().Equals("True"))
                    {
                        using (SqlCommand cmd = new SqlCommand("getScore", cn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.Add("@user_id", SqlDbType.Int).Value = login.id;
                            cmd.Parameters.Add("@quiz_id", SqlDbType.Int).Value = Convert.ToInt32(dataGridView1.Rows[index].Cells[0].Value);

                            cmd.Parameters.Add("@score", SqlDbType.Int).Direction = ParameterDirection.Output;

                            cn.Open();
                            cmd.ExecuteNonQuery();
                            cn.Close();
                            int score = 0;
                            if(cmd.Parameters["@score"].Value != DBNull.Value)
                                score = Convert.ToInt32(cmd.Parameters["@score"].Value);
                            MessageBox.Show("Your score on this quiz is " + score.ToString(), "Score", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        int quiz_id = Convert.ToInt32(dataGridView1.Rows[index].Cells[0].Value);
                        using (SqlCommand cmd = new SqlCommand("getQuestions", cn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@quiz_id", SqlDbType.Int).Value = quiz_id;
                            cn.Open();
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    while (reader.Read())
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
                                            questionlist.Add(q);
                                        }
                                        else
                                        {
                                            q = questionlist[q_index];
                                        }
                                        q.answers.Add(a);
                                    }
                                }
                            } cn.Close();
                        }
                        var frm = new answer_quiz(questionlist, quiz_id);
                        frm.Location = this.Location;
                        frm.StartPosition = FormStartPosition.Manual;
                        frm.Show();
                        this.Hide();
                    }
                }
            }
        }
        private int getQuestion(int question_id)
        {
            int res = -1;
            for (int i = 0; i < questionlist.Count; i++)
            {
                Question q = questionlist[i];
                if (q.question_id == question_id)
                    res = i;
            }   
            return res;
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
    }
}
