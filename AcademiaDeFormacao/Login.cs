 using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using AcademiaDeFormacao;

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

        #region Utils
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
        #endregion

        #region MoveTo
        private void lbl_singUp_Click(object sender, EventArgs e)
        {
            this.Hide();
            new SignUp(this).Show();
        }

        #endregion

        #region Login
        private void btn_login_Click(object sender, EventArgs e)
        {
            string EncryptedPassword = EncryptPassword(txt_password.Text, 150);

            using (var context = new School())
            {

                try
                {
                    
                    Employee employee = context.Employees.FirstOrDefault(emp => emp.Username == txt_username.Text && emp.Password == EncryptedPassword);

                    if (employee != null)
                    {
                        this.AuthenticatedUser = txt_username.Text;
                        this.UserRole = employee.Role;
                        if (employee.AccountStatus == true) // Check if the account is enabled
                        {
                            
                            if (employee.Role == "Director" || employee.Role == "Secretary")
                            {
                                this.Hide();
                                new Menu(AuthenticatedUser, employee.Role.ToString(), this).Show();
                            }
                            else if (employee.Role == "Trainer" || employee.Role == "Trainee" || employee.Role == "Coordinator")
                            {
                                this.Hide();
                                new MenuTrainer(AuthenticatedUser, employee.Role.ToString(), this).Show();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Account is currently disabled.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else if (txt_username.Text == string.Empty && EncryptedPassword == string.Empty)
                    {
                            MessageBox.Show("Fields Empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txt_username.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txt_password.Text = string.Empty;
                        txt_username.Text = "";
                        txt_username.Focus();
                    }

                }
                catch (Exception ex)
                {
                    // Handle any exceptions that might occur during the database
                    MessageBox.Show("An error occurred while trying to log in: " + ex.Message);
                }
            }

        }

        #endregion

    }
}
