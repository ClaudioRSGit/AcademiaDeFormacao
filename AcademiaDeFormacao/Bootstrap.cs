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

        static string EncryptPassword(string password, int leap)
        {
            char[] chars = password.ToCharArray();


            for (int i = 0; i < chars.Length; i++)
            {
                if (char.IsLetter(chars[i]))
                {
                    char baseChar = char.IsLower(chars[i]) ? 'a' : 'A';
                    chars[i] = (char)(baseChar + (chars[i] - baseChar + leap) % 26);
                }
            }



            return new string(chars);
        }

        //Trainers
        public static void DefaultTrainers()
        {
            using (var context = new School())
            {
                string EncryptedPassword = EncryptPassword("senha123", 150);

                Trainer trainer1 = new Trainer(
                    1,                          //int employeeId,
                    "ana.silva",                //string username,
                    EncryptedPassword,          //string password,
                    "Ana Silva",                //string name,
                    "ana_silva@email.com",      //string email,
                    0.0,                        //double salary,
                    "Trainer",                  //string role,
                    "Rua dos Formadores, Lisboa",//string address,
                    "+351 912345678",           //string contact,
                    new DateTime(1997, 12, 31), //DateTime dateOfBirth,
                    new DateTime(2027, 12, 31), //DateTime contractEndDate,
                    new DateTime(2027, 6, 30),  //DateTime criminalRecordEndDate,
                    "Computer Science",         //string educationArea,
                    "Full Time",                //string availability,
                    9.5,                        //double timeValue
                    true                        //bool accountStatus
                );
                string EncryptedPassword1 = EncryptPassword("pass123", 150);

                Trainer trainer2 = new Trainer(
                    2,
                    "ricardo.sousa",
                    EncryptedPassword1,
                    "Ricardo Sousa",
                    "ricardo_sousa@email.com",
                    0.0,
                    "Trainer",
                    "Avenida dos Designers, Porto",
                    "+351 919876543",
                    new DateTime(1980, 10, 11),
                    new DateTime(2029, 6, 30),
                    new DateTime(2028, 12, 31),
                    "Web Design and Development",
                    "Half Time",
                    10.0,
                    true
                );
                string EncryptedPassword3 = EncryptPassword("senha123", 150);

                Trainer trainer3 = new Trainer(
                    3,
                    "marta.pereira",
                    EncryptedPassword3,
                    "Marta Pereira",
                    "marta.pereira@email.com",
                    0.0,
                    "Trainer",
                    "Praça do Marketing, Coimbra",
                    "+351 934567890",
                    new DateTime(1994, 02, 20),
                    new DateTime(2031, 9, 30),
                    new DateTime(2030, 8, 31),
                    "Laravel",
                    "Full Time",
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
                string EncryptedPassword = EncryptPassword("pass123", 150);

                Coordinator coordinator1 = new Coordinator(
                   1,
                   "alice.brown",
                   EncryptedPassword,
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
                string EncryptedPassword2 = EncryptPassword("password123", 150);

                Coordinator coordinator2 = new Coordinator(
                    2,
                    "david.lee",
                    EncryptedPassword2,
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
                string EncryptedPassword3 = EncryptPassword("paulpass", 150);

                Coordinator coordinator3 = new Coordinator(
                    3,
                    "paul.garcia",
                    EncryptedPassword3,
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
                string EncryptedPassword = EncryptPassword("pass123", 150);

                Director director1 = new Director(
                   4,
                   "john.doe",
                   EncryptedPassword,
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
                string EncryptedPassword2 = EncryptPassword("Atec123", 150);

                Director director2 = new Director(
                    5,
                    "jane.smith",
                    EncryptedPassword2,
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
                string EncryptedPassword3 = EncryptPassword("pass123", 150);

                Director director3 = new Director(
                    6,
                    "michael.johnson",
                    EncryptedPassword3,
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
                string EncryptedPassword = EncryptPassword("pass123", 150);

                Secretary secretary1 = new Secretary(
                    7,
                    "susan_johnson",
                    EncryptedPassword,
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
                string EncryptedPassword2 = EncryptPassword("google", 150);

                Secretary secretary2 = new Secretary(
                    8,
                    "mary_smith",
                    EncryptedPassword2,
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
                string EncryptedPassword3 = EncryptPassword("SENHA", 150);

                Secretary secretary3 = new Secretary(
                    9,
                    "robert_white",
                    EncryptedPassword3,
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
