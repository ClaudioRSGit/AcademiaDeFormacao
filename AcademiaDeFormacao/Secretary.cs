using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiaDeFormacao
{
    internal class Secretary : Employee
    {
        public int DiretorID { get; set; }
        public string Area { get; set; }

        [ForeignKey("DiretorID")]
        public virtual Director DiretorReporta { get; set; }

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
            DateTime dateOfBirth,
            DateTime contractEndDate,
            DateTime criminalRecordEndDate,
            int reportingToDirector,
            string area) : base(employeeId, username, password, name, email, salary, role, address, contact, dateOfBirth, contractEndDate, contractEndDate)
        {
            DiretorID = reportingToDirector;
            Area = area;
        }

        public Secretary() { }
    }
}
