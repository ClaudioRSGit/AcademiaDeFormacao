using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AcademiaDeFormacao.UserControls
{
    public partial class Calendar : UserControl
    {
        int month, year;

        public Calendar()
        {
            InitializeComponent();
            displayDays();
        }
        public void displayMonth()
        {
            string monthName = DateTimeFormatInfo.CurrentInfo.GetMonthName(month);
            lbl_dateMonthYear.Text = monthName + " " + year;

            //first day of the month
            DateTime firstDayOfMonth = new DateTime(year, month, 1);

            //days count per month
            int daysCount = DateTime.DaysInMonth(year, month);

            //convert firstDayOfMonth to int
            int dayOfTheWeek = Convert.ToInt32(firstDayOfMonth.DayOfWeek.ToString("d")) + 1;

            for (int i = 1; i < dayOfTheWeek; i++)
            {
                Day day = new Day();
                dayContainer.Controls.Add(day);
            }

            for (int i = 1; i <= daysCount; i++)
            {
                TrainingDay trainingDay = new TrainingDay();
                trainingDay.TrainingDays(i);

                // Set the Year and Month properties
                trainingDay.Year = year;
                trainingDay.Month = month;

                dayContainer.Controls.Add(trainingDay);

                trainingDay.DayClicked += DayClicked;
            }
        }
        public void PopulateTrainingDays(int year, int month)
        {

        }
        private void DayClicked(DateTime clickedDate)
        {
            
        }
        private void displayDays()
        {
            DateTime now = DateTime.Now;
            month = now.Month;
            year = now.Year;

            displayMonth();
        }

        private void btn_previous_Click(object sender, EventArgs e)
        {
            month--;
            if (month < 1)
            {
                month = 12;
                year--;
            }
            dayContainer.Controls.Clear();
            displayMonth();
        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            month++;
            if (month > 12)
            {
                month = 1;
                year++;
            }
            dayContainer.Controls.Clear();
            displayMonth();
        }

    }
}
