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
    public partial class login : Form
    {

        public static String username;
        public static String email;
        public static int id;
        // 1 = student, 2 = teacher
        public static int role;

        public login()
        {
            InitializeComponent();
        }

        private void login_button_Click(object sender, EventArgs e)
        {
            String email = email_textbox.Text;
            String password = password_textbox.Text;
            String errorMessage;

            if (String.IsNullOrEmpty(email) || String.IsNullOrEmpty(password))
            {
                errorMessage = "All fields must be filled";
            }
            else if (!utils.IsValidEmail(email))
            {
                errorMessage = "Invalid Email";
            }
            //else if (password.Length < 8)
            //{
            //    errorMessage = "Password must be at least 8 characters long";
            //}
            else
            {
                user_login(email, password);
                return;
            }
            MessageBox.Show(errorMessage, "login error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void user_login(String email, String password)
        {
            SqlConnection cn = startpage.cn;
            using (SqlCommand cmd = new SqlCommand("userFromCredentials", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@email", SqlDbType.VarChar, 40).Value = email;
                cmd.Parameters.Add("@password", SqlDbType.VarChar, 40).Value = password;

                cmd.Parameters.Add("@id", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@username", SqlDbType.VarChar, 40).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@role", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.Parameters.Add("@returnValue", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();

                int result = Convert.ToInt32(cmd.Parameters["@returnValue"].Value);

                // -1 means the email is not in the database
                if (result == -1)
                {
                    MessageBox.Show("no account is registered with that email", "invalid email", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                // -2 means the email is in the database but the password does not match
                else if (result == -2)
                {
                    MessageBox.Show("incorrect password", "incorrect password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                // 1 means the password and email match
                else if (result == 1)
                {
                    login.id = Convert.ToInt32(cmd.Parameters["@id"].Value);
                    login.username = Convert.ToString(cmd.Parameters["@username"].Value);
                    login.role = Convert.ToInt32(cmd.Parameters["@role"].Value);

                    MessageBox.Show("logged in as " + String.Format("{0}#{1}", login.username, id), "login sucessfull", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    utils.loadForm(this, utils.getPageFromRole());
                }
            }
        }

        private void register_label_Click(object sender, EventArgs e)
        {
            utils.loadForm(this, new register());
        }
    }
}
