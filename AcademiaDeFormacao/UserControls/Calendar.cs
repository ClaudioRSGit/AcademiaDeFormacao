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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

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
            //displayMonth();
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

            dayContainer.Enabled = UserRole == "Coordinator" ? true : false;

            if (UserRole == "Trainer")
            {
                string trainerName = ConvertUsernameToFullName(AuthenticatedUser);
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

                    // Calculate the position to center the label
                    int horizontalCenter = (dayPanel.Width - lblTrainingDay.Width) / 2;
                    int verticalCenter = (dayPanel.Height - lblTrainingDay.Height) / 2;

                    // Ensure the label is within the panel's bounds
                    horizontalCenter = Math.Max(horizontalCenter, 0);
                    verticalCenter = Math.Max(verticalCenter, 0);

                    // Set the label's location
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
                                selectedDate <= Training.TrainingEndDate &&
                                Training.TrainerName == trainerName);

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
            else
            {
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

                    // Calculate the position to center the label
                    int horizontalCenter = (dayPanel.Width - lblTrainingDay.Width) / 2;
                    int verticalCenter = (dayPanel.Height - lblTrainingDay.Height) / 2;

                    // Ensure the label is within the panel's bounds
                    horizontalCenter = Math.Max(horizontalCenter, 0);
                    verticalCenter = Math.Max(verticalCenter, 0);

                    // Set the label's location
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
        }
        static string ConvertUsernameToFullName(string username)
        {
            // Split the username by periods
            string[] parts = username.Split('.');

            // Create a TextInfo object to properly capitalize names
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;

            // Capitalize each part and join them with a space
            string fullName = string.Join(" ", Array.ConvertAll(parts, part => textInfo.ToTitleCase(part)));

            return fullName;
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
                        tooltipText.AppendLine($"{training.TrainerName}: {training.Description}");
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
