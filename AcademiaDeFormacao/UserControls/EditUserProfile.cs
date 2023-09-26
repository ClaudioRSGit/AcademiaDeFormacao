using System;
using System.Linq;
using System.Windows.Forms;

namespace AcademiaDeFormacao.UserControls
{
    public partial class EditUserProfile : UserControl
    {
        string authUser;
        public EditUserProfile()
        {
            InitializeComponent();

            // Associate the event handler with the txt_contact control's KeyDown event
            txt_contact.KeyDown += new KeyEventHandler(txt_contact_KeyDown);
        }

        public void PopulateFormFields(string userName)
        {
            authUser = userName;
            try
            {
                using (var context = new School())
                {
                    var employee = context.Employees.FirstOrDefault(emp => emp.Username == userName);

                    if (employee != null)
                    {
                        txt_role.Text = employee.Role;
                        txt_id.Text = employee.EmployeeId.ToString();
                        txt_username.Text = employee.Username;
                        txt_name.Text = employee.Name;
                        txt_address.Text = employee.Address;
                        txt_newPassword.Text = employee.Password;
                        txt_email.Text = employee.Email;
                        txt_contact.Text = employee.Contact;
                        txt_salary.Text = employee.Salary.ToString();
                        txt_dateOfBirth.Text = employee.DateOfBirth.ToString();
                        txt_contractEndDate.Text = employee.ContractEndDate.ToString();
                        txt_criminalRecordEndDate.Text = employee.CriminalRecordEndDate.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }

        }

        private void btn_saveData_Click(object sender, EventArgs e)
        {
            string EncryptedPassword = EncryptPassword(txt_newPassword.Text, 150);

            if (txt_newPassword.Text == txt_confirmPassword.Text)
            {
                using (var context = new School())
                {
                    var employee = context.Employees.FirstOrDefault(emp => emp.Username == authUser);

                    if (employee != null)
                    {
                        employee.Name = txt_name.Text;
                        employee.Address = txt_address.Text;
                        employee.Password = EncryptedPassword;
                        employee.Email = txt_email.Text;
                        employee.Contact = txt_contact.Text;

                        context.SaveChanges();
                        MessageBox.Show("Employee data updated successfully!");
                    }
                }
            }
            else
            {
                MessageBox.Show("New password and confirm password do not match.");
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
        private void txt_onlyNumbers(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is a valid numeric character or control key
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                e.KeyChar != '\b' && e.KeyChar != '\u007F') // Backspace and Delete keys
            {
                e.Handled = true; // Cancel the key press event
            }
        }

        private void txt_onlyLetters(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is a valid letter character or control key
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) &&
                e.KeyChar != ' ' && e.KeyChar != '\'' && e.KeyChar != '-' &&
                e.KeyChar != '\b' && e.KeyChar != '\u007F') // Backspace and Delete keys
            {
                e.Handled = true; // Cancel the key press event
            }
        }

        private void txt_contact_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                e.Handled = true;
            }
        }

    }
}
