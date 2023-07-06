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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
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
        //Set the form's start position to center screen
        private void CenterFormOnScreen()
        {
            StartPosition = FormStartPosition.CenterScreen; 
        }
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            new SignUp().Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void register1_Load(object sender, EventArgs e)
        {

        }
    }
}
