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
        public MenuTrainer(string userName, string userRole, Form log)
        {
            InitializeComponent();
        }
        private void ShowUserControl(UserControl userControl)
        {
            welcomePage1.Hide();
            calendar1.Hide();
            editUserProfile1.Hide();

            userControl.Show();
        }
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Login().Show();
        }

        private void associateTrainings_Click(object sender, EventArgs e)
        {
            ShowUserControl(calendar1);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ShowUserControl(welcomePage1);
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            ShowUserControl(editUserProfile1);
        }
        public void showScheduler()
        {
        }
    }
}
