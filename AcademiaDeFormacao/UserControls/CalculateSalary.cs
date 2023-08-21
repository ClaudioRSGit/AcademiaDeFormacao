using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AcademiaDeFormacao.UserControls
{
    public partial class CalculateSalary : UserControl
    {
        public CalculateSalary()
        {
            InitializeComponent();
        }

        public void CalculateTotalSalary()
        {
            using (var context = new School())
            {
                List<Employee> employees = context.Employees.ToList();
                double t_salary = 0;

                // Apply filter based on the selected option in cmb_filter
                string selectedFilter = cmb_filter?.SelectedItem?.ToString() ?? "All";
                if (selectedFilter != "All")
                {
                    employees = employees.Where(emp => emp.Role == selectedFilter).ToList();
                }

                foreach (var employee in employees)
                {
                    t_salary += employee.Salary;
                }
                label1.Text = t_salary.ToString("C2");
            }
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cmb_filter_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalculateTotalSalary();
        }
    }
}
