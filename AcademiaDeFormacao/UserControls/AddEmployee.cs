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


//ToDo Ver bugs quando se clica no btn_add pois pode haver campos nao escritos

namespace AcademiaDeFormacao.UserControls
{
    public partial class AddEmployee : UserControl
    {
        public int SelectedDirectorId { get; set; }

        public AddEmployee()
        {
            InitializeComponent();
            HideAll();
        }

        #region Utils
        //Hide all Components
        private void HideAll()
        {
            cbx_timeExemption.Hide();
            cbx_Car.Hide();
            lbl_MensalBonus.Hide();
            txt_mensalBonus.Hide();
            lbl_Area.Hide();
            cbx_Area.Hide();
            btn_ShowPanels.Hide();
            panel_listDirectors.Hide();
            panel_Trainer.Hide();
            panel_coordinator.Hide();
            director_name.Hide();
            cbx_area_trainer.Hide();
        }

        //Wipe all inputs
        private void wipeFields()
        {
            txt_username.Text = "";
            txt_password.Text = "";
            txt_name.Text = "";
            txt_email.Text = "";
            txt_salary.Text = "";
            txt_address.Text = "";
            txt_contact.Text = "";

            //Todo Colocar aqui o resto
        }

        #endregion



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

        private void cmb_Role_SelectedIndexChanged(object sender, EventArgs e)
        {
            wipeFields();
            
            string selectedRole = cmb_Role.SelectedItem.ToString();

            switch (selectedRole)
            {
                case "Director":
                    cbx_Car.Show();
                    cbx_timeExemption.Show();
                    lbl_MensalBonus.Show();
                    txt_mensalBonus.Show();
                    btn_ShowPanels.Hide();
                    lbl_Area.Hide();
                    cbx_Area.Hide();
                    cbx_area_trainer.Hide();
                    director_name.Hide();
                    txt_salary.Enabled = true;
                    break;
                case "Secretary":
                    btn_ShowPanels.Show();
                    lbl_Area.Show();
                    cbx_Area.Show();
                    cbx_area_trainer.Hide();
                    director_name.Show();
                    cbx_timeExemption.Hide();
                    cbx_Car.Hide();
                    lbl_MensalBonus.Hide();
                    txt_mensalBonus.Hide();
                    btn_ShowPanels.Text = "Show Directors";
                    txt_salary.Enabled = true;
                    break;
                case "Trainer":
                    lbl_Area.Show();
                    cbx_area_trainer.Show();
                    btn_ShowPanels.Show();
                    cbx_Area.Hide();
                    director_name.Hide();
                    cbx_timeExemption.Hide();
                    cbx_Car.Hide();
                    lbl_MensalBonus.Hide();
                    txt_mensalBonus.Hide();
                    btn_ShowPanels.Text = "Availability";
                    txt_salary.Enabled = false;
                    break;
                case "Coordinator":
                    btn_ShowPanels.Show();
                    lbl_Area.Hide();
                    cbx_Area.Hide();
                    cbx_area_trainer.Hide();
                    director_name.Hide();
                    cbx_timeExemption.Hide();
                    cbx_Car.Hide();
                    lbl_MensalBonus.Hide();
                    txt_mensalBonus.Hide();
                    btn_ShowPanels.Text = "Add Trainers";
                    txt_salary.Enabled = true;
                    break;

                default:
                    cbx_timeExemption.Hide();
                    cbx_Car.Hide();
                    director_name.Hide();

                    break;
            }
        }

