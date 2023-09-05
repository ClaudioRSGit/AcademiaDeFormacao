using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiaDeFormacao
{
    internal class Director : Employee
    {
        public bool TimeExemption { get; set; }
        public double MonthlyBonus { get; set; }
        public bool CompanyCar { get; set; }

        public Director(
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
            bool timeExemption,
            double monthlyBonus,
            bool companyCar,
            bool accountStatus) : base(employeeId, username, password, name, email, salary, role, address, contact, dateOfBirth, contractEndDate, criminalRecordEndDate,accountStatus)
        {
            TimeExemption = timeExemption;
            MonthlyBonus = monthlyBonus;
            CompanyCar = companyCar;
        }

        public Director() { }
    }
}
