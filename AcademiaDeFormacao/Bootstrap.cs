using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AcademiaDeFormacao
{
    internal class Bootstrap
    {
        //Trainers
        public static void DefaultTrainers()
        {
            using (var context = new School())
            {
                Trainer trainer1 = new Trainer(
                    1,                          //int employeeId,
                    "ana.silva",                //string username,
                    "senha123",                 //string password,
                    "Ana Silva",                //string name,
                    "ana_silva@email.com",      //string email,
                    0.0,                        //double salary,
                    "Trainer",                  //string role,
                    "Rua dos Formadores, Lisboa",//string address,
                    "+351 912345678",           //string contact,
                    new DateTime(1997, 12, 31), //DateTime dateOfBirth,
                    new DateTime(2027, 12, 31), //DateTime contractEndDate,
                    new DateTime(2027, 6, 30),  //DateTime criminalRecordEndDate,
                    "Ciência da Computação",    //string educationArea,
                    "Período Integral",         //string availability,
                    9.5,                        //double timeValue
                    true                        //bool accountStatus
                );

                Trainer trainer2 = new Trainer(
                    2,
                    "ricardo.sousa",
                    "ricardo123",
                    "Ricardo Sousa",
                    "ricardo_sousa@email.com",
                    0.0,
                    "Trainer",
                    "Avenida dos Designers, Porto",
                    "+351 919876543",
                    new DateTime(1980, 10, 11),
                    new DateTime(2029, 6, 30),
                    new DateTime(2028, 12, 31),
                    "Web Design e Multimédia",
                    "Meio Período",
                    10.0,
                    true
                );

                Trainer trainer3 = new Trainer(
                    3,
                    "marta.pereira",
                    "marta123",
                    "Marta Pereira",
                    "marta.pereira@email.com",
                    0.0,
                    "Trainer",
                    "Praça do Marketing, Coimbra",
                    "+351 934567890",
                    new DateTime(1994, 02, 20),
                    new DateTime(2031, 9, 30),
                    new DateTime(2030, 8, 31),
                    "Marketing e Publicidade",
                    "Período Integral",
                    15.0,
                    true
                );

                //Add to lists
                context.Trainers.Add(trainer1);
                context.Trainers.Add(trainer2);
                context.Trainers.Add(trainer3);
                context.SaveChanges();
            }

        }

        //Coordinators
        public static void DefaultCoordinators()
        {
            using (var context = new School())
            {
                Coordinator coordinator1 = new Coordinator(
                   1,
                   "alice.brown",
                   "password123",
                   "Alice Brown",
                   "alice@example.com",
                   1200,
                   "Coordinator",
                   "123 Main St",
                   "555-1212",
                   new DateTime(1995, 12, 31),
                   DateTime.Now.Date.AddDays(60),
                   DateTime.Now.Date.AddDays(90),
                   true

                );

                Coordinator coordinator2 = new Coordinator(
                    2,
                    "david.lee",
                    "pass123",
                    "David Lee",
                    "david@example.com",
                    1300,
                    "Coordinator",
                    "789 Elm St",
                    "555-9101",
                    new DateTime(1997, 12, 31),
                    DateTime.Now.Date.AddDays(60),
                    DateTime.Now.Date.AddDays(90),
                    true
                );

                Coordinator coordinator3 = new Coordinator(
                    3,
                    "paul.garcia",
                    "paulpass",
                    "Paul Garcia",
                    "paul@example.com",
                    1100,
                    "Coordinator",
                    "789 Maple St",
                    "555-4321",
                    new DateTime(1997, 12, 31),
                    DateTime.Now.Date.AddDays(60),
                    DateTime.Now.Date.AddDays(90),
                    true
                );
                //Add to lists
                context.Coordinators.Add(coordinator1);
                context.Coordinators.Add(coordinator2);
                context.Coordinators.Add(coordinator3);
                context.SaveChanges();
            }



        }

        //Directors
        public static void DefaultDirectors()
        {
            /*
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
            bool companyCar*/

            using (var context = new School())
            {
                Director director1 = new Director(
                   4,
                   "john.doe",
                   "password123",
                   "John Doe",
                   "john@example.com",
                   5000.0,
                   "Director",
                   "456 Oak St",
                   "555-9876",
                   new DateTime(1985, 12, 31),
                   new DateTime(2040, 12, 31),
                   new DateTime(2036, 12, 31),
                   true,
                   1000.0,
                   true,
                   true
                );

                Director director2 = new Director(
                    5,
                    "jane.smith",
                    "pass123",
                    "Jane Smith",
                    "jane@example.com",
                    6000.0,
                    "Director",
                    "789 Maple St",
                    "555-1234",
                    new DateTime(1985, 12, 31),
                    new DateTime(2039, 12, 31),
                    new DateTime(2027, 12, 31),
                    false,
                    1500.0,
                    false,
                    true
                );

                Director director3 = new Director(
                    6,
                    "michael.johnson",
                    "mypass",
                    "Michael Johnson",
                    "michael@example.com",
                    5500.0,
                    "Director",
                    "321 Pine St",
                    "555-5678",
                    new DateTime(1985, 12, 31),
                    new DateTime(2050, 12, 31),
                    new DateTime(2036, 12, 31),
                    true,
                    1200.0,
                    true,
                    true
                );

                //Add to lists
                context.Directors.Add(director1);
                context.Directors.Add(director2);
                context.Directors.Add(director3);
                context.SaveChanges();
            }

        }
        //Secretaries
        public static void DefaultSecretaries()
        {
            using (var context = new School())
            {
                Secretary secretary1 = new Secretary(
                    7,
                    "susan_johnson",
                    "pass456",
                    "Susan Johnson",
                    "susan@example.com",
                    2500,
                    "Secretary",
                    "789 Oak St",
                    "555-7890",
                    new DateTime(1985, 12, 31),
                    new DateTime(2030, 12, 31),
                    new DateTime(2026, 12, 31),
                    4,
                    "Administration",
                    true
                );

                Secretary secretary2 = new Secretary(
                    8,
                    "mary_smith",
                    "marypass",
                    "Mary Smith",
                    "mary@example.com",
                    2300,
                    "Secretary",
                    "123 Elm St",
                    "555-2345",
                    new DateTime(1977, 12, 31),
                    new DateTime(2030, 12, 31),
                    new DateTime(2026, 12, 31),
                    6,
                    "HR",
                    true
                );

                Secretary secretary3 = new Secretary(
                    9,
                    "robert_white",
                    "pass789",
                    "Robert White",
                    "robert@example.com",
                    2400,
                    "Secretary",
                    "456 Maple St",
                    "555-5678",
                    new DateTime(1972, 12, 31),
                    new DateTime(2031, 12, 31),
                    new DateTime(2032, 12, 31),
                    5,
                    "Finance",
                    true
                );

                context.Secretaries.Add(secretary1);
                context.Secretaries.Add(secretary2);
                context.Secretaries.Add(secretary3);
                context.SaveChanges();
            }
            
        }
        public static void DefaultTrainings()
        {
            using (var context = new School())
            {
                //Training Sessions
                Training training1 = new Training(
                1,
                "Web Development",
                DateTime.Now.Date,
                DateTime.Now.Date.AddDays(60),
                "Ricardo Sousa"
            );

            Training training2 = new Training(
                2,
                "Web Design",
                DateTime.Now.Date.AddDays(30),
                DateTime.Now.Date.AddDays(50),
                "Ricardo Sousa"
            );

            Training training3 = new Training(
                3,
                "Laravel",
                DateTime.Now.Date.AddDays(90),
                DateTime.Now.Date.AddDays(60),
                "Ricardo Sousa"
            );

            context.TrainingSessions.Add(training1);
            context.TrainingSessions.Add(training2);
            context.TrainingSessions.Add(training3);
            context.SaveChanges();
            }
        }
    }
}
