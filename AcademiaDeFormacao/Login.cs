using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TryProject
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
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
            this.Hide();
            new Menu().Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

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
    }
}
