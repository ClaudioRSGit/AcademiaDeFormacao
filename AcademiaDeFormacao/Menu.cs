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



        public Menu()
        {
            InitializeComponent();
            //Colocar border no Form
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0,0,Width,Height,25,25));
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Login().Show();
        }

        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void btn_ExitProgram_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
