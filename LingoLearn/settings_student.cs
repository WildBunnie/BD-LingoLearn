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
    public partial class settings_student : Form
    {
        String available;
        bool loaded = false;
        
        SqlConnection cn = startpage.cn;


        public settings_student()
        {
            InitializeComponent();
            availability_load();
            language_load();
            loaded = true;
        }

        private void availability_load()
        {
            try
            {
                cn.Open();
                    using (SqlCommand cmd = new SqlCommand("getAvailability", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@id", SqlDbType.Int).Value = login.id;
                        cmd.Parameters.Add("@user_role", SqlDbType.Int).Value = login.role;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                this.available = reader["looking_for_teacher"].ToString();
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

        private void language_load()
        {
            try
            {
                cn.Open();
                List<String> languages_to_activate = new List<String>();
                using (SqlCommand cmd = new SqlCommand("getDesignations", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = login.id;
                    cmd.Parameters.Add("@user_role", SqlDbType.Int).Value = login.role;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            activateLanguage(reader["designation"].ToString());
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
        
        private void activateLanguage(String designation)
        {
            // horrible code practice due to DRY principle, but we're short on time
            if (designation.Equals(portuguese_box.Text))
            {
                portuguese_box.Checked = true;  return;
            }
            else if (designation.Equals(english_box.Text))
            {
                english_box.Checked = true; return;
            }
            else if (designation.Equals(italian_box.Text))
            {
                italian_box.Checked = true; return;
            }
            else if (designation.Equals(french_box.Text))
            {
                french_box.Checked = true; return;
            }
            else if (designation.Equals(spanish_box.Text))
            {
                spanish_box.Checked = true; return;
            }
            else if (designation.Equals(korean_box.Text))
            {
                korean_box.Checked = true; return;
            }
                
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
            utils.loadForm(this, new startpage());
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
            if (yes_available.Checked && loaded)
            {
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
            if (no_available.Checked && loaded)
            {
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

        //
        // SP strings to make it easier to change at will
        //
        String spLearn = "addLanguage";
        String spRemove = "removeLanguage";
        // Languages check - Sad code below //
        private void portuguese_box_CheckedChanged(object sender, EventArgs e)
        {
            if (portuguese_box.Checked && loaded)
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand(spLearn, cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@id", SqlDbType.Int).Value = login.id;
                        cmd.Parameters.Add("@designation", SqlDbType.VarChar, 40).Value = portuguese_box.Text;
                        cmd.Parameters.Add("@user_role", SqlDbType.Int).Value = login.role;
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
            else
            {
                if (loaded)
                {
                    try
                    {
                        cn.Open();
                        using (SqlCommand cmd = new SqlCommand(spRemove, cn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.Add("@id", SqlDbType.Int).Value = login.id;
                            cmd.Parameters.Add("@designation", SqlDbType.VarChar, 40).Value = portuguese_box.Text;
                            cmd.Parameters.Add("@user_role", SqlDbType.Int).Value = login.role;
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

        private void spanish_box_CheckedChanged(object sender, EventArgs e)
        {
            if (spanish_box.Checked && loaded)
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand(spLearn, cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@id", SqlDbType.Int).Value = login.id;
                        cmd.Parameters.Add("@designation", SqlDbType.VarChar, 40).Value = spanish_box.Text;
                        cmd.Parameters.Add("@user_role", SqlDbType.Int).Value = login.role;
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
            else
            {
                if (loaded)
                {
                    try
                    {
                        cn.Open();
                        using (SqlCommand cmd = new SqlCommand(spRemove, cn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.Add("@id", SqlDbType.Int).Value = login.id;
                            cmd.Parameters.Add("@designation", SqlDbType.VarChar, 40).Value = spanish_box.Text;
                            cmd.Parameters.Add("@user_role", SqlDbType.Int).Value = login.role;
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

        private void english_box_CheckedChanged(object sender, EventArgs e)
        {
            if (english_box.Checked && loaded)
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand(spLearn, cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@id", SqlDbType.Int).Value = login.id;
                        cmd.Parameters.Add("@designation", SqlDbType.VarChar, 40).Value = english_box.Text;
                        cmd.Parameters.Add("@user_role", SqlDbType.Int).Value = login.role;
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
            else
            {
                if (loaded)
                {
                    try
                    {
                        cn.Open();
                        using (SqlCommand cmd = new SqlCommand(spRemove, cn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.Add("@id", SqlDbType.Int).Value = login.id;
                            cmd.Parameters.Add("@designation", SqlDbType.VarChar, 40).Value = english_box.Text;
                            cmd.Parameters.Add("@user_role", SqlDbType.Int).Value = login.role;
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

        private void korean_box_CheckedChanged(object sender, EventArgs e)
        {
            if (korean_box.Checked && loaded)
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand(spLearn, cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@id", SqlDbType.Int).Value = login.id;
                        cmd.Parameters.Add("@designation", SqlDbType.VarChar, 40).Value = korean_box.Text;
                        cmd.Parameters.Add("@user_role", SqlDbType.Int).Value = login.role;
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
            else
            {
                if (loaded)
                {
                    try
                    {
                        cn.Open();
                        using (SqlCommand cmd = new SqlCommand(spRemove, cn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.Add("@id", SqlDbType.Int).Value = login.id;
                            cmd.Parameters.Add("@designation", SqlDbType.VarChar, 40).Value = korean_box.Text;
                            cmd.Parameters.Add("@user_role", SqlDbType.Int).Value = login.role;
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

        private void french_box_CheckedChanged(object sender, EventArgs e)
        {
            if (french_box.Checked && loaded)
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand(spLearn, cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@id", SqlDbType.Int).Value = login.id;
                        cmd.Parameters.Add("@designation", SqlDbType.VarChar, 40).Value = french_box.Text;
                        cmd.Parameters.Add("@user_role", SqlDbType.Int).Value = login.role;
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
            else
            {
                if (loaded)
                {
                    try
                    {
                        cn.Open();
                        using (SqlCommand cmd = new SqlCommand(spRemove, cn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.Add("@id", SqlDbType.Int).Value = login.id;
                            cmd.Parameters.Add("@designation", SqlDbType.VarChar, 40).Value = french_box.Text;
                            cmd.Parameters.Add("@user_role", SqlDbType.Int).Value = login.role;
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

        private void italian_box_CheckedChanged(object sender, EventArgs e)
        {
            if (italian_box.Checked && loaded)
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand(spLearn, cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@id", SqlDbType.Int).Value = login.id;
                        cmd.Parameters.Add("@designation", SqlDbType.VarChar, 40).Value = italian_box.Text;
                        cmd.Parameters.Add("@user_role", SqlDbType.Int).Value = login.role;
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
            else
            {
                if (loaded)
                {
                    try
                    {
                        cn.Open();
                        using (SqlCommand cmd = new SqlCommand(spRemove, cn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.Add("@id", SqlDbType.Int).Value = login.id;
                            cmd.Parameters.Add("@designation", SqlDbType.VarChar, 40).Value = italian_box.Text;
                            cmd.Parameters.Add("@user_role", SqlDbType.Int).Value = login.role;
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

        private void logout_button_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Logged out successfully", "User log out", MessageBoxButtons.OK, MessageBoxIcon.Information);
            utils.loadForm(this, new startpage());
        }
    }
}
