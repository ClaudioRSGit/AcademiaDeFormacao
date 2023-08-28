using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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

            using (var context = new School())
            {
                //total employee label
                int totalEmployees = context.Employees.Count();
                lbl_totalEmployees.Text = totalEmployees.ToString();
           
                //average salary label
                double averageSalary = context.Employees.Average(emp => emp.Salary);
                lbl_averageSalary.Text = averageSalary.ToString("C2");

                //monthly birthday label
                string currentMonth = DateTime.Now.ToString("MMMM");
                var birthdayEmployees = context.Employees
                    .Where(emp => emp.DateOfBirth.Month == DateTime.Now.Month)
                    .ToList();

                StringBuilder birthdayText = new StringBuilder();
                foreach (var employee in birthdayEmployees)
                {
                    birthdayText.AppendLine($"{employee.Name} ({employee.DateOfBirth.Day}/{employee.DateOfBirth.Month})");
                }
                lbl_birthdays.Text = birthdayText.ToString();

                //latest employee
                var latestEmployee = context.Employees.OrderByDescending(emp => emp.EmployeeId).FirstOrDefault();
                if (latestEmployee != null)
                {
                    lbl_latestEmployee.Text = $"{latestEmployee.Role} {latestEmployee.Name}";
                }
            }
        }

        private void InitializeCharts()
        {
            // chart1
            chart1.Series.Clear();
            chart1.ChartAreas.Clear();

            ChartArea chartArea = new ChartArea();
            chartArea.Name = "EmployeeRoles";
            chartArea.BackColor = Color.FromArgb(61, 69, 76); // Set background color
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
            chartArea2.BackColor = Color.FromArgb(61, 69, 76); // Set background color
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
            // Check if the chart area already exists
            // Check if the chart area already exists
            ChartArea chartArea3 = chart3.ChartAreas.FindByName("AgeDistribution");
            if (chartArea3 == null)
            {
                chartArea3 = new ChartArea();
                chartArea3.Name = "AgeDistribution";
                // Set the background color of the chart area
                chartArea3.BackColor = Color.FromArgb(61, 69, 76); // Set background color

                chart3.ChartAreas.Add(chartArea3);
            }

            // Clear the existing series collection
            chart3.Series.Clear();

            Series series3 = new Series("Age Distribution");
            series3.ChartType = SeriesChartType.Pie;
            series3.ChartArea = "AgeDistribution"; // Assign the chart area for the pie chart
            chart3.Series.Add(series3);

            // Adjust chart area margins and positions for chart3
            chartArea3.Position.X = 2;
            chartArea3.Position.Y = 2;
            chartArea3.Position.Width = 95;
            chartArea3.Position.Height = 95;

            // Hide the legend for chart3
            chart3.Legends.Clear();
            

        }

        private void UpdateAgeDistributionChart()
        {
            chart3.Series["Age Distribution"].Points.Clear();

            foreach (var kvp in ageDistribution)
            {
                chart3.Series["Age Distribution"].Points.AddXY(kvp.Key, kvp.Value);
            }
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
            if (age < 20) return "< 20";
            if (age < 30) return "20s";
            if (age < 40) return "30s";
            if (age < 50) return "40s";
            return "> 50";
        }
        private string GetMonthName(int monthNumber)
        {
            return DateTimeFormatInfo.CurrentInfo.GetMonthName(monthNumber);
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

                // Calculate age distribution
                foreach (var employee in employees)
                {
                    int age = CalculateAge(employee.DateOfBirth);
                    string ageGroup = GetAgeGroup(age);

                    if (ageDistribution.ContainsKey(ageGroup))
                        ageDistribution[ageGroup]++;
                    else
                        ageDistribution[ageGroup] = 1;
                }

                // Update the age distribution chart
                UpdateAgeDistributionChart();


                
            }


        }

        private void cmb_filter_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalculateTotalSalary();
        }


    }
}
