using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace AcademiaDeFormacao.UserControls
{
    public partial class CalculateSalary : UserControl
    {
        private Dictionary<string, int> ageDistribution = new Dictionary<string, int>();

        public CalculateSalary()
        {
            InitializeComponent();
            //PopulateDashboard();
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
        public void PopulateDashboard()
        {
            InitializeCharts();
            CalculateTotalSalary();
            UpdateChartData();
            //UpdateAgeDistributionChart();


            using (var context = new School())
            {
                int totalEmployees = context.Employees.Count();
                lbl_totalEmployees.Text = totalEmployees.ToString();
            }
        }

        private void InitializeCharts()
        {
            // chart1
            chart1.Series.Clear();
            chart1.ChartAreas.Clear();

            ChartArea chartArea = new ChartArea();
            chartArea.Name = "EmployeeRoles";
            chart1.ChartAreas.Add(chartArea);

            Series series = new Series("Roles");
            series.ChartType = SeriesChartType.Column;
            chart1.Series.Add(series);

            // Hide the legend for chart1
            chart1.Legends.Clear();

            // Adjust chart area margins and positions for chart1
            chartArea.Position.X = 0;
            chartArea.Position.Y = 0;
            chartArea.Position.Width = 100;
            chartArea.Position.Height = 100;
            // chart1

            // ...

            // chart2
            chart2.Series.Clear();
            chart2.ChartAreas.Clear();

            ChartArea chartArea2 = new ChartArea();
            chartArea2.Name = "AverageSalaryRoles";
            chart2.ChartAreas.Add(chartArea2);

            Series series2 = new Series("Average Salary");
            series2.ChartType = SeriesChartType.Column;
            chart2.Series.Add(series2);

            // Hide the legend for chart2
            chart2.Legends.Clear();
            // chart2


            // Adjust chart area margins and positions for chart2
            chartArea2.Position.X = 0;
            chartArea2.Position.Y = 0;
            chartArea2.Position.Width = 100;
            chartArea2.Position.Height = 100;

            // chart3
            /*
            ChartArea chartArea3 = new ChartArea();
            chartArea3.Name = "AgeDistribution";
            chart3.ChartAreas.Add(chartArea3);

            Series series3 = new Series("Age Distribution");
            series3.ChartType = SeriesChartType.Pie;
            chart3.Series.Add(series3);
            // chart3 
            */
        }
        private int CalculateAge(DateTime birthdate)
        {
            int age = DateTime.Now.Year - birthdate.Year;
            if (birthdate > DateTime.Now.AddYears(-age))
                age--;

            return age;
        }

        private string GetAgeGroup(int age)
        {
            if (age < 20) return "Less than 20";
            if (age < 30) return "20s";
            if (age < 40) return "30s";
            if (age < 50) return "40s";
            return "50 and above";
        }

        private void UpdateAgeDistributionChart()
        {
            chart3.Series["Age Distribution"].Points.Clear();

            foreach (var kvp in ageDistribution)
            {
                chart3.Series["Age Distribution"].Points.AddXY(kvp.Key, kvp.Value);
            }
        }
        public void UpdateChartData()
        {
            ageDistribution.Clear(); // Clear the dictionary before updating
            using (var context = new School())
            {
                //chart1
                List<Employee> employees = context.Employees.ToList();

                Dictionary<string, int> roleCount = new Dictionary<string, int>();

                foreach (var employee in employees)
                {
                    if (roleCount.ContainsKey(employee.Role))
                        roleCount[employee.Role]++;
                    else
                        roleCount[employee.Role] = 1;
                }

                chart1.Series["Roles"].Points.Clear();

                foreach (var kvp in roleCount)
                {
                    chart1.Series["Roles"].Points.AddXY(kvp.Key, kvp.Value);
                }
                //chart1

                //chart2
                var averageSalaryByRole = employees
                .GroupBy(emp => emp.Role)
                .Select(group => new
                {
                    Role = group.Key,
                    AverageSalary = group.Average(emp => emp.Salary)
                })
                .ToList();

                chart2.Series["Average Salary"].Points.Clear();

                foreach (var item in averageSalaryByRole)
                {
                    chart2.Series["Average Salary"].Points.AddXY(item.Role, item.AverageSalary);
                }
                //chart2
                
                //chart3
                foreach (var employee in employees)
                {
                    int age = CalculateAge(employee.DateOfBirth);
                    string ageGroup = GetAgeGroup(age);

                    if (ageDistribution.ContainsKey(ageGroup))
                        ageDistribution[ageGroup]++;
                    else
                        ageDistribution[ageGroup] = 1;
                }
                //chart3
                
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

        private void CalculateSalary_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void lbl_totalEmployees_Click(object sender, EventArgs e)
        {

        }
    }
}
