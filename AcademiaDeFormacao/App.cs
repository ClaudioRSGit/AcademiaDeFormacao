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
    public partial class App : Form
    {
        private registerPanel registerPanel;
        private loginPanel loginPanel;
        public App()
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
        private void CenterFormOnScreen()
        {
            StartPosition = FormStartPosition.CenterScreen;
            //Set the form's start position to center screen
        }
        
    }
}
