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
    public partial class add_quizes : Form
    {

        bool verbs = false;
        bool grammar = false;
        int quiz_id;
        String designation;

        List<Quiz> list = new List<Quiz>();

        SqlConnection cn = startpage.cn;

        public add_quizes()
        {
            InitializeComponent();
        }

        private void quiz_list_load(object sender, EventArgs e)
        {
            quiz_load();
            loadDesignations();

            dataGridView1.DataSource = list;
            dataGridView1.Columns["Answered"].Visible = false;
            dataGridView1.Columns["Creator"].Visible = false;
            dataGridView1.Columns["ID"].Visible = false;
            dataGridView1.Columns["Score"].Visible = false;

            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
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
                                q.Name = reader["name"].ToString();
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
            utils.loadForm(this, new students_list());

        }

        private void create_quiz_button_Click(object sender, EventArgs e)
        {
            if ((!radioButton1.Checked && !radioButton2.Checked) || dropdown.SelectedIndex == -1 || quiz_name.TextLength == 0)
            {
                MessageBox.Show("Quiz options missing [Name/Language/Type]!", "Quiz creation error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (verbs == true)
                {
                    var add_quiz = new add_quiz(quiz_name.Text, "Verbs", quiz_id, dropdown.SelectedItem.ToString());
                    add_quiz.Show();
                }
                else if (grammar == true)
                {
                    var add_quiz = new add_quiz(quiz_name.Text, "Grammar", quiz_id, dropdown.SelectedItem.ToString());
                    add_quiz.Show();
                }


                this.Close();
            }
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

        public void loadDesignations()
        {
            try
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand("getDesignations", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = login.id;
                    cmd.Parameters.Add("@user_role", SqlDbType.Int).Value = login.role;
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

        private void homepage_button_Click(object sender, EventArgs e)
        {
            utils.loadForm(this, new teacher_page());
        }

        private void leaderboards_button_Click(object sender, EventArgs e)
        {
            utils.loadForm(this, new leaderboards());
        }

        private void settings_button_Click(object sender, EventArgs e)
        {
            utils.loadForm(this, new settings_teacher());
        }
    }

}
