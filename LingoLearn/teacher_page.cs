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
    public partial class teacher_page : Form
    {

        //SqlConnection cn;

        public teacher_page()
        {
            InitializeComponent();
        }

        private void teacher_page_Load(object sender, EventArgs e)
        {
            hello_label.Text = String.Format("Hello {0}, what would you like to do?", login.username);
        }

        private void students_button_Click(object sender, EventArgs e)
        {
            utils.loadForm(this, new students_list());
        }

        private void add_quizzes_button_Click(object sender, EventArgs e)
        {
            utils.loadForm(this, new add_quizes());
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
