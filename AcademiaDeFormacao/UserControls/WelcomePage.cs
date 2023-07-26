using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AcademiaDeFormacao.UserControls
{
    public partial class WelcomePage : UserControl
    {
        public WelcomePage()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label_Form1_Data.Text = DateTime.Now.ToLongDateString();
            label_Hora.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }


        private void label_Form1_Data_Click(object sender, EventArgs e)
        {

        }

        private void label_Hora_Click(object sender, EventArgs e)
        {

        }
    }
}
