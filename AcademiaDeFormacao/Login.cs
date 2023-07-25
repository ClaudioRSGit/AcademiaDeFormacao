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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TryProject
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();

        }

        //Con Goncalo
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-VEKAU7O;Initial Catalog=ADOSMELHORES;Integrated Security=True");
        //Con Claudio
        //SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-D08A4VR;Initial Catalog=ADOSMELHORES;Integrated Security=True");


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
            SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM Employee WHERE Username='" + txt_username.Text + "' AND Password='" + txt_password.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                this.Hide();
                new Menu().Show();
            }
            else
            {
                MessageBox.Show("Invalid username or password");
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
