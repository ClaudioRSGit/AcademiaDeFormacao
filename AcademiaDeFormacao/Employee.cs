using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace AcademiaDeFormacao
{
        internal class Employee
        {
            public int EmployeeId { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
            public double Salary { get; set; }
            public string Role { get; set; }
            public string Address { get; set; }
            public string Contact { get; set; }
            public DateTime ContractEndDate { get; set; }
            public DateTime CriminalRecordEndDate { get; set; }

            public Employee(
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
                DateTime criminalRecordEndDate)
            {
                EmployeeId = employeeId;
                Username = username;
                Password = password;
                Name = name;
                Email = email;
                Salary = salary;
                Role = role;
                Address = address;
                Contact = contact;
                ContractEndDate = contractEndDate;
                CriminalRecordEndDate = criminalRecordEndDate;

            }

        }

}
