using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace AcademiaDeFormacao.UserControls
{
    public partial class EditUserProfile : UserControl
    {

        public EditUserProfile()
        {
            InitializeComponent();
            //this.AuthenticatedUser = userName;
            //PopulateFormFields(userName);
        
        }

        public void PopulateFormFields(string userName)
        {
            try
            {
                using (var context = new School())
                {
                    var employee = context.Employees.FirstOrDefault(emp => emp.Username == userName);

                    if (employee != null)
                    {
                        test.Text = employee.Name;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
    }
}
