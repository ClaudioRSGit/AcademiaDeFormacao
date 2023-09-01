using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TryProject;

namespace AcademiaDeFormacao.UserControls
{
    public partial class TrainingDay : UserControl
    {
        public TrainingDay()
        {
            InitializeComponent();
        }
        public void TrainingDays(int numDay)
        {
            lb_days.Text = Convert.ToString(numDay);
        }

        private void TrainingDay_Click(object sender, EventArgs e)
        {
            new Scheduler().Show();
        }

        private void TrainingDay_Load(object sender, EventArgs e)
        {
            
        }
    }
}
