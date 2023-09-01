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
    }
}
