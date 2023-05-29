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
            var frm = new students_list();
            frm.Location = this.Location;
            frm.StartPosition = FormStartPosition.Manual;
            frm.Show();
            this.Close();
        }

        private void add_quizzes_button_Click(object sender, EventArgs e)
        {
            var add_quizzes = new add_quizes();
            add_quizzes.Show();
            this.Close();
        }

        private void leaderboards_button_Click(object sender, EventArgs e)
        {
            var frm = new leaderboards();
            frm.Location = this.Location;
            frm.StartPosition = FormStartPosition.Manual;
            frm.Show();
            this.Close();
        }

        private void settings_button_Click(object sender, EventArgs e)
        {
            var settings = new settings_teacher();
            settings.Show();
            this.Close();
        }
    }
}
