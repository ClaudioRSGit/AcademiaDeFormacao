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
using System.Xml;
using System.Xml.Serialization;

namespace AcademiaDeFormacao.UserControls
{
    public partial class ExportData : UserControl
    {
        public ExportData()
        {
            InitializeComponent();
           // LoadDatabasePreview();
        }
        public void LoadDatabasePreview()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("ID");
            dataTable.Columns.Add("Name");
            dataTable.Columns.Add("Role");
            dataTable.Columns.Add("Email");
            dataTable.Columns.Add("Address");

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
                    dataTable.Rows.Add(employee.EmployeeId, employee.Username, employee.Role, employee.Email, employee.Address);
                }
            }
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = dataTable;
        }
        private void btn_exportCSV_Click(object sender, EventArgs e)
        {
            
        }
        private void LoadDatabasePreview(string selectedFilter)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("ID");
            dataTable.Columns.Add("Name");
            dataTable.Columns.Add("Role");
            dataTable.Columns.Add("Email");
            dataTable.Columns.Add("Address");

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
                    dataTable.Rows.Add(employee.EmployeeId, employee.Username, employee.Role, employee.Email, employee.Address);
                }

            }

            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AllowUserToAddRows = false;

            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = dataTable;
        }
        private void cmb_filter_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedFilter = cmb_filter.SelectedItem.ToString();
            LoadDatabasePreview(selectedFilter);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "XML Files (*.xml)|*.xml";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string xmlFilePath = saveFileDialog.FileName;

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

                        // Create an XmlDocument and root element
                        XmlDocument xmlDoc = new XmlDocument();
                        XmlElement rootElement = xmlDoc.CreateElement("Employees");
                        xmlDoc.AppendChild(rootElement);

                        foreach (var employee in employees)
                        {
                            // Create an employee element
                            XmlElement employeeElement = xmlDoc.CreateElement("Employee");
                            rootElement.AppendChild(employeeElement);

                            // Add child elements for each property
                            AddXmlElement(xmlDoc, employeeElement, "EmployeeId", employee.EmployeeId.ToString());
                            AddXmlElement(xmlDoc, employeeElement, "Username", employee.Username);
                            AddXmlElement(xmlDoc, employeeElement, "Role", employee.Role);
                            AddXmlElement(xmlDoc, employeeElement, "Email", employee.Email);
                            AddXmlElement(xmlDoc, employeeElement, "Address", employee.Address);
                            // Add other properties as needed
                        }

                        // Save the XML document to the file
                        xmlDoc.Save(xmlFilePath);

                        MessageBox.Show("Data Exported to XML Successfully!!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }
        private void AddXmlElement(XmlDocument xmlDoc, XmlElement parentElement, string elementName, string elementValue)
        {
            XmlElement element = xmlDoc.CreateElement(elementName);
            element.InnerText = elementValue;
            parentElement.AppendChild(element);
        }


        private void pictureBox2_Click(object sender, EventArgs e)
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
                            writer.WriteLine("ID,Name,Function, Email, Address");

                            foreach (var employee in employees)
                            {
                                writer.WriteLine($"{employee.EmployeeId},{employee.Username},{employee.Role}, {employee.Email}, {employee.Address}");
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

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "JSON Files (*.json)|*.json";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string jsonFilePath = saveFileDialog.FileName;

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

                        // Create a list to store employee data as dictionaries
                        List<Dictionary<string, object>> employeeData = new List<Dictionary<string, object>>();

                        foreach (var employee in employees)
                        {
                            var employeeDict = new Dictionary<string, object>
                            {
                                { "EmployeeId", employee.EmployeeId },
                                { "Username", employee.Username },
                                { "Role", employee.Role },
                                { "Email", employee.Email },
                                { "Address", employee.Address }
                            };
                            employeeData.Add(employeeDict);
                        }

                        // Serialize the employee data to JSON
                        string json = SerializeToJson(employeeData);

                        // Write JSON to the file
                        File.WriteAllText(jsonFilePath, json);

                        MessageBox.Show("Data Exported to JSON Successfully!!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }
        private string SerializeToJson(List<Dictionary<string, object>> data)
        {
            List<string> jsonObjects = new List<string>();

            foreach (var item in data)
            {
                List<string> keyValuePairs = new List<string>();
                foreach (var kvp in item)
                {
                    keyValuePairs.Add($"\"{kvp.Key}\": \"{kvp.Value}\"");
                }
                jsonObjects.Add("{" + string.Join(",", keyValuePairs) + "}");
            }

            return "[" + string.Join(",", jsonObjects) + "]";
        }
    }
}
