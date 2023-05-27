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

        List<Quiz> list = new List<Quiz>();
        public quizes_to_answer()
        {
            InitializeComponent();
        }

        private void students_list_Load(object sender, EventArgs e)
        {
            loadQuizes();
            dataGridView1.DataSource = list;
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

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Quiz q = new Quiz();

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

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Selected ==true && this.dataGridView1.SelectedRows.Count == 1)
                {
                    // get information of 1st column from the row
                    String index = row.Index.ToString();

                    var frm = new student_page();
                    frm.Location = this.Location;
                    frm.StartPosition = FormStartPosition.Manual;
                    frm.Show();
                    this.Close();
                    return;
                }
            }
        }
    }

    public class Quiz
    {
        public String Type { get; set; }
        public String Answered { get; set; }
        public String Language { get; set; }
        public String Creator { get; set; }
    }
}
