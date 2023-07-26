using System;
using System.Collections.Generic;
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
            DateTime contractEndDate,
            DateTime criminalRecordEndDate,
            bool timeExemption,
            double monthlyBonus,
            bool companyCar) : base(employeeId, username, password, name, email, salary, role, address, contact, contractEndDate, contractEndDate)
        {
            TimeExemption = timeExemption;
            MonthlyBonus = monthlyBonus;
            CompanyCar = companyCar;
        }
    }
}
