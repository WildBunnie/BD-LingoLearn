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
    public partial class register : Form
    {

        public register()
        {
            InitializeComponent();
        }

        private void register_button_Click(object sender, EventArgs e)
        {
            String name = name_textbox.Text;
            String email = email_textbox.Text;
            String password = password_textbox.Text;

            int isStudent = 0, isTeacher = 0;
            if (student_radio.Checked)
                isStudent = 1;
            else if (teacher_radio.Checked)
                isTeacher = 1;

            String errorMessage;

            if (String.IsNullOrEmpty(email) || String.IsNullOrEmpty(password) || String.IsNullOrEmpty(name))
            {
                errorMessage = "All fields must be filled";
            }
            else if (!utils.IsValidEmail(email))
            {
                errorMessage = "Invalid Email";
            }
            else if (isStudent == 0 && isTeacher == 0)
            {
                errorMessage = "You must be a student and/or a teacher";
            }
            //else if (password.Length < 8)
            //{
            //    errorMessage = "Password must be at least 8 characters long";
            //}
            else
            {
                user_register(name, email, password, isStudent, isTeacher);
                return;
            }
            MessageBox.Show(errorMessage, "login error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void user_register(String name, String email, String password, int isStudent, int isTeacher)
        {
            SqlConnection cn = startpage.cn;
            using (SqlCommand cmd = new SqlCommand("addUser", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@username", SqlDbType.VarChar, 40).Value = name;
                cmd.Parameters.Add("@email", SqlDbType.VarChar, 40).Value = email;
                cmd.Parameters.Add("@password", SqlDbType.VarChar, 40).Value = password;
                cmd.Parameters.Add("@isLearner", SqlDbType.Bit).Value = isStudent;
                cmd.Parameters.Add("@isTeacher", SqlDbType.Bit).Value = isTeacher;

                cmd.Parameters.Add("@returnValue", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();

                int result = Convert.ToInt32(cmd.Parameters["@returnValue"].Value);

                if (result == 1)
                {
                    MessageBox.Show("register successful", "register successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    utils.loadForm(this, new login());
                }
                else if (result == 0)
                {
                    MessageBox.Show("an account is already registered with that email", "email already in use", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void login_button_Click(object sender, EventArgs e)
        {
            utils.loadForm(this, new login());
        }
    }
}
