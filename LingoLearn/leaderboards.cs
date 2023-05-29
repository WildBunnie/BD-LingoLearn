﻿using System;
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
    public partial class leaderboards : Form
    {
        List<LeaderboardStudent> lb = new List<LeaderboardStudent>();
        public leaderboards()
        {
            InitializeComponent();
        }

        private void leaderboards_Load(object sender, EventArgs e)
        {
            loadStudents();
            dataGridView1.DataSource = lb;
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            dataGridView1.Rows[0].Selected = false;
        }

        public void loadStudents()
        {
            SqlConnection cn = homepage.cn;

            cn.Open();
            using (SqlCommand cmd = new SqlCommand("getLeaderboard", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.Add("@user_id", SqlDbType.Int).Value = login.id;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            LeaderboardStudent s = new LeaderboardStudent();
                            s.name = String.Format("{0}#{1}", reader["username"].ToString(), reader["id"].ToString());
                            s.score = Convert.ToInt32(reader["score"]);
                            lb.Add(s);
                        }
                    }
                }
            }
            cn.Close();
        }

        private void homepage_button_Click(object sender, EventArgs e)
        {
            var frm = new Form();
            if (login.role == 2)
                frm = new teacher_page();
            else
                frm = new student_page();
            frm.Location = this.Location;
            frm.StartPosition = FormStartPosition.Manual;
            frm.Show();
            this.Hide();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
        }
    }

    public class LeaderboardStudent
    {
        public String name { get; set; }
        public int score { get; set; }
    }
}
