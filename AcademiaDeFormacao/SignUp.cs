﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using AcademiaDeFormacao;

namespace TryProject
{
    public partial class SignUp : Form
    {

        public SignUp(Form log)
        {
            InitializeComponent();
            void CloseForm(object sender, EventArgs e)
            {
                log.Close();
            }
            this.FormClosing += CloseForm;
        }


        private void lbl_ToLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Login().Show();
        }

        private void txt_password_TextChanged(object sender, EventArgs e)
        {
            if (check_ShowPassword.Checked)
            {
                txt_password.PasswordChar = '\0';
            }
            else
            {
                txt_password.PasswordChar = '*';
            }
        }

        private void txt_confirmPassword_TextChanged(object sender, EventArgs e)
        {
            if (check_ShowPassword.Checked)
            {
                txt_confirmPassword.PasswordChar = '\0';
            }
            else
            {
                txt_confirmPassword.PasswordChar = '*';
            }
        }

        private void check_ShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (check_ShowPassword.Checked)
            {
                txt_password.PasswordChar = '\0';
                txt_confirmPassword.PasswordChar = '\0';
            }
            else
            {
                txt_password.PasswordChar = '*';
                txt_confirmPassword.PasswordChar = '*';
            }
        }

        private void btn_register_Click(object sender, EventArgs e)
        {
            string EncryptedPassword = EncryptPassword(txt_password.Text, 150);
            string EncryptedPasswordConfirmation = EncryptPassword(txt_confirmPassword.Text, 150);

            if (txt_username.Text == string.Empty && txt_password.Text == string.Empty && txt_confirmPassword.Text == string.Empty)
            {
                MessageBox.Show("Fields Empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_username.Focus();
            }
            else if (EncryptedPassword == EncryptedPasswordConfirmation)
            {
                using (var context = new School())
                {
                    var existUser = context.Employees.FirstOrDefault(emp => emp.Username == txt_username.Text);
                    if (existUser != null)
                    {
                        MessageBox.Show("Username already exists", "Try another UserName", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txt_username.Text = "";
                        txt_username.Focus();
                    }
                    else
                    {
                        Employee NewRegister = new Employee(
                            txt_username.Text, txt_username.Text, EncryptedPassword
                            );
                        context.Employees.Add(NewRegister);
                        context.SaveChanges();
                        MessageBox.Show("Account ceated successfully, awaiting activation approval", "Registration Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        this.Hide();
                        new Login().Show();
                    }
                }

                txt_username.Text = "";
                txt_password.Text = "";
                txt_confirmPassword.Text = "";

            }
            else
            {
                txt_password.Text = "";
                txt_confirmPassword.Text = "";
                MessageBox.Show("The passwords did not match", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_password.Focus();
            }

        }
        static string EncryptPassword(string password, int leap)
        {
            char[] chars = password.ToCharArray();

            for (int i = 0; i < chars.Length; i++)
            {
                if (char.IsLetter(chars[i]))
                {
                    char baseChar = char.IsLower(chars[i]) ? 'a' : 'A';
                    chars[i] = (char)(baseChar + (chars[i] - baseChar + leap) % 26);
                }
            }

            return new string(chars);
        }
        private void btn_clear_Click(object sender, EventArgs e)
        {
            txt_username.Text = "";
            txt_password.Text = "";
            txt_confirmPassword.Text = "";
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Login().Show();
        }
    }
}
