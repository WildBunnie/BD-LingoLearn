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

        //SqlConnection cn;

        public student_page()
        {
            InitializeComponent();
        }

        private void student_page_Load(object sender, EventArgs e)
        {
            hello_label.Text = String.Format("Hello {0}, what would you like to do?", login.username);
        }
    }
}
