using System;
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
        public SignUp()
        {
            InitializeComponent();
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
            if (txt_username.Text == string.Empty && txt_password.Text == string.Empty && txt_confirmPassword.Text == string.Empty)
            {
                MessageBox.Show("Fields Empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_username.Focus();
            }
            else if (txt_password.Text == txt_confirmPassword.Text)
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
                            txt_username.Text, txt_password.Text
                            );

                        context.Employees.Add(NewRegister);
                        context.SaveChanges();
                        MessageBox.Show("Account Successfully Created", "Registration Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

        private void btn_clear_Click(object sender, EventArgs e)
        {
            txt_username.Text = "";
            txt_password.Text = "";
            txt_confirmPassword.Text = "";
        }
    }
}
