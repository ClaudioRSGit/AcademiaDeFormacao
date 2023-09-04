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
            this.StartPosition = FormStartPosition.CenterScreen;
            this.AuthenticatedUser = userName;
            this.UserRole = userRole;

            void CloseForm(object sender, EventArgs e)
            {
                log.Close();
            }
            this.FormClosing += CloseForm;
        }
        private void ShowUserControl(UserControl userControl)
        {
            OnMenuTrainerWelcome.Hide();
            OnMenuTrainerCalendar.Hide();
            OnMenuTrainerEditProfile.Hide();

            userControl.Show();
        }
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Login().Show();
        }

        private void associateTrainings_Click(object sender, EventArgs e)
        {
            OnMenuTrainerCalendar.displayMonth();
            OnMenuTrainerCalendar.PopulateData(AuthenticatedUser,UserRole);
            ShowUserControl(OnMenuTrainerCalendar);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ShowUserControl(OnMenuTrainerWelcome);
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            OnMenuTrainerEditProfile.PopulateFormFields(this.AuthenticatedUser);
            ShowUserControl(OnMenuTrainerEditProfile);
        }

        private void pictureBox6_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            new Login().Show();
        }
    }
}
