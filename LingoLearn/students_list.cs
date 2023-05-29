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
    public partial class students_list : Form
    {

        List<Student> list = new List<Student>();
        public students_list()
        {
            InitializeComponent();
        }

        private void students_list_Load(object sender, EventArgs e)
        {
            loadStudents();
            dataGridView1.DataSource = list;
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        private void loadStudents()
        {
            SqlConnection cn = startpage.cn;
            try
            {
                String query = String.Format("SELECT username, designation " +
                                                "FROM \"USER\" JOIN TEACHES_STUDENTS ON id = learner_id " +
                                                "WHERE teacher_id = " + login.id.ToString());

                cn.Open();
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Student s = new Student();
                                s.name = reader["username"].ToString();
                                s.language = reader["designation"].ToString();

                                list.Add(s);
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
            utils.loadForm(this, new add_quizes());

        }

        private void leaderboards_button_Click(object sender, EventArgs e)
        {
            utils.loadForm(this, new leaderboards());

        }

        private void homepage_button_Click(object sender, EventArgs e)
        {
            utils.loadForm(this, new teacher_page());

        }
    }
    public class Student
    {
        public String name { get; set; }
        public String language { get; set; }
    }
}
