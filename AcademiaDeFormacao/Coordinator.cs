﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiaDeFormacao
{
    internal class Coordinator : Employee
    {
        public virtual ICollection<Trainer> AssociatedTrainer { get; set; }

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
           DateTime criminalRecordEndDate) : base(employeeId, username, password, name, email, salary, role, address, contact, dateOfBirth, contractEndDate, contractEndDate)
        {
            AssociatedTrainer = new List<Trainer>();
        }

        public Coordinator() { }

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
