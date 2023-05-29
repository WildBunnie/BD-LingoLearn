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
    public partial class settings : Form
    {
        String available;
        public settings()
        {
            InitializeComponent();
            availabilityCheck();
        }

        private void availabilityCheck()
        {
            SqlConnection cn = homepage.cn;
            try
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand("getAvailability", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = login.id;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            this.available = reader["available"].ToString();
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

            if (available.Equals("True"))
            {
                yes_available.Checked = true;
            }
            else
            {
                no_available.Checked = true;
            }
        }

        private void homepage_button_Click(object sender, EventArgs e)
        {
            var frm = new Form();
            if (login.role == 3)
                frm = new student_teacher_page();
            else if (login.role == 2)
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

        private void settings_button_Click(object sender, EventArgs e)
        {
            teaches_panel.Visible = false;
            availability_panel.Visible = false;
            language_panel.Visible = false;
            delete_account_panel.Visible = false;
            change_pass_panel.Visible = true;
        }

        private void updatePassword(String password)
        {
            SqlConnection cn = homepage.cn;

            try
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand("updatePassword", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = login.id;
                    cmd.Parameters.Add("@password", SqlDbType.VarChar, 40).Value = password;
                    cmd.ExecuteNonQuery();
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

        private void confirm_pass_Click(object sender, EventArgs e)
        {
            updatePassword(password_textbox.Text);
            MessageBox.Show("Password changed successfully", "Password Changed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            teaches_panel.Visible = true;
            availability_panel.Visible = true;
            language_panel.Visible = true;
            change_pass_panel.Visible = false;
        }

        private void cancel_pass_Click(object sender, EventArgs e)
        {
            teaches_panel.Visible = true;
            availability_panel.Visible = true;
            language_panel.Visible = true;
            change_pass_panel.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            teaches_panel.Visible = false;
            availability_panel.Visible = false;
            language_panel.Visible = false;
            change_pass_panel.Visible = false;
            delete_account_panel.Visible = true;
        }

        private void delete_button_Click(object sender, EventArgs e)
        {
            deleteUser();
            MessageBox.Show("User deleted successfully", "User deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
            var homepage = new homepage();
            homepage.Show();
            this.Close();
        }

        private void cancel_deletion_button_Click(object sender, EventArgs e)
        {
            teaches_panel.Visible = true;
            availability_panel.Visible = true;
            language_panel.Visible = true;
            delete_account_panel.Visible = false;
        }

        private void deleteUser()
        {
            SqlConnection cn = homepage.cn;
            try
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand("deleteUser", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = login.id;
                    cmd.ExecuteNonQuery();
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

        private void yes_available_CheckedChanged(object sender, EventArgs e)
        {
            if (!yes_available.Checked)
            {
                SqlConnection cn = homepage.cn;
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("updateAvailability", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@id", SqlDbType.Int).Value = login.id;
                        cmd.Parameters.Add("@bool", SqlDbType.Bit).Value = 1;
                        cmd.ExecuteNonQuery();
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
        }

        private void no_available_CheckedChanged(object sender, EventArgs e)
        {
            if (!no_available.Checked)
            {
                SqlConnection cn = homepage.cn;
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("updateAvailability", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@id", SqlDbType.Int).Value = login.id;
                        cmd.Parameters.Add("@bool", SqlDbType.Bit).Value = 0;
                        cmd.ExecuteNonQuery();
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
        }
    }
}
