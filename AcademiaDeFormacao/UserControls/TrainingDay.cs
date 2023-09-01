﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TryProject;

namespace AcademiaDeFormacao.UserControls
{
    public partial class TrainingDay : UserControl
    {
        public string TrainerAndDescription { get; set; }

        public event Action<DateTime> DayClicked;
        public int Year { get; set; }
        public int Month { get; set; }
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
            int dayNumber = Convert.ToInt32(lb_days.Text);
            DateTime clickedDate = new DateTime(Year, Month, dayNumber);

            Scheduler scheduler1 = new Scheduler();
            scheduler1.PopulateTrainersComboBox();
            scheduler1.Show();

            // Pass the DateTime to the event handler
            DayClicked?.Invoke(clickedDate);
        }

    }
}