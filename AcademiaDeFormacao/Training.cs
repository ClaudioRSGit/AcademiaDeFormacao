using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiaDeFormacao
{
    internal class Training
    {
        public int TrainingID { get; set; }
        public string TrainerName { get; set; }
        public string Description { get; set; }
        public DateTime TrainingStartDate { get; set; }
        public DateTime TrainingEndDate { get; set; }
        
        public Training()
        {

        }
        public Training(string description, DateTime trainingStartDate, DateTime trainingEndDate, string trainerName)
        {
            Description = description;
            TrainingStartDate = trainingStartDate;
            TrainingEndDate = trainingEndDate;
            TrainerName = trainerName;
        }
        public Training(int trainingID, string description, DateTime trainingStartDate, DateTime trainingEndDate, string trainerName)
        {
            TrainingID = trainingID;
            Description = description;
            TrainingStartDate = trainingStartDate;
            TrainingEndDate = trainingEndDate;
            TrainerName = trainerName;
        }
    }
}
