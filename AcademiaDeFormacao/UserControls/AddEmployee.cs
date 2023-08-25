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
        public int SelectedDirectorId { get; set; }

        public AddEmployee()
        {
            InitializeComponent();
            cbx_timeExemption.Hide();
            cbx_Car.Hide();
            lbl_MensalBonus.Hide();
            txt_mensalBonus.Hide();
            lbl_Area.Hide();
            cbx_Area.Hide();
            btn_ShowDirectors.Hide();
            panel_listDirectors.Hide();
            director_name.Hide();
        }

        public void LoadDirectors()
        {
            using (var context = new School())
            {
                List<Director> directors = context.Directors.ToList();

                foreach (Director director in directors)
                {
                    list_director.Items.Add(director.Name);
                }
            }
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
                    lbl_MensalBonus.Show();
                    txt_mensalBonus.Show();
                    btn_ShowDirectors.Hide();
                    lbl_Area.Hide();
                    cbx_Area.Hide();
                    director_name.Hide();
                    break;
                case "Secretary":
                    btn_ShowDirectors.Show();
                    lbl_Area.Show();
                    cbx_Area.Show();
                    director_name.Show();
                    cbx_timeExemption.Hide();
                    cbx_Car.Hide();
                    lbl_MensalBonus.Hide();
                    txt_mensalBonus.Hide();

                    break;
                default:
                    cbx_timeExemption.Hide();
                    cbx_Car.Hide();
                    director_name.Hide();

                    break;
            }
        }

        private void wipeFields()
        {
            txt_username.Text = "";
            txt_password.Text = "";
            txt_name.Text = "";
            txt_email.Text = "";
            txt_salary.Text = "";
            txt_address.Text = "";
            txt_contact.Text = "";
        }

        private void button_addEmployee_Click(object sender, EventArgs e)
        {
            string selectedRole = cmb_Role.SelectedItem.ToString();
            switch (selectedRole)
            {
                case "Secretary":
                    using (var context = new School())
                    {
                        Director selectedDirector = context.Directors.FirstOrDefault(d => d.EmployeeId == this.SelectedDirectorId);
                        Secretary newSecretary = new Secretary();
                        newSecretary.Username = txt_username.Text;
                        newSecretary.Password = txt_password.Text;
                        newSecretary.Name = txt_name.Text;
                        newSecretary.Email = txt_email.Text;
                        newSecretary.Salary = Convert.ToDouble(txt_salary.Text);
                        newSecretary.Role = selectedRole;
                        newSecretary.Address = txt_address.Text;
                        newSecretary.Contact = txt_contact.Text;
                        newSecretary.ContractEndDate = dtp_ContractEndDate.Value;
                        newSecretary.CriminalRecordEndDate = dtp_CriminalRecord.Value;
                        newSecretary.DateOfBirth = dtp_BirthDate.Value;
                        newSecretary.Area = cbx_Area.SelectedItem.ToString();
                        newSecretary.DiretorReporta = selectedDirector;
                        context.Secretaries.Add(newSecretary);
                        context.SaveChanges();
                        
                        MessageBox.Show("ADICIONADO");

                        //wipe all fields
                        wipeFields();

                    }
                    break;
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
                        newDirector.DateOfBirth = dtp_BirthDate.Value;
                        newDirector.MonthlyBonus = Convert.ToDouble(txt_mensalBonus.Text);   
                        newDirector.CompanyCar = cbx_Car.Checked;
                        newDirector.TimeExemption = cbx_timeExemption.Checked;

                        context.Directors.Add(newDirector);
                        context.SaveChanges();
                        MessageBox.Show("ADICIONADO");

                        //wipe all fields
                        wipeFields();
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

        private void btn_ShowDirectors_Click(object sender, EventArgs e)
        {
            panel_listDirectors.Show();
        }

        private void list_director_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (list_director.SelectedIndex != -1)
            {
                using (var context = new School())
                {
                    var selectedDirector = context.Directors.FirstOrDefault(d => d.Name == list_director.SelectedItem.ToString());
                    if (selectedDirector != null)
                    {
                        this.SelectedDirectorId = selectedDirector.EmployeeId;
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel_listDirectors.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            director_name.Show();
            director_name.Text = list_director.SelectedItem.ToString();
            panel_listDirectors.Hide();
        }

        private void cbx_Area_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
