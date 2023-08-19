using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace AcademiaDeFormacao.UserControls
{
    public partial class EditProfile : UserControl
    {
        public string AuthenticatedUser { get; set; }
        public EditProfile(string userName)
        {
            InitializeComponent();
            this.AuthenticatedUser = userName;
            PopulateFormFields(userName);
        }

        private void PopulateFormFields(string userName)
        {
            try
            {
                using (var context = new School())
                {
                    var employee = context.Employees.FirstOrDefault(emp => emp.Username == userName);
                    
                    if (employee != null)
                    {
                        MessageBox.Show("name: " + employee.Name + "\n" + "pass: " + employee.Password + "\n" + "contact: " + employee.Contact);
                        
                        
                        userName = txt_name.Text;

                    }
                    else
                    {
                        MessageBox.Show("Employee not found.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        

        
        private void button1_Click(object sender, EventArgs e)
        {
            
        }
        private void txt_name_TextChanged(object sender, EventArgs e)
        {
           
        }
    }
}
