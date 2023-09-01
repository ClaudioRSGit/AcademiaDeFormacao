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
        public string TrainerName { get; set; }
        public int TrainingId { get; set; }
        public string Description { get; set; }
        public DateTime TrainingStartDate { get; set; }
        public DateTime TrainingEndDate { get; set; }
        
        public Training(int trainingID,string description, DateTime trainingStartDate, DateTime trainingEndDate, string trainerName)
        {
            TrainingId = trainingID;
            Description = description;
            TrainingStartDate = trainingStartDate;
            TrainingEndDate = trainingEndDate;
            TrainerName = trainerName;
        }
    }
}
