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
    public partial class add_quizes : Form
    {

        bool verbs = false;
        bool grammar = false;
        int quiz_id;
        String designation;

        List<Quiz> list = new List<Quiz>();

        SqlConnection cn = homepage.cn;

        public add_quizes()
        {
            InitializeComponent();
        }

        private void quiz_list_load(object sender, EventArgs e)
        {
            quiz_load();
            dataGridView1.DataSource = list;
            dataGridView1.Columns["Answered"].Visible = false;
            dataGridView1.Columns["Creator"].Visible = false;

            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void designations_load(object sender, EventArgs e)
        {
            getDesignations();
        }

        private void quiz_load()
        {
            try
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand("getProfessorQuizzes", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = login.id;
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Quiz q = new Quiz();
                                q.Type = reader["type"].ToString();
                                q.NumberQuestions = reader["n_questions"].ToString();
                                q.Language = reader["designation"].ToString();

                                list.Add(q);
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

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
        }

        private void add_quizzes_button_Click(object sender, EventArgs e)
        {
            var view_students = new students_list();
            view_students.Show();
            this.Close();
        }

        private void create_quiz_button_Click(object sender, EventArgs e)
        {
            if (verbs == true)
            {
                addQuiz("Verbs");
            }
            else if (grammar == true)
            {
                addQuiz("Grammar");
            }
            var add_quiz = new add_quiz(quiz_id, dropdown.SelectedItem.ToString());
            add_quiz.Show();
            this.Close();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            verbs = true;
            grammar = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            verbs = false;
            grammar = true;
        }

        public void getDesignations()
        {
            try
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand("getDesignations", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = login.id;
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                dropdown.Items.Add(reader["designation"].ToString());
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
                    cmd.Parameters.Add("@designation", SqlDbType.VarChar, 40).Value = dropdown.SelectedItem.ToString();
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
        
    }

}
