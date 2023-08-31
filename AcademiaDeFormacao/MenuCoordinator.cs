using AcademiaDeFormacao.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AcademiaDeFormacao
{
    public partial class MenuCoordinator : Form
    {
        public MenuCoordinator()
        {
            InitializeComponent();
        }
        private void ShowUserControl(UserControl userControl)
        {
            welcomePage1.Hide();

            userControl.Show();
        }
        private void pictureBox8_Click(object sender, EventArgs e)
        {
            /*editUserProfile1.PopulateFormFields();
            ShowUserControl(editUserProfile1);*/
        }
    }
}
