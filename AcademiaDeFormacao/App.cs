using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TryProject
{
    public partial class App : Form
    {
        private registerPanel registerPanel;
        private loginPanel loginPanel;
        public App()
        {
            InitializeComponent();
<<<<<<< HEAD:AcademiaDeFormacao/Login.cs
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void lbl_singUp_Click(object sender, EventArgs e)
        {
            this.Hide();
            new SignUp().Show();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Menu().Show();
=======
            DisableFormResize();
            CenterFormOnScreen();
        }
        private void DisableFormResize()
        {
            FormBorderStyle = FormBorderStyle.FixedSingle; // Set the form's border style to fixed
            MaximizeBox = false; // Disable the maximize button
            MinimizeBox = true; // Disable the minimize button
            // ControlBox = false; // Disable the control box (close, minimize, maximize buttons)
            // ResizeRedraw = false; // Disable redrawing of the form while resizing
        }
        private void CenterFormOnScreen()
        {
            StartPosition = FormStartPosition.CenterScreen;
            //Set the form's start position to center screen
>>>>>>> 15b440fd6ad9e00e3f1a84d33a934101fd44e8af:AcademiaDeFormacao/App.cs
        }
        
    }
}
