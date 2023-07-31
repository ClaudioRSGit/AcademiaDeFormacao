using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiaDeFormacao
{
    internal class Training
    {
        private DateTime startTraining;
        private DateTime endTraining;

        public DateTime StartTraining { get; set; }

        public DateTime EndTraining { get; set; }

        public Training(DateTime startTraining, DateTime endTraining)
        {
            StartTraining = startTraining;
            EndTraining = endTraining;
        }
    }
}
