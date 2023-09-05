using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;   //Colocar border no Form
using AcademiaDeFormacao.UserControls;
using System.Threading;
using AcademiaDeFormacao;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Runtime.Remoting.Contexts;

namespace TryProject
{
    public partial class Menu : Form
    {
        #region Colocar border form
        //Isto serve para colocar border no form 
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn(
                    int nLeftRect,
                    int nTopRect,
                    int nRightRect,
                    int nBottomRect,
                    int nWidthEllipse,
                    int nHeightEllipse
            );
        #endregion

        

        public string AuthenticatedUser { get; set; }
        public string UserRole { get; set; }

        public Menu(string userName, string userRole, Form log)
        {
            InitializeComponent();
            ShowUserControl(welcomePage1);
            this.AuthenticatedUser = userName;
            this.UserRole = userRole;
            lbl_DisplayUserName.Text = userName;
            UserRole = userRole;

            lbl_role.Text = userRole;
            // Calculate the center position within panel1
            int centerX = (panel1.Width - lbl_role.Width) / 2;
            int centerY = 70;

            // Set the label's location
            lbl_role.Location = new Point(centerX, centerY);
 

            void CloseForm(object sender,EventArgs e)
            {
                log.Close();
            }
            this.FormClosing += CloseForm;
        }




        private void ShowUserControl(UserControl userControl)
        {
            addEmployee1.Hide();
            welcomePage1.Hide();
            DashBoard.Hide();
            contracts1.Hide();
            OnMenuEditProf.Hide();
            exportData2.Hide();

            userControl.Show();
        }


        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Login().Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            ShowUserControl(addEmployee1);
            addEmployee1.LoadDirectors();
            addEmployee1.LoadTrainers();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //contracts1.PopulateFormFields();
            //ShowUserControl(contracts1);
        }

        private void btn_ExitProgram_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void btn_CalculateSalary_Click(object sender, EventArgs e)
        {
            DashBoard.PopulateDashboard();
            ShowUserControl(DashBoard);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ShowUserControl(welcomePage1);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            try
            {
                contracts1.PopulateFormFields();
                ShowUserControl(contracts1);
            }
            catch
            {

            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            try
            {
                exportData2.LoadDatabasePreview();
                ShowUserControl(exportData2);
            }
            catch
            {
                
            }
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            OnMenuEditProf.PopulateFormFields(this.AuthenticatedUser);
            //OnMenuEditProf = new EditUserProfile();
            ShowUserControl(OnMenuEditProf);
        }
    }
}
