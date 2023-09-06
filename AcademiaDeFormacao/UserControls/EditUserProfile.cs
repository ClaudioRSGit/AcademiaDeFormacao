using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace AcademiaDeFormacao.UserControls
{
    public partial class EditUserProfile : UserControl
    {
        string authUser;
        public EditUserProfile()
        {
            InitializeComponent();
            //this.AuthenticatedUser = userName;
            //PopulateFormFields(userName);
        
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (txt_newPassword.Text == txt_confirmPassword.Text)
            {
                using (var context = new School())
                {
                    var employee = context.Employees.FirstOrDefault(emp => emp.Username == authUser);

                    if (employee != null)
                    {
                        employee.Name = txt_name.Text;
                        employee.Address = txt_address.Text;
                        employee.Password = txt_newPassword.Text;
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
            // Check if Ctrl+V (paste) is pressed
            if (e.Control && e.KeyCode == Keys.V)
            {
                // Prevent the paste operation
                e.Handled = true;
            }
        }

        private void txt_contact_KeyDown(object sender, KeyPressEventArgs e)
        {

        }
    }
}
