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
    public partial class teachers_list : Form
    {

        List<Teacher> teacher_list = new List<Teacher>();
        public teachers_list()
        {
            InitializeComponent();
        }

        private void students_list_Load(object sender, EventArgs e)
        {
            loadTeachers();
            teacher_table.DataSource = teacher_list;
            teacher_table.Columns["CountryCode"].Visible = false;
            foreach (DataGridViewColumn column in teacher_table.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            teacher_table.Rows[0].Selected = false;
        }
        private void loadTeachers()
        {
            SqlConnection cn = startpage.cn;

            using (SqlCommand cmd = new SqlCommand("getPossibleTeachers", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@user_id", SqlDbType.Int).Value = login.id;

                cn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.HasRows && reader.Read())
                    {
                        Teacher teacher = new Teacher();

                        teacher.ID = Convert.ToInt32(reader["id"]);
                        teacher.Name = reader["teacher_name"].ToString();
                        teacher.Language = reader["designation"].ToString();
                        teacher.CountryCode = reader["country_code"].ToString();
                        teacher.TeachesYou = reader["teaches_you"].ToString();

                        teacher_list.Add(teacher);
                    }
                }
                cn.Close();
            }
        }

        private void teacher_table_MouseClick(object sender, MouseEventArgs e)
        {
            foreach (DataGridViewRow row in teacher_table.Rows)
            {
                if (row.Selected == true && this.teacher_table.SelectedRows.Count == 1)
                {
                    Teacher teacher = teacher_list[row.Index];

                    if (teacher.TeachesYou.Equals("True"))
                    {
                        DialogResult result = MessageBox.Show("Do you want to stop being a student of this teacher?", "Leave Teacher", MessageBoxButtons.OKCancel);
                        if (result == DialogResult.OK)
                        {
                            SqlConnection cn = startpage.cn;
                            using (SqlCommand cmd = new SqlCommand("stopTeaching", cn))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;

                                cmd.Parameters.Add("@teacher_id", SqlDbType.Int).Value = teacher.ID;
                                cmd.Parameters.Add("@student_id", SqlDbType.Int).Value = login.id;
                                cmd.Parameters.Add("@country_code", SqlDbType.Int).Value = teacher.CountryCode;
                                cmd.Parameters.Add("@designation", SqlDbType.VarChar, 40).Value = teacher.Language;

                                cn.Open();
                                cmd.ExecuteNonQuery();
                                cn.Close();
                            }
                            utils.loadForm(this, new teachers_list());
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("Do you want to start being a student of this teacher?", "Get Teacher", MessageBoxButtons.OKCancel);

                        if (result == DialogResult.OK)
                        {
                            SqlConnection cn = startpage.cn;
                            using (SqlCommand cmd = new SqlCommand("startTeaching", cn))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;

                                cmd.Parameters.Add("@teacher_id", SqlDbType.Int).Value = teacher.ID;
                                cmd.Parameters.Add("@student_id", SqlDbType.Int).Value = login.id;
                                cmd.Parameters.Add("@country_code", SqlDbType.Int).Value = teacher.CountryCode;
                                cmd.Parameters.Add("@designation", SqlDbType.VarChar, 40).Value = teacher.Language;

                                cn.Open();
                                cmd.ExecuteNonQuery();
                                cn.Close();
                            }
                            utils.loadForm(this, new teachers_list());
                        }
                    }
                }
            }
        }

        private void leaderboards_button_Click(object sender, EventArgs e)
        {
            utils.loadForm(this, new leaderboards());
        }

        private void answer_quizzes_button_Click(object sender, EventArgs e)
        {
            utils.loadForm(this, new quizes_to_answer());
        }

        private void homepage_button_Click(object sender, EventArgs e)
        {
            utils.loadForm(this, new student_page());
        }
    }

    public class Teacher
    {
        public int ID { get; set; }
        public String Name { get; set; }
        public String Language { get; set; }
        public String CountryCode { get; set; }
        public String TeachesYou { get; set; }
    }
}
