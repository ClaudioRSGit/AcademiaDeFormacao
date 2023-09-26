using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;   //Border on Form

namespace TryProject
{
    public partial class Menu : Form
    {
        #region FormBorder
        //Put border on Form
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

            //Pass information to the form
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

            // Close
            void CloseForm(object sender, EventArgs e)
            {
                log.Close();
            }
            this.FormClosing += CloseForm;
        }

        #region Utils
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

        private void picB_Login_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Login().Show();
        }

        private void btn_ExitProgram_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        
        private void picB_WelcomePage_Click(object sender, EventArgs e)
        {
            ShowUserControl(welcomePage1);
        }
        #endregion

        #region AddEmployee
        private void picB_AddEmployee_Click(object sender, EventArgs e)
        {
            ShowUserControl(addEmployee1);
            addEmployee1.LoadDirectors();
            addEmployee1.LoadTrainers();
        }

        #endregion

        #region Contracts
        private void btn_CalculateSalary_Click(object sender, EventArgs e)
        {
            DashBoard.PopulateDashboard();
            ShowUserControl(DashBoard);
        }

        private void picB_Contracts_Click(object sender, EventArgs e)
        {
            contracts1.PopulateFormFields();
            ShowUserControl(contracts1);
        }

        #endregion

        #region ExportData
        private void picB_ExportCSV_Click(object sender, EventArgs e)
        {
            exportData2.LoadDatabasePreview();
            ShowUserControl(exportData2);
        }

        #endregion

        #region EditProfile
        private void picB_EditProf_Click(object sender, EventArgs e)
        {
            OnMenuEditProf.PopulateFormFields(this.AuthenticatedUser);
            ShowUserControl(OnMenuEditProf);
        }

        #endregion
    }
}
