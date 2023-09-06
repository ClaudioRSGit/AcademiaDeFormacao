using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiaDeFormacao
{
    internal class Coordinator : Employee
    {
        public List<Trainer> Trainers = new List<Trainer>();


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
           DateTime dateOfBirth,
           DateTime contractEndDate,
           DateTime criminalRecordEndDate,
           bool accountStatus) : base(employeeId, username, password, name, email, salary, role, address, contact, dateOfBirth, contractEndDate, 
           criminalRecordEndDate, accountStatus)
        {
            Trainers = new List<Trainer>();
        }

        public Coordinator() { }

        public void AddTrainer(Trainer trainer)
        {
            Trainers.Add(trainer);
        }

        public void RemoveTrainer(Trainer trainer)
        {
            Trainers.Remove(trainer);
        }
    }
}
