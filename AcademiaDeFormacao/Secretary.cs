using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiaDeFormacao
{
    internal class Secretary : Employee
    {
        public string ReportingToDirector { get; set; }
        public string Area { get; set; }

        public Secretary(
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
            string reportingToDirector,
            string area) : base(employeeId, username, password, name, email, salary, role, address, contact, contractEndDate, contractEndDate)
        {
            ReportingToDirector = reportingToDirector;
            Area = area;
        }
    }
}
