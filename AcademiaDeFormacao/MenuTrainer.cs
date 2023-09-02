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
using TryProject;

namespace AcademiaDeFormacao
{
    public partial class MenuTrainer : Form
    {
        public string AuthenticatedUser { get; set; }
        public string UserRole { get; set; }
        public MenuTrainer(string userName, string userRole, Form log)
        {
            InitializeComponent();
            AuthenticatedUser = userName;
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        private void ShowUserControl(UserControl userControl)
        {
            welcomePage2.Hide();
            calendar2.Hide();
            editUserProfile2.Hide();

            userControl.Show();
        }
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Login().Show();
        }

        private void associateTrainings_Click(object sender, EventArgs e)
        {
            ShowUserControl(calendar2);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ShowUserControl(welcomePage2);
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            editUserProfile2.PopulateFormFields(this.AuthenticatedUser);
            ShowUserControl(editUserProfile2);
        }

        private void pictureBox6_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            new Login().Show();
        }
    }
}
