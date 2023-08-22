using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AcademiaDeFormacao.UserControls
{
    public partial class AddEmployee : UserControl
    {
        public AddEmployee()
        {
            InitializeComponent();
            cbx_timeExemption.Hide();
            cbx_Car.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void cmb_Role_SelectedIndexChanged(object sender, EventArgs e)
        {

            string selectedRole = cmb_Role.SelectedItem.ToString();

            switch (selectedRole)
            {
                case "Director":
                    cbx_Car.Show();
                    cbx_timeExemption.Show();
                    break;
                default:
                    cbx_timeExemption.Hide();
                    cbx_Car.Hide();
                    break;
            }
        }

        

        private void button_addEmployee_Click(object sender, EventArgs e)
        {
            string selectedRole = cmb_Role.SelectedItem.ToString();
            switch (selectedRole)
            {
                case "Secretary":
                case "Director":
                    using (var context = new School())
                    {
                        Director newDirector = new Director();

                        newDirector.Username = txt_username.Text;
                        newDirector.Password = txt_password.Text;
                        newDirector.Name = txt_name.Text;
                        newDirector.Email = txt_email.Text;
                        newDirector.Salary = Convert.ToDouble(txt_salary.Text);
                        newDirector.Role = selectedRole;
                        newDirector.Address = txt_address.Text;
                        newDirector.Contact = txt_contact.Text;
                        newDirector.ContractEndDate = dtp_ContractEndDate.Value;
                        newDirector.CriminalRecordEndDate = dtp_CriminalRecord.Value;
                        newDirector.MonthlyBonus = 1200;        //Colocar uma txt box talvez para escrever o input
                        newDirector.CompanyCar = cbx_Car.Checked;
                        newDirector.TimeExemption = cbx_timeExemption.Checked;

                        context.Directors.Add(newDirector);
                        context.SaveChanges();
                        MessageBox.Show("ADICIONADO");

                        //wipe all fields
                        txt_username.Text = "";
                        txt_password.Text = "";
                        txt_name.Text = "";
                        txt_email.Text = "";
                        txt_salary.Text = "";
                        txt_address.Text = "";
                        txt_contact.Text = "";

                    }
                    break;

                case "Trainer":
                    //placeholder trainer
                break;
             
            }

            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
