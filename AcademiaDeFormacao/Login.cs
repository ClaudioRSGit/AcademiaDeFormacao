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
using System.IO;

namespace TryProject
{
    public partial class Login : Form
    {
        public string AuthenticatedUser { get; set; }
        public string UserRole { get; set; }

        public Login()
        {
            InitializeComponent();
            txt_password.KeyPress += TxtPassword_KeyPress;
            txt_username.KeyPress += Txt_username_KeyPress;
        }

        private void Txt_username_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btn_login.PerformClick();
            }
        }

        private void TxtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btn_login.PerformClick();
            }
        }


        private void btn_clear_Click(object sender, EventArgs e)
        {
            txt_username.Text = "";
            txt_password.Text = "";
        }

        private void lbl_singUp_Click(object sender, EventArgs e)
        {
            this.Hide();
            new SignUp().Show();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            

            using(var context = new School())
            {

                try
                {
                    
                    Employee employee = context.Employees.FirstOrDefault(emp => emp.Username == txt_username.Text && emp.Password == txt_password.Text);

                    if (employee != null)
                    {
                        if (employee.Role == "Director" || employee.Role == "Secretary")
                        {
                            this.AuthenticatedUser = txt_username.Text;
                            this.UserRole = employee.Role;
                            this.Hide();
                            new Menu(AuthenticatedUser, UserRole).Show();
                        }
                        else
                        {
                            this.AuthenticatedUser = txt_username.Text;
                            this.UserRole = employee.Role;
                            //this.Hide();
                            MessageBox.Show("OUTRO FORM");
                            // vai entrar no outro menu
                        }
                    }
                    else if (txt_username.Text == string.Empty && txt_password.Text == string.Empty)
                    {
                            MessageBox.Show("Fields Empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txt_username.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txt_password.Text = string.Empty;
                        txt_username.Text = string.Empty;
                        txt_username.Focus();
                    }

                }
                catch (Exception ex)
                {
                    // Handle any exceptions that might occur during the database query
                    MessageBox.Show("An error occurred while trying to log in: " + ex.Message);
                }
            }

        }


        private void check_ShowPassword_CheckedChanged(object sender, EventArgs e)
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


        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.pictureBox3.Parent = this.pictureBox1;
            this.pictureBox3.BackColor = Color.Yellow;
        }

        
    }
}
