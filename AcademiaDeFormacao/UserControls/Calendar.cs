using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace AcademiaDeFormacao.UserControls
{
    public partial class Calendar : UserControl
    {
        int month, year;
        public string AuthenticatedUser { get; set; }
        public string UserRole { get; set; }

        private ToolTip dayToolTip = new ToolTip();
        public Calendar()
        {
            InitializeComponent();
            DateTime now = DateTime.Now;
            month = now.Month;
            year = now.Year;
        }
        public void PopulateData(string authUser, string userRole)
        {
            this.AuthenticatedUser = authUser;
            this.UserRole = userRole;
        }
        public void displayMonth()
        {
            dayContainer.Controls.Clear();

            string monthName = DateTimeFormatInfo.CurrentInfo.GetMonthName(month);
            lbl_dateMonthYear.Text = monthName + " " + year;

            DateTime firstDayOfMonth = new DateTime(year, month, 1);

            int daysCount = DateTime.DaysInMonth(year, month);

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

                dayLabel.Location = new Point(5, 5);

                dayPanel.Controls.Add(dayLabel);

                Label lblTrainingDay = new Label();
                lblTrainingDay.AutoSize = true;
                lblTrainingDay.Font = new Font("Arial", 8);
                lblTrainingDay.ForeColor = Color.Green;

                int horizontalCenter = (dayPanel.Width - lblTrainingDay.Width) / 2;
                int verticalCenter = (dayPanel.Height - lblTrainingDay.Height) / 2;

                horizontalCenter = Math.Max(horizontalCenter, 0);
                verticalCenter = Math.Max(verticalCenter, 0);

                lblTrainingDay.Location = new Point(horizontalCenter, verticalCenter);
                dayPanel.Controls.Add(lblTrainingDay);

                DateTime selectedDate = new DateTime(year, month, dayOfTheWeek);
                dayToolTip.SetToolTip(dayPanel, GetTrainingSessionsTooltip(selectedDate));

                dayContainer.Controls.Add(dayPanel);


                using (var context = new School())
                {
                    var training = context.TrainingSessions
                        .FirstOrDefault(Training =>
                            selectedDate >= Training.TrainingStartDate &&
                            selectedDate <= Training.TrainingEndDate);

                    if (training != null)
                    {
                        //training found
                        lblTrainingDay.Text = $"{training.TrainerName} \n {training.Description}";
                    }
                    else
                    {
                        lblTrainingDay.Text = string.Empty; // No training session, clear the label
                    }
                }

                dayContainer.Controls.Add(dayPanel);

                //Training day click event
                dayPanel.Click += (sender, e) =>
                {
                    if (UserRole == "Coordinator")
                    {
                        int dayNumber = Convert.ToInt32(dayLabel.Text);
                        DateTime clickedDate = new DateTime(year, month, dayNumber);

                        Scheduler scheduler1 = new Scheduler();
                        scheduler1.PopulateTrainersComboBox();
                        scheduler1.Show();
                    }
                };
            }
        }

        private string GetTrainingSessionsTooltip(DateTime selectedDate)
        {
            using (var context = new School())
            {
                var trainingSessions = context.TrainingSessions
                    .Where(Training =>
                        selectedDate >= Training.TrainingStartDate &&
                        selectedDate <= Training.TrainingEndDate)
                    .ToList();

                if (trainingSessions.Count > 0)
                {
                    StringBuilder tooltipText = new StringBuilder();
                    tooltipText.AppendLine("Training Sessions:");

                    foreach (var training in trainingSessions)
                    {
                        string formattedTimeStart = training.TrainingStartDate.ToString("hh:mm tt");
                        string formattedTimeEnd = training.TrainingEndDate.ToString("hh:mm tt");

                        tooltipText.AppendLine($"{formattedTimeStart} - {formattedTimeEnd} : {training.TrainerName} - {training.Description}");
                    }
                    return tooltipText.ToString();
                }
                else
                {
                    return "No training sessions for this day.";
                }
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