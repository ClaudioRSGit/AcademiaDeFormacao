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
    public partial class Scheduler : Form
    {
        int trainingID = 4;
        public Scheduler()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            // Set the first DateTimePicker to today's date
            dt_trainingStartDate.Value = DateTime.Today;

            // Disable the first DateTimePicker
            dt_trainingStartDate.Enabled = false;

            // Set the minimum date for the first DateTimePicker to today
            dt_trainingEndDate.MinDate = dt_trainingStartDate.Value;
            dt_trainingStartDate.MinDate = DateTime.Today;
        }
        public void PopulateTrainersComboBox()
        {
            using (var context = new School())
            {
                // Query the Employees table to get the trainer names
                var trainerNames = context.Employees
                    .Where(emp => emp.Role == "Trainer")
                    .Select(emp => emp.Name)
                    .ToList();

                // Bind the trainer names to the ComboBox
                cmb_trainers.DataSource = trainerNames;

                // Query the Employees table to get the distinct EducationArea values
                var educationAreas = context.Trainers
                    .Where(emp => !string.IsNullOrEmpty(emp.EducationArea))
                    .Select(emp => emp.EducationArea)
                    .Distinct()
                    .ToList();

                // Bind the education areas to the cmb_classes ComboBox
                cmb_classes.DataSource = educationAreas;
            }
        }

        private void btn_saveTraining_Click(object sender, EventArgs e)
        {
            using (var context = new School())
            {
                string selectedDescription = cmb_classes.SelectedItem.ToString();
                string selectedTrainerName = cmb_trainers.SelectedItem.ToString();

                // Create a new Training object without specifying an ID
                var newTraining = new Training
                {
                    Description = selectedDescription,
                    TrainingStartDate = dt_trainingStartDate.Value.Date,
                    TrainingEndDate = dt_trainingEndDate.Value.Date,
                    TrainerName = selectedTrainerName
                };

                // Add the new training to the context and save changes
                context.TrainingSessions.Add(newTraining);
                context.SaveChanges();
                MessageBox.Show("Training Scheduled Successfully!");
                this.Close();
            }
        }


    }
}
