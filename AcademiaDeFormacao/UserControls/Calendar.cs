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
        public string AuthenticatedUser { get; set; }
        public string UserRole { get; set; }
        public Calendar()
        {
            InitializeComponent();
            DateTime now = DateTime.Now;
            month = now.Month;
            year = now.Year;

            displayMonth();
        }
        public void PopulateData(string authUser, string userRole)
        {
            this.AuthenticatedUser = authUser;
            this.UserRole = userRole;
        }
        public void displayMonth()
        {
            // Limpar o container de dias antes de adicionar novos dias
            dayContainer.Controls.Clear();

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
                Panel dayPanel = new Panel();
                dayPanel.BackColor = Color.FromArgb(61, 69, 76);
                dayPanel.Size = new Size(80, 78);

                Label dayLabel = new Label();
                dayLabel.AutoSize = true;
                dayLabel.Font = new Font("Arial", 8);
                dayLabel.Text = i.ToString();
                dayLabel.ForeColor = Color.White;

                // Position the label within the panel
                dayLabel.Location = new Point(5, 5); // Adjust the position as needed

                // Add the label to the panel
                dayPanel.Controls.Add(dayLabel);

                Label lblTrainingDay = new Label();
                lblTrainingDay.AutoSize = true;
                lblTrainingDay.Font = new Font("Arial", 8);
                lblTrainingDay.ForeColor = Color.Green;

                // Position the label within the panel
                lblTrainingDay.Location = new Point(15, 15); // Adjust the position as needed
                dayPanel.Controls.Add(lblTrainingDay);


                DateTime selectedDate = new DateTime(year, month, dayOfTheWeek);

                using (var context = new School())
                {
                    var training = context.TrainingSessions
                        .FirstOrDefault(Training =>
                            selectedDate >= Training.TrainingStartDate &&
                            selectedDate <= Training.TrainingEndDate);

                    if (training != null)
                    {
                        lblTrainingDay.Text = $"{training.TrainerName} \n {training.Description}";
                    }
                    else
                    {
                        lblTrainingDay.Text = string.Empty; // No training session, so clear the label
                    }
                }

                dayContainer.Controls.Add(dayPanel);

                dayPanel.Click += (sender, e) =>
                {
                    int dayNumber = Convert.ToInt32(dayLabel.Text); // Get the day number from the label
                    DateTime clickedDate = new DateTime(year, month, dayNumber);

                    Scheduler scheduler1 = new Scheduler();
                    scheduler1.PopulateTrainersComboBox();
                    scheduler1.Show();

                };
            }
        }

        public void PopulateTrainingDays(int year, int month)
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
