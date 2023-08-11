using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiaDeFormacao
{
    internal class Trainer : Employee
    {
        public string EducationArea { get; set; }
        public string Availability { get; set; }
        public double TimeValue { get; set; }

        public Trainer(
            int employeeId,
            string username,
            string password,
            string name,
            string email,
            double salary,
            string role,
            string address,
            string contact,
            DateTime contractEndDate,
            DateTime criminalRecordEndDate,
            string educationArea,
            string availability,
            double timeValue) : base(employeeId, username, password, name, email, salary, role, address, contact, contractEndDate, criminalRecordEndDate)
        {
            EducationArea = educationArea;
            Availability = availability;
            TimeValue = timeValue;
        }

        public Trainer() { }
    }
}
