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
    public partial class homepage : Form
    {

        public static SqlConnection cn;

        public homepage()
        {
            InitializeComponent();
        }

        private void homepage_Load(object sender, EventArgs e)
        {
            cn = new SqlConnection("Data Source = localhost;" +
                        "Initial Catalog = LingoLearn;" +
                        "uid = joao_andrade;" +
                        "password = tmFJ.<?~fMSR8Xr*Eck|d");
        }

        private void sign_in_button_Click(object sender, EventArgs e)
        {
            var frm = new login();
            frm.Location = this.Location;
            frm.StartPosition = FormStartPosition.Manual;
            //frm.FormClosing += delegate { this.Show(); };
            frm.Show();
            this.Hide();
        }

        private void register_label_Click(object sender, EventArgs e)
        {
            var frm = new register();
            frm.Location = this.Location;
            frm.StartPosition = FormStartPosition.Manual;
            frm.Show();
            this.Hide();
        }


    }
}
