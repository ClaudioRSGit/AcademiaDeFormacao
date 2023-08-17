using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace AcademiaDeFormacao.UserControls
{
    public partial class ExportCSV : UserControl
    {
        SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AcademiaDeFormacao.School;Integrated Security=True");
        public ExportCSV()
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

                string selectedFilter = cmb_filter?.SelectedItem?.ToString() ?? "All";
                
                if (selectedFilter != "All")
                {
                    employees = employees.Where(emp => emp.Role == selectedFilter).ToList();
                }

                foreach (var employee in employees)
                {
                    dataTable.Rows.Add(employee.EmployeeId, employee.Username, employee.Role, employee.Email);
                }
            }
            dataGridViewEmployees.ReadOnly = true;
            dataGridViewEmployees.DataSource = dataTable;
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
                        List<Employee> employees = context.Employees.ToList();

                        using (StreamWriter writer = new StreamWriter(csvFilePath))
                        {
                            writer.WriteLine("ID,Nome de Usuário,Função");

                            foreach (var employee in employees)
                            {
                                writer.WriteLine($"{employee.EmployeeId},{employee.Username},{employee.Role}");
                            }
                        }

                        MessageBox.Show("Dados do funcionário exportados para CSV com sucesso!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocorreu um erro ao exportar para CSV: " + ex.Message);
                    }
                }
            }

        }

    }
}
