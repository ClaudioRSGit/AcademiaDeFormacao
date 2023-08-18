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
        public EditProfile(string userName)
        {
            InitializeComponent();
            AuthenticatedUser = userName;
            PopulateFormFields();
        }

        public string AuthenticatedUser { get; set; }

        public string MyProperty { get; set; }

        private void PopulateFormFields()
        {
            using (var context = new School())
            {
                // Query the Employees table based on the authenticated username
                var employee = context.Employees.FirstOrDefault(emp => emp.Username == AuthenticatedUser);

                if (employee != null)
                {
                    MyProperty = employee.Name;
                }
            }
        }

        

        private void txt_name_TextChanged(object sender, EventArgs e)
        {
           
        }
        private void button1_Click(object sender, EventArgs e)
        {
            txt_name.Text = MyProperty;
        }
    }
}
