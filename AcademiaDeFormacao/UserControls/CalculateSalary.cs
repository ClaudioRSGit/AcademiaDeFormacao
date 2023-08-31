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
        DateTime currentDate = DateTime.Today;
        int disabledAccountsCount, expiredContractsCount, contractsEndingThisMonthCount, enabledAccountsCount;
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
                var birthdayEmployees = context.Employees
                    .Where(emp => emp.DateOfBirth.Month == currentDate.Month && emp.DateOfBirth.Year == currentDate.Year)
                    .ToList();

                StringBuilder birthdayText = new StringBuilder();
                foreach (var employee in birthdayEmployees)
                {
                    birthdayText.AppendLine($"{employee.Name} ({employee.DateOfBirth.Day}/{employee.DateOfBirth.Month}/{employee.DateOfBirth.Year})");
                }
                lbl_birthdays.Text = birthdayText.ToString();


                //latest employee
                var latestEmployee = context.Employees.OrderByDescending(emp => emp.EmployeeId).FirstOrDefault();
                if (latestEmployee != null)
                {
                    lbl_latestEmployee.Text = $"New Emp: {latestEmployee.Role} {latestEmployee.Name}";
                }

                //update AccountStatus
                foreach (var employee in context.Employees)
                {
                    if (employee.ContractEndDate < currentDate)
                    {
                        employee.AccountStatus = false;
                        employee.ContractEndDate = DateTime.Now;
                    }
                    else
                    {
                        employee.AccountStatus = true;
                    }
                }

                // Count of contracts ending in the current month
                contractsEndingThisMonthCount = context.Employees
                    .Count(emp => emp.ContractEndDate.Month == currentDate.Month && emp.ContractEndDate.Year == currentDate.Year);

                lbl_contractsEnding.Text = contractsEndingThisMonthCount.ToString();

                //disabled accounts count
                disabledAccountsCount = context.Employees.Count(emp => emp.AccountStatus == false);
                lbl_disabledAccounts.Text = $"{disabledAccountsCount}";

                //expired contracts count
                expiredContractsCount = context.Employees.Count(emp => emp.AccountStatus == false);
                lbl_expiredContracts.Text = $"{expiredContractsCount}";

                //enabled accounts
                enabledAccountsCount = context.Employees.Count(emp => emp.AccountStatus == true);
                lbl_enabledAccounts.Text = $"{enabledAccountsCount}";


                // Save changes to the database
                context.SaveChanges();
            }

            //current date
            lbl_currentDate.Text = currentDate.ToString("MM/dd/yyyy");
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
            int age = currentDate.Year - birthdate.Year;
            if (birthdate > currentDate.AddYears(-age))
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

        private void lbl_disabledAccounts_MouseHover(object sender, EventArgs e)
        {
            using (var context = new School())
            {
                var disabledEmployees = context.Employees.Where(emp => emp.AccountStatus == false).ToList();

                if (disabledEmployees.Any())
                {
                    StringBuilder tooltipText = new StringBuilder("Disabled Accounts:\n");
                    foreach (var employee in disabledEmployees)
                    {
                        tooltipText.AppendLine(employee.Name);
                    }

                    ToolTip tooltip = new ToolTip();
                    tooltip.IsBalloon = true;
                    tooltip.ShowAlways = false;
                    tooltip.Show(tooltipText.ToString(), lbl_disabledAccounts, 0, lbl_disabledAccounts.Height);
                    tooltip.AutoPopDelay = 50;
                }
            }
        }

        private void lbl_enabledAccounts_MouseHover_1(object sender, EventArgs e)
        {
            using (var context = new School())
            {
                var disabledEmployees = context.Employees.Where(emp => emp.AccountStatus == true).ToList();

                if (disabledEmployees.Any())
                {
                    StringBuilder tooltipText = new StringBuilder("Enabled Accounts:\n");
                    foreach (var employee in disabledEmployees)
                    {
                        tooltipText.AppendLine(employee.Name);
                    }

                    ToolTip tooltip = new ToolTip();
                    tooltip.IsBalloon = true;
                    tooltip.ShowAlways = false;
                    tooltip.Show(tooltipText.ToString(), lbl_disabledAccounts, 0, lbl_disabledAccounts.Height);
                    tooltip.AutoPopDelay = 50;
                }
            }
        }

        private void lbl_expiredContracts_MouseHover(object sender, EventArgs e)
        {
            using (var context = new School())
            {
                //expired
                var contractsEndingThisMonth = context.Employees
                    .Where(emp => emp.ContractEndDate < currentDate)
                    .ToList();

                if (contractsEndingThisMonth.Any())
                {
                    StringBuilder tooltipText = new StringBuilder("Contracts Expired:\n");
                    foreach (var employee in contractsEndingThisMonth)
                    {
                        tooltipText.AppendLine(employee.Name + " : " + employee.ContractEndDate.ToString("MM/dd/yy"));
                    }

                    ToolTip tooltip = new ToolTip();
                    tooltip.IsBalloon = true;
                    tooltip.ShowAlways = false;
                    tooltip.Show(tooltipText.ToString(), lbl_contractsEnding, 0, lbl_contractsEnding.Height);
                    tooltip.AutoPopDelay = 1000;
                }
            }
        }

        private void lbl_contractsEnding_MouseHover(object sender, EventArgs e)
        {
            using (var context = new School())
            {
                // Contracts ending in the current month
                var contractsEndingThisMonth = context.Employees
                    .Where(emp => emp.ContractEndDate.Month == currentDate.Month)
                    .ToList();

                if (contractsEndingThisMonth.Any())
                {
                    StringBuilder tooltipText = new StringBuilder("Contracts Ending This Month:\n");
                    foreach (var employee in contractsEndingThisMonth)
                    {
                        tooltipText.AppendLine(employee.Name + " : " + employee.ContractEndDate.ToString("MM/dd/yy"));
                    }

                    ToolTip tooltip = new ToolTip();
                    tooltip.IsBalloon = true;
                    tooltip.ShowAlways = false;
                    tooltip.Show(tooltipText.ToString(), lbl_contractsEnding, 0, lbl_contractsEnding.Height);
                    tooltip.AutoPopDelay = 1000;
                }
            }
        }

        private void lbl_currentDate_Click(object sender, EventArgs e)
        {
            //add one day
            currentDate = currentDate.AddDays(1);
            //current date
            lbl_currentDate.Text = currentDate.ToString("MM/dd/yyyy");

            PopulateDashboard();
        }
        private void lbl_currentDate_DoubleClick(object sender, EventArgs e)
        {
            DialogResult confirmationResult = MessageBox.Show(
                    "Are you sure you want to advance one year?",
                    "Confirm",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

            if (confirmationResult == DialogResult.Yes)
            {
                //add one day
                currentDate = currentDate.AddYears(1);
                //current date
                lbl_currentDate.Text = currentDate.ToString("MM/dd/yyyy");

                PopulateDashboard();
            }
        }
    }
}
