using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace AcademiaDeFormacao.UserControls
{
    public partial class AddEmployee : UserControl
    {
        public int SelectedDirectorId { get; set; }

        public AddEmployee()
        {
            InitializeComponent();
            HideAll();

            // Initialize Dates
            dtp_CriminalRecord.MinDate = DateTime.Now.AddDays(+1);
            dtp_ContractEndDate.MinDate = DateTime.Now.AddDays(+1);
            dtp_BirthDate.MaxDate = DateTime.Now.AddYears(-18);

        }

        #region Utils
        private bool fieldsChecked = true;

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
            //Global
            txt_username.Text = "";
            txt_password.Text = "";
            txt_name.Text = "";
            txt_email.Text = "";
            txt_salary.Text = "";
            txt_address.Text = "";
            txt_contact.Text = "";
            dtp_CriminalRecord.MinDate = DateTime.Now.AddDays(+1);
            dtp_ContractEndDate.MinDate = DateTime.Now.AddDays(+1);
            dtp_BirthDate.MaxDate = DateTime.Now.AddYears(-18);
            //Directors
            txt_mensalBonus.Text = "";
            cbx_timeExemption.Checked = false;
            cbx_Car.Checked = false;
            //Secretary
            cbx_Area.SelectedIndex = 0;
            director_name.Text = "Director Name";
            list_director.ClearSelected();
            this.SelectedDirectorId = 0;
            //Trainers
            cmb_availability.SelectedIndex = 0;
            txt_timevalue.Text = "";
            txt_timevalue2.Text = "";
            //Coordinators
            listView_TrainersAdded.Clear();


        }

        private void txt_onlyNumbers(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is a valid numeric character or control key
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                e.KeyChar != '\b' && e.KeyChar != '\u007F')
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

        private void CheckValues(string role)
        {
            fieldsChecked = true;

            switch (role)
            {
                case "Secretary":
                    if (string.IsNullOrWhiteSpace(txt_username.Text) || string.IsNullOrWhiteSpace(txt_password.Text) ||
                        string.IsNullOrWhiteSpace(txt_name.Text) || string.IsNullOrWhiteSpace(txt_email.Text) ||
                        string.IsNullOrWhiteSpace(txt_salary.Text) || string.IsNullOrWhiteSpace(txt_address.Text) ||
                        string.IsNullOrWhiteSpace(txt_contact.Text) || cmb_Role.SelectedItem == null ||
                        director_name.Text == "Director Name" || !ValidateEmail(txt_email.Text))
                    {
                        MessageBox.Show("Please fill in all required fields and provide a valid email address.");
                        fieldsChecked = false;
                    }
                    break;
                case "Director":
                    if (string.IsNullOrWhiteSpace(txt_username.Text) || string.IsNullOrWhiteSpace(txt_password.Text) ||
                string.IsNullOrWhiteSpace(txt_name.Text) || string.IsNullOrWhiteSpace(txt_email.Text) ||
                string.IsNullOrWhiteSpace(txt_salary.Text) || string.IsNullOrWhiteSpace(txt_address.Text) ||
                string.IsNullOrWhiteSpace(txt_contact.Text) || cmb_Role.SelectedItem == null || string.IsNullOrWhiteSpace(txt_mensalBonus.Text)
                || !ValidateEmail(txt_email.Text))
                    {
                        MessageBox.Show("Please fill in all required fields.");
                        fieldsChecked = false;
                    }
                    break;
                case "Coordinator":
                    if (string.IsNullOrWhiteSpace(txt_username.Text) || string.IsNullOrWhiteSpace(txt_password.Text) ||
                string.IsNullOrWhiteSpace(txt_name.Text) || string.IsNullOrWhiteSpace(txt_email.Text) ||
                string.IsNullOrWhiteSpace(txt_salary.Text) || string.IsNullOrWhiteSpace(txt_address.Text) ||
                string.IsNullOrWhiteSpace(txt_contact.Text) || cmb_Role.SelectedItem == null || !ValidateEmail(txt_email.Text))
                    {
                        MessageBox.Show("Please fill in all required fields.");
                        fieldsChecked = false;
                    }
                    else if (listView_TrainersAdded.Items.Count == 0) 
                    {
                        panel_coordinator.Show();
                        MessageBox.Show("Please select Trainers associated!");
                        fieldsChecked = false;
                    }
                    break;
                case "Trainer":
                    if (string.IsNullOrWhiteSpace(txt_username.Text) || string.IsNullOrWhiteSpace(txt_password.Text) ||
                string.IsNullOrWhiteSpace(txt_name.Text) || string.IsNullOrWhiteSpace(txt_email.Text) ||
                string.IsNullOrWhiteSpace(txt_salary.Text) || string.IsNullOrWhiteSpace(txt_address.Text) ||
                string.IsNullOrWhiteSpace(txt_contact.Text) || cmb_Role.SelectedItem == null || !ValidateEmail(txt_email.Text))
                    {
                        MessageBox.Show("Please fill in all required fields.");
                        fieldsChecked = false;
                    }
                    else if (string.IsNullOrWhiteSpace(txt_timevalue.Text)
                || string.IsNullOrWhiteSpace(txt_timevalue2.Text))
                    {
                        panel_Trainer.Show();
                        MessageBox.Show("Please fill in all required fields.");
                        fieldsChecked = false;
                    }
                    break;
                default:
                    fieldsChecked = true;
                    break;
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

        private bool ValidateEmail(string email)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            // Use Regex.IsMatch to check if the email matches the pattern
            if (Regex.IsMatch(email, pattern))
            {
                return true; // Email is valid
            }
            else
            {
                return false; // Email is invalid
            }
        }

        #endregion

        #region AddSecretary
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

        private void btn_backPanelDirectors_Click(object sender, EventArgs e)
        {
            panel_listDirectors.Hide();
        }

        private void btn_saveDirector_Click(object sender, EventArgs e)
        {
            director_name.Show();
            director_name.Text = list_director.SelectedItem.ToString();
            panel_listDirectors.Hide();
        }
        #endregion

        #region AddCoordinador
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

        private void btn_exitPanelCoordinator_Click(object sender, EventArgs e)
        {
            panel_coordinator.Hide();
            foreach (ListViewItem item in listView_TrainersAdded.Items)
            {
                // Clone selected item
                ListViewItem clonedItem = (ListViewItem)item.Clone();

                // Add clone to listView_TrainersToAdd
                listView_TrainersToAdd.Items.Add(clonedItem);
            }
            listView_TrainersAdded.Clear();
        }

        List<Trainer> trainersToAddToCoordinator = new List<Trainer>();

        private void btn_addTrainer_Click(object sender, EventArgs e)
        {
            if (listView_TrainersToAdd.SelectedItems.Count > 0)
            {
                foreach (ListViewItem selectedItem in listView_TrainersToAdd.SelectedItems)
                {
                    // Clone selected item
                    ListViewItem clonedItem = (ListViewItem)selectedItem.Clone();

                    // Add clone to listView_TrainersAdded
                    listView_TrainersAdded.Items.Add(clonedItem);

                    // Remove item from listView_TrainersToAdd
                    listView_TrainersToAdd.Items.Remove(selectedItem);

                }
            }
        }

        private void btn_removeTrainer_Click(object sender, EventArgs e)
        {
            if (listView_TrainersAdded.SelectedItems.Count > 0)
            {
                foreach (ListViewItem selectedItem in listView_TrainersAdded.SelectedItems)
                {
                    string selectedTrainerName = selectedItem.Text;

                    // Clone selected item
                    ListViewItem clonedItem = (ListViewItem)selectedItem.Clone();

                    // Add clone to listView_TrainersToAdd
                    listView_TrainersToAdd.Items.Add(clonedItem);

                    // Remove item from listView_TrainersAdded
                    listView_TrainersAdded.Items.Remove(selectedItem);

                    using (var context = new School())
                    {
                        Trainer selectedTrainer = trainersToAddToCoordinator.FirstOrDefault(trainer => trainer.Name == selectedTrainerName);
                        if (selectedTrainer != null)
                        {
                            trainersToAddToCoordinator.Remove(selectedTrainer); // Remove trainer from temporary List<>
                        }
                    }
                }
            }
        }

        private void btn_SaveTrainersAdd_Click(object sender, EventArgs e)
        {
            // Clean trainers from temporary List<>
            trainersToAddToCoordinator.Clear();

            foreach (ListViewItem item in listView_TrainersAdded.Items)
            {
                // Get Trainer Name
                string selectedTrainerName = item.Text;

                // Find the corresponding Trainer in the database context
                using (var context = new School())
                {
                    Trainer selectedTrainer = context.Trainers.FirstOrDefault(trainer => trainer.Name == selectedTrainerName);
                    if (selectedTrainer != null)
                    {
                        // Add Trainer to Temporary List<>
                        trainersToAddToCoordinator.Add(selectedTrainer);
                    }
                }
            }
            panel_coordinator.Hide();
        }
        #endregion

        #region AddTrainer
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
                string value1 = txt_timevalue.Text;
                string value2 = txt_timevalue2.Text;
                string finalValue = value1 + "," + value2;
                double timevalue = Convert.ToDouble(finalValue);
                int currentMonth = DateTime.Today.Month;
                int daysInCurrentMonth = DateTime.DaysInMonth(DateTime.Today.Year, currentMonth);
                double calculatedSalary = (timevalue * 6) * daysInCurrentMonth;
                txt_salary.Text = calculatedSalary.ToString();
                panel_Trainer.Hide();
            }
        }

        #endregion

        #region AddEmployee
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
            string EncryptedPassword = EncryptPassword(txt_password.Text, 150);

            string selectedRole = cmb_Role.SelectedItem.ToString();

            CheckValues(selectedRole);

            if (!fieldsChecked)
            {
                return;
            }

            switch (selectedRole)
            {
                case "Secretary":
                    using (var context = new School())
                    {
                        Director selectedDirector = context.Directors.FirstOrDefault(d => d.EmployeeId == this.SelectedDirectorId);
                        Secretary newSecretary = new Secretary();
                        newSecretary.Username = txt_username.Text;
                        newSecretary.Password = EncryptedPassword;
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

                        MessageBox.Show("Account created successfully", "Registration Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //Wipe all fields
                        wipeFields();
                        cmb_Role.SelectedIndex = 0;

                    }
                    break;
                case "Director":
                    using (var context = new School())
                    {
                        Director newDirector = new Director();

                        newDirector.Username = txt_username.Text;
                        newDirector.Password = EncryptedPassword;
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
                        MessageBox.Show("Account created successfully", "Registration Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //Wipe all fields
                        wipeFields();
                        cmb_Role.SelectedIndex = 0;

                    }
                    break;

                case "Trainer":
                    using (var context = new School())
                    {
                        Trainer newTrainer = new Trainer();

                        newTrainer.Username = txt_username.Text;
                        newTrainer.Password = EncryptedPassword;
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
                        newTrainer.TimeValue = Convert.ToDouble(txt_timevalue.Text);
                        newTrainer.AccountStatus = true;

                        context.Trainers.Add(newTrainer);
                        context.SaveChanges();
                        MessageBox.Show("Account created successfully", "Registration Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //Wipe all fields
                        wipeFields();
                        cmb_Role.SelectedIndex = 0;

                    }

                    break;
                case "Coordinator":
                    using (var context = new School())
                    {
                        Coordinator newCoordinator = new Coordinator();

                        newCoordinator.Username = txt_username.Text;
                        newCoordinator.Password = EncryptedPassword;
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

                        foreach (Trainer trainer in trainersToAddToCoordinator)
                        {
                            if (trainer != null)
                            {
                                newCoordinator.AddTrainer(trainer);
                            }
                        }

                        // Loop with Trainer list
                        string trainerListMessage = "Coordinators associated:\n";

                        foreach (Trainer trainer in newCoordinator.Trainers)
                        {
                            trainerListMessage += trainer.Name + "\n";
                        }

                        // Message
                        MessageBox.Show(trainerListMessage, "Trainer List", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        context.Coordinators.Add(newCoordinator);
                        context.SaveChanges();
                        MessageBox.Show("Account created successfully", "Registration Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //Wipe all fields
                        wipeFields();
                        cmb_Role.SelectedIndex = 0;

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
                panel_listDirectors.BringToFront();
                panel_Trainer.SendToBack();
                panel_coordinator.SendToBack();
            }
            else if (selectedRole == "Trainer")
            {
                panel_Trainer.Show();
                panel_Trainer.BringToFront();
                panel_coordinator.SendToBack();
                panel_listDirectors.SendToBack();
            }
            else
            {
                panel_coordinator.Show();
                panel_coordinator.BringToFront();
                panel_listDirectors.SendToBack();
                panel_Trainer.SendToBack();
            }
        }

        #endregion

    }
}
