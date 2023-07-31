using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiaDeFormacao
{
    internal class Coordinator : Employee
    {
        public List<Trainer> AssociatedTrainer { get; set; }

        public Coordinator(
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
           DateTime criminalRecordEndDate) : base(employeeId, username, password, name, email, salary, role, address, contact, contractEndDate, contractEndDate)
        {
            AssociatedTrainer = new List<Trainer>();
        }
        public void AddTrainer(Trainer formador)
        {
            AssociatedTrainer.Add(formador);
        }

        public void RemoveTrainer(Trainer formador)
        {
            AssociatedTrainer.Remove(formador);
        }
    }
}
