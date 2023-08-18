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
    public partial class ExportData : UserControl
    {
        public ExportData()
        {
            InitializeComponent();
            LoadDatabasePreview();
        }
        private void LoadDatabasePreview()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("ID");
            dataTable.Columns.Add("Nome");
            dataTable.Columns.Add("Função");
            dataTable.Columns.Add("Email");

            using (var context = new School())
            {
                List<Employee> employees = context.Employees.ToList();

                // Apply filter based on the selected option in cmb_filter
                string selectedFilter = cmb_filter?.SelectedItem?.ToString()??"All";
                if (selectedFilter != "All")
                {
                    employees = employees.Where(emp => emp.Role == selectedFilter).ToList();
                }

                foreach (var employee in employees)
                {
                    dataTable.Rows.Add(employee.EmployeeId, employee.Username, employee.Role, employee.Email);
                }
            }
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = dataTable;
        }
        private void btn_exportCSV_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV Files (*.csv)|*.csv";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string csvFilePath = saveFileDialog.FileName;

                using (var context = new School())
                {
                    try
                    {
                        string selectedFilter = cmb_filter?.SelectedItem?.ToString() ?? "All";
                        List<Employee> employees = context.Employees.ToList();

                        // Apply filter based on the selected option in cmb_filter
                        if (selectedFilter != "All")
                        {
                            employees = employees.Where(emp => emp.Role == selectedFilter).ToList();
                        }

                        using (StreamWriter writer = new StreamWriter(csvFilePath))
                        {
                            writer.WriteLine("ID,Name,Function, Email");

                            foreach (var employee in employees)
                            {
                                writer.WriteLine($"{employee.EmployeeId},{employee.Username},{employee.Role}, {employee.Email}");
                            }
                        }

                        MessageBox.Show("Data Exported Successfully!!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }
        private void LoadDatabasePreview(string selectedFilter)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("ID");
            dataTable.Columns.Add("Nome");
            dataTable.Columns.Add("Função");
            dataTable.Columns.Add("Email");

            using (var context = new School())
            {
                List<Employee> employees = context.Employees.ToList();

                // Apply filter based on the selected option in cmb_filter
                if (selectedFilter != "All")
                {
                    employees = employees.Where(emp => emp.Role == selectedFilter).ToList();
                }

                foreach (var employee in employees)
                {
                    dataTable.Rows.Add(employee.EmployeeId, employee.Username, employee.Role, employee.Email);
                }
            }
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = dataTable;
        }
        private void cmb_filter_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedFilter = cmb_filter.SelectedItem.ToString();
            LoadDatabasePreview(selectedFilter);
        }
    }
}
