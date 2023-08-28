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
            DateTime dateOfBirth,
            DateTime contractEndDate,
            DateTime criminalRecordEndDate,
            string educationArea,
            string availability,
            double timeValue,
            bool accountStatus) : base(employeeId, username, password, name, email, salary, role, address, contact, dateOfBirth, contractEndDate, criminalRecordEndDate, accountStatus)
        {
            EducationArea = educationArea;
            Availability = availability;
            TimeValue = timeValue;

            int currentMonth = DateTime.Today.Month;
            int daysInCurrentMonth = DateTime.DaysInMonth(DateTime.Today.Year, currentMonth);
            double calculatedSalary = (timeValue * 6) * daysInCurrentMonth;
            Salary = calculatedSalary;
        }

        public Trainer() { }
    }
}
