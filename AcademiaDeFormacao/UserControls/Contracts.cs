using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AcademiaDeFormacao.UserControls
{
    public partial class Contracts : UserControl
    {
        List<Employee> employees;
        int yearsOfService;

        public Contracts()
        {
            InitializeComponent();
        }
        public void PopulateFormFields()
        {
            GetAllEmployees(); // Fetch employees and populate the list
            PopulateEmployeesComboBox(); // Populate the combo box
        }
        // Fetch employees from the database and populate the employees list
        public void GetAllEmployees()
        {
            using (var context = new School())
            {
                employees = context.Employees.ToList();
            }
        }
        public void showMedal(PictureBox medal)
        {
            goldenMedal.Hide();
            silverMedal.Hide();
            bronzeMedal.Hide();
            newbieMedal.Hide();

            medal.Show();
        }
        // Populate the combo box with employee names
        public void PopulateEmployeesComboBox()
        {
            cmb_employee.DisplayMember = "Name"; // Set the property to display
            cmb_employee.DataSource = employees; // Set the data source

            if (cmb_employee.SelectedIndex >= 0)
            {
                Employee selectedEmployee = (Employee)cmb_employee.SelectedItem;
                yearsOfService = CalculateYearsOfService(selectedEmployee.ContractEndDate);
            }
  
                if (yearsOfService >= 10)
                {
                    showMedal(goldenMedal);
                }
                else if (yearsOfService >= 5 && yearsOfService < 10)
                {
                    showMedal(silverMedal);
                }
                else if (yearsOfService >= 1 && yearsOfService < 5)
                {
                    showMedal(bronzeMedal);
                }
                else
                {
                    showMedal(newbieMedal);
                }
        }

        private int CalculateYearsOfService(DateTime contractEndDate)
        {
            DateTime currentDate = DateTime.Now.Date; // Get current date without time
            TimeSpan serviceSpan = currentDate - contractEndDate;

            // Calculate the years of service
            int years = (int)(serviceSpan.Days / 365.25);

            return years;
        }



    }
}
