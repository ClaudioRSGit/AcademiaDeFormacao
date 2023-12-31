﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace AcademiaDeFormacao.UserControls
{
    public partial class Contracts : UserControl
    {
        List<Employee> employees;
        double yearsOfService;

        public Contracts()
        {
            InitializeComponent();
        }
        public void PopulateFormFields()
        {
            GetAllEmployees();

            btn_renewContract.Visible = false;

            PopulateEmployeesComboBox();

            // Attach the SelectedIndexChanged event handler to the combo box
            cmb_employee.SelectedIndexChanged += cmb_employee_SelectedIndexChanged;
            txt_contractEndDate.Enabled = false;
            txt_criminalRecordEndDate.Enabled = false;
        }
        // Fetch employees from the database and populate the employees list
        public void GetAllEmployees()
        {
            using (var context = new School())
            {
                employees = context.Employees.ToList();
            }
        }
        private void UpdateMedalVisibility(bool golden, bool silver, bool bronze, bool newbie, bool disabled)
        {
            goldenMedal.Visible = golden;
            silverMedal.Visible = silver;
            bronzeMedal.Visible = bronze;
            newbieMedal.Visible = newbie;
            disabledAccount.Visible = disabled;
        }
        private string GetPartnerCondition(double yearsOfService)
        {
            // Get the selected employee from the ComboBox
            Employee selectedEmployee = (Employee)cmb_employee.SelectedItem;

            if (selectedEmployee.AccountStatus == false)
            {
                return "User Disabled";
            }
            else if (yearsOfService >= 10)
                return "Golden Partner";
            else if (yearsOfService >= 5 && yearsOfService < 10)
                return "Silver Partner";
            else if (yearsOfService >= 0 && yearsOfService < 5)
                return "Bronze Partner";
            else if (yearsOfService < 0)
                return "Disabled User";
            else return "error";
        }
        private void UpdatePartnerInfo(double yearsOfService)
        {
            // Retrieve the selected employee from the ComboBox
            Employee selectedEmployee = (Employee)cmb_employee.SelectedItem;

            // isDisabled?
            if (selectedEmployee.AccountStatus == false)
            {
                UpdateMedalVisibility(false, false, false, false, true);
                lbl_partner.Visible = false;
            }
            else if (yearsOfService >= 10)
                UpdateMedalVisibility(true, false, false, false, false);
            
            else if (yearsOfService >= 5 && yearsOfService < 10)
                UpdateMedalVisibility(false, true, false, false, false);
            
            else if (yearsOfService >= 2 && yearsOfService < 5)
                UpdateMedalVisibility(false, false, true, false, false);
            
            else if (yearsOfService == 0 || yearsOfService == 1 && selectedEmployee.AccountStatus == true)
                UpdateMedalVisibility(false, false, false, true, false);
           
            else if (yearsOfService == 0 || yearsOfService == 1 && selectedEmployee.AccountStatus == false)
                UpdateMedalVisibility(false, false, false, false, true);
            
            else if (yearsOfService < 0)
            {
                UpdateMedalVisibility(false, false, false, false, true);
                lbl_partner.Visible = false;
            }
            else
            {
                UpdateMedalVisibility(false, false, false, false, false);
            }
            lbl_partnerCondition.Text = GetPartnerCondition(yearsOfService);
        }

        private void cmb_employee_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_employee.SelectedIndex >= 0)
            {
                Employee selectedEmployee = (Employee)cmb_employee.SelectedItem;

                txt_contractEndDate.Text = selectedEmployee.ContractEndDate.ToString();
                txt_criminalRecordEndDate.Text = selectedEmployee.CriminalRecordEndDate.ToString();
                txt_role.Text = selectedEmployee.Role;
                txt_role.Enabled = false;

                yearsOfService = CalculateYearsOfService(selectedEmployee.ContractEndDate);
                UpdatePartnerInfo(yearsOfService);

                if (selectedEmployee.AccountStatus == true)
                {
                    lbl_partner.Visible = true;
                    dateTimePicker1.Enabled = true;
                    dateTimePicker2.Enabled = true;

                    button1.Visible = true;
                    btn_renewContract.Visible = false;
                }
                else
                {
                    button1.Visible = false;
                    btn_renewContract.Visible = true;
                }
                if (selectedEmployee.Role == "Trainer")
                {
                    calculatorPNG.Visible = true;
                    lbl_salaryCalculator.Visible = true;
                }
                else
                {
                    calculatorPNG.Visible = false;
                    lbl_salaryCalculator.Visible = false;
                    panel_Trainer.Visible = false;
                    lbl_partner.Text = $"Contract ends in {yearsOfService.ToString()} years";

                    UpdateRemainingContractDays(selectedEmployee.ContractEndDate);
                    UpdateCriminalRecordDays(selectedEmployee.CriminalRecordEndDate);
                }
            }
        }

        public void PopulateEmployeesComboBox()
        {
            // Set the minimum date for dateTimePicker1 to today
            dateTimePicker1.MinDate = DateTime.Today;

            // Set the minimum date for dateTimePicker2 to today
            dateTimePicker2.MinDate = DateTime.Today;

            cmb_employee.DisplayMember = "Name";
            cmb_employee.DataSource = employees;

            calculatorPNG.Visible = false;
            lbl_salaryCalculator.Visible = false;
            panel_Trainer.Visible = false;

            //standard option
            cmb_employee.SelectedIndex = 1;

            if (cmb_employee.SelectedIndex >= 0)
            {
                Employee selectedEmployee = (Employee)cmb_employee.SelectedItem;
                yearsOfService = CalculateYearsOfService(selectedEmployee.ContractEndDate);

                txt_contractEndDate.Text = selectedEmployee.ContractEndDate.ToString();
                txt_criminalRecordEndDate.Text = selectedEmployee.ContractEndDate.ToString();
                txt_role.Text = selectedEmployee.Role;
                txt_role.Enabled = false;

                if (selectedEmployee.AccountStatus == false)
                {
                    dateTimePicker1.Enabled = false;
                    dateTimePicker2.Enabled = false;
                    btn_renewContract.Visible = false;
                }

                if (selectedEmployee.Role == "Trainer")
                {
                    calculatorPNG.Visible = true;
                    lbl_salaryCalculator.Visible = true;
                }
                else
                {
                    calculatorPNG.Visible = false;
                    lbl_salaryCalculator.Visible = false;
                    panel_Trainer.Visible = false;
                }

                UpdatePartnerInfo(yearsOfService);

                lbl_partner.Text = $"Contract ends in {yearsOfService.ToString()} years";
            }
            cmb_employee_SelectedIndexChanged(null, EventArgs.Empty);
        }
        private void UpdateRemainingContractDays(DateTime contractEndDate)
        {
            DateTime currentDate = DateTime.Now.Date;
            TimeSpan remainingTime = contractEndDate - currentDate;

            int remainingDays = (int)remainingTime.TotalDays;

            lbl_remainingContractDays.Text = remainingDays > 0
                ? $"Remaining Contract Days: {Math.Abs(remainingDays)}"
                : $"Account disabled for {Math.Abs(remainingDays)} days";

        }
        private void UpdateCriminalRecordDays(DateTime criminalRecordEndDate)
        {
            DateTime currentDate = DateTime.Now.Date;
            TimeSpan remainingTime = criminalRecordEndDate - currentDate;

            int remainingDays = (int)remainingTime.TotalDays;

            lbl_criminalRecordDays.Text = $"Remaining Criminal Record Days: {remainingDays}";
        }
        private double CalculateYearsOfService(DateTime contractEndDate)
        {
            DateTime currentDate = DateTime.Now.Date;
            TimeSpan remainingTime = contractEndDate - currentDate;

            double years = (int)(remainingTime.TotalDays / 365);
            return years;
        }

        private void UpdateUIAfterContractEnd()
        {
            Employee selectedEmployee = (Employee)cmb_employee.SelectedItem;

            // Disable the "End Contract" button since the contract is already ended
            button1.Visible = false;

            // Update contract end date labels
            txt_contractEndDate.Text = selectedEmployee.ContractEndDate.ToString();
            txt_criminalRecordEndDate.Text = selectedEmployee.CriminalRecordEndDate.ToString();
            lbl_remainingContractDays.Text = "Contract Ended";
            lbl_partnerCondition.Text = "Contract Over";
            btn_renewContract.Visible = true;
            UpdateMedalVisibility(false, false, false, false, true);


            // Update partner info and remaining days
            yearsOfService = CalculateYearsOfService(selectedEmployee.ContractEndDate);
            UpdatePartnerInfo(yearsOfService);
            UpdateRemainingContractDays(selectedEmployee.ContractEndDate);
            UpdateCriminalRecordDays(selectedEmployee.CriminalRecordEndDate);

            // Display a success message to the user
            MessageBox.Show("Contract ended successfully.", "Contract Ended", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void EndContract()
        {
            Employee selectedEmployee = (Employee)cmb_employee.SelectedItem;

            // Update the contract end date to today's date
            selectedEmployee.ContractEndDate = DateTime.Now.Date.AddYears(-1);
            //disable account
            selectedEmployee.AccountStatus = false;

            using (var context = new School())
            {
                context.Entry(selectedEmployee).State = EntityState.Modified;
                context.SaveChanges();
            }

            // Update the UI after ending the contract
            UpdateUIAfterContractEnd();
        }
        private void RenewContract()
        {
            Employee selectedEmployee = (Employee)cmb_employee.SelectedItem;

            using (var dateDialog = new Form())
            {
                dateDialog.Text = "Select New Contract End Date";
                dateDialog.Width = 250;
                dateDialog.Height = 150;
                dateDialog.BackColor = Color.FromArgb(49, 57, 64);

                dateDialog.StartPosition = FormStartPosition.CenterScreen;

                DateTimePicker datePicker = new DateTimePicker();
                datePicker.Format = DateTimePickerFormat.Short;
                datePicker.Value = selectedEmployee.ContractEndDate;

                datePicker.MinDate = DateTime.Today;

                // Center the DateTimePicker both vertically and horizontally
                datePicker.Top = (dateDialog.ClientSize.Height - datePicker.Height) / 2;
                datePicker.Left = (dateDialog.ClientSize.Width - datePicker.Width) / 2;

                datePicker.Anchor = AnchorStyles.None;

                Button confirmButton = new Button();
                confirmButton.Text = "Confirm";
                confirmButton.Dock = DockStyle.Bottom;
                confirmButton.DialogResult = DialogResult.OK;
                confirmButton.BackColor = Color.FromArgb(61, 69, 76);
                confirmButton.ForeColor = Color.White;

                dateDialog.Controls.AddRange(new Control[] { datePicker, confirmButton });
                selectedEmployee.AccountStatus = true;

                btn_renewContract.Visible = false;
                button1.Visible = true;

                if (dateDialog.ShowDialog() == DialogResult.OK)
                {
                    selectedEmployee.ContractEndDate = datePicker.Value.Date;

                    using (var context = new School())
                    {
                        context.Entry(selectedEmployee).State = EntityState.Modified;
                        context.SaveChanges();
                    }

                    UpdateUIAfterRenewContract();
                }

            }
        }


        private void UpdateUIAfterRenewContract()
        {
            cmb_employee_SelectedIndexChanged(null, EventArgs.Empty);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to end the contract?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // The user confirmed, perform the contract ending action

                //disable date pickers
                dateTimePicker1.Enabled = false;
                dateTimePicker2.Enabled = false;
                UpdateMedalVisibility(false, false, false, true, false);
                lbl_partner.Visible = false;

                EndContract();
            }
        }

        private void btn_renewContract_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to renew the contract?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                RenewContract();
            }
        }

        private void btn_saveData_Click(object sender, EventArgs e)
        {
            if (cmb_employee.SelectedIndex >= 0 && cmb_roles.SelectedIndex >= 0)
            {
                DialogResult confirmationResult = MessageBox.Show(
                    "Are you sure you want to save the changes?",
                    "Confirm Save",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirmationResult == DialogResult.Yes)
                {
                    Employee selectedEmployee = (Employee)cmb_employee.SelectedItem;

                    selectedEmployee.ContractEndDate = dateTimePicker1.Value.Date;
                    selectedEmployee.CriminalRecordEndDate = dateTimePicker2.Value.Date;

                    selectedEmployee.AccountStatus = selectedEmployee.ContractEndDate > DateTime.Today;

                    // Update the role to the new role from the combo box
                    selectedEmployee.Role = cmb_roles.SelectedItem.ToString();
                    UpdatePartnerInfo(yearsOfService);
                    using (var context = new School())
                    {
                        context.Entry(selectedEmployee).State = EntityState.Modified;
                        context.SaveChanges();
                    }

                    // Update the UI to reflect the changes
                    txt_contractEndDate.Text = selectedEmployee.ContractEndDate.ToString();
                    txt_criminalRecordEndDate.Text = selectedEmployee.CriminalRecordEndDate.ToString();
                    UpdateRemainingContractDays(selectedEmployee.ContractEndDate);
                    UpdateCriminalRecordDays(selectedEmployee.CriminalRecordEndDate);
                    UpdatePartnerInfo(CalculateYearsOfService(selectedEmployee.ContractEndDate));
                }
            }
        }

        private void calculatorPNG_Click(object sender, EventArgs e)
        {
            dt_trainingStart.MinDate = DateTime.Today.Date;
            dt_trainingEnd.MinDate = DateTime.Today.Date;
            panel_Trainer.Show();
        }

        private void btn_save_trainer_Click(object sender, EventArgs e)
        {
            Trainer selectedEmployee = (Trainer)cmb_employee.SelectedItem;

            DateTime trainingStart = dt_trainingStart.Value.Date;
            DateTime trainingEnd = dt_trainingEnd.Value.Date;
            double numberOfDaysWorked = (trainingEnd - trainingStart).Days;

            double salary = (numberOfDaysWorked * 6) + (Convert.ToDouble(selectedEmployee.TimeValue) * numberOfDaysWorked);
            txt_salary.Text = $"Calculated Salary: {salary:C}";
        }

        private void btn_closeSalaryCalculator_Click(object sender, EventArgs e)
        {
            dt_trainingStart.Value = DateTime.Today;
            dt_trainingEnd.Value = DateTime.Today;
            txt_salary.Text = "";
            panel_Trainer.Hide();
        }

    }
}
