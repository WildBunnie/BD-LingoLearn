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
    public partial class startpage : Form
    {

        public static SqlConnection cn;

        public startpage()
        {
            InitializeComponent();
        }

        private void startpage_Load(object sender, EventArgs e)
        {
            cn = new SqlConnection("Data Source = localhost;" +
                        "Initial Catalog = LingoLearn;" +
                        "uid = joao_andrade;" +
                        "password = tmFJ.<?~fMSR8Xr*Eck|d");
        }

        private void sign_in_button_Click(object sender, EventArgs e)
        {
            utils.loadForm(this, new login());
        }

        private void register_label_Click(object sender, EventArgs e)
        {
            utils.loadForm(this, new register());
        }
    }
}
