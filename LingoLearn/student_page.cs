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
    public partial class student_page : Form
    {

        public student_page()
        {
            InitializeComponent();
        }

        private void student_page_Load(object sender, EventArgs e)
        {
            hello_label.Text = String.Format("Hello {0}, what would you like to do?", login.username);
        }

        private void answer_quizes_button_Click(object sender, EventArgs e)
        {
            utils.loadForm(this, new quizes_to_answer());
        }

        private void look_for_teacher_button_Click(object sender, EventArgs e)
        {

        }

        private void leaderboards_button_Click(object sender, EventArgs e)
        {
            utils.loadForm(this, new leaderboards());
        }

        private void settings_button_Click(object sender, EventArgs e)
        {

        }
    }
}