        private void button_addEmployee_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_username.Text) || string.IsNullOrWhiteSpace(txt_password.Text) ||
                string.IsNullOrWhiteSpace(txt_name.Text) || string.IsNullOrWhiteSpace(txt_email.Text) ||
                string.IsNullOrWhiteSpace(txt_salary.Text) || string.IsNullOrWhiteSpace(txt_address.Text) ||
                string.IsNullOrWhiteSpace(txt_contact.Text) || cmb_Role.SelectedItem == null)
            {
                MessageBox.Show("Please fill in all required fields.");
                return;
            }
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
                        newSecretary.AccountStatus = true;
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
                        newDirector.AccountStatus = true;

                        context.Directors.Add(newDirector);
                        context.SaveChanges();
                        MessageBox.Show("ADICIONADO");

                        //wipe all fields
                        wipeFields();
                    }
                    break;

                case "Trainer":
                    using (var context = new School())
                    {
                        Trainer newTrainer = new Trainer();

                        newTrainer.Username = txt_username.Text;
                        newTrainer.Password = txt_password.Text;
                        newTrainer.Name = txt_name.Text;
                        newTrainer.Email = txt_email.Text;
                        newTrainer.Salary = Convert.ToDouble(txt_salary.Text);
                        newTrainer.Role = selectedRole;
                        newTrainer.Address = txt_address.Text;
                        newTrainer.Contact = txt_contact.Text;
                        newTrainer.ContractEndDate = dtp_ContractEndDate.Value;
                        newTrainer.CriminalRecordEndDate = dtp_CriminalRecord.Value;
                        newTrainer.DateOfBirth = dtp_BirthDate.Value;
                        newTrainer.EducationArea = cbx_area_trainer.SelectedItem.ToString();
                        newTrainer.Availability = cmb_availability.SelectedItem.ToString();
                        newTrainer.TimeValue = Convert.ToDouble( txt_timevalue.Text);
                        newTrainer.AccountStatus = true;

                        context.Trainers.Add(newTrainer);
                        context.SaveChanges();
                        MessageBox.Show("ADICIONADO");

                        //wipe all fields
                        wipeFields();
                    }

                    break;
                case "Coordinator":
                    using (var context = new School())
                    {
                        Coordinator newCoordinator = new Coordinator();

                        newCoordinator.Username = txt_username.Text;
                        newCoordinator.Password = txt_password.Text;
                        newCoordinator.Name = txt_name.Text;
                        newCoordinator.Email = txt_email.Text;
                        newCoordinator.Salary = Convert.ToDouble(txt_salary.Text);
                        newCoordinator.Role = selectedRole;
                        newCoordinator.Address = txt_address.Text;
                        newCoordinator.Contact = txt_contact.Text;
                        newCoordinator.ContractEndDate = dtp_ContractEndDate.Value;
                        newCoordinator.CriminalRecordEndDate = dtp_CriminalRecord.Value;
                        newCoordinator.DateOfBirth = dtp_BirthDate.Value;
                        newCoordinator.AccountStatus = true;
                        //newCoordinator.AssociatedTrainer = "ewr";

                        context.Coordinators.Add(newCoordinator);
                        context.SaveChanges();
                        MessageBox.Show("ADICIONADO");

                        //wipe all fields
                        wipeFields();
                        break;
                    }

            }


        }

        private void btn_ShowPanels_Click(object sender, EventArgs e)
        {
            string selectedRole = cmb_Role.SelectedItem.ToString();
            if (selectedRole == "Secretary")
            {
                panel_listDirectors.Show();
            }
            else if (selectedRole == "Trainer")
            {
                panel_Trainer.Show();
            }
            else
            {
                panel_coordinator.Show();
            }
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

        private void btn_back_trainer_Click(object sender, EventArgs e)
        {
            panel_Trainer.Hide();
        }

        private void btn_save_trainer_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_timevalue.Text) || cmb_availability.SelectedIndex == -1)
            {
                MessageBox.Show("Fields Empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //BUGS A VER ... Podem colocar um "." em vez de "," / Podem colocar letras
                double timevalue = Convert.ToDouble( txt_timevalue.Text);
                int currentMonth = DateTime.Today.Month;
                int daysInCurrentMonth = DateTime.DaysInMonth(DateTime.Today.Year, currentMonth);
                double calculatedSalary = (timevalue * 6) * daysInCurrentMonth;
                txt_salary.Text = calculatedSalary.ToString();
                panel_Trainer.Hide();
            }
        }

        private void txt_onlyNumbers(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is a valid numeric character or control key
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                e.KeyChar != '\b' && e.KeyChar != '\u007F' && e.KeyChar != ',' && e.KeyChar != '.')
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

        private void btn_exitPanelCoordinator_Click(object sender, EventArgs e)
        {
            panel_coordinator.Hide();
        }

        public void LoadTrainers()
        {

            using (var context = new School())
            {
                List<Trainer> trainers = context.Trainers.ToList();

                foreach (Trainer trainer in trainers)
                {
                    listView_TrainersToAdd.Items.Add(trainer.Name);
                }
            }

        }
    }
}
