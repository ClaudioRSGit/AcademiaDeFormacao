using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiaDeFormacao
{
    internal class Bootstrap
    {
        //Trainers
        public static void DefaultTrainers()
        {
                Trainer trainer1 = new Trainer(
                    1,
                    "ana.silva",
                    "senha123",
                    "Ana Silva",
                    "ana_silva@email.com",
                    3000.0,
                    "Instrutor de Programação",
                    "Rua dos Formadores, Lisboa",
                    "+351 912345678",
                    new DateTime(2024, 12, 31),
                    new DateTime(2023, 6, 30),
                    "Ciência da Computação",
                    "Período Integral",
                    50.0
                );

                Trainer trainer2 = new Trainer(
                    2,
                    "ricardo.sousa",
                    "ricardo123",
                    "Ricardo Sousa",
                    "ricardo_sousa@email.com",
                    2500.0,
                    "Instrutor de Web Design",
                    "Avenida dos Designers, Porto",
                    "+351 919876543",
                    new DateTime(2025, 6, 30),
                    new DateTime(2023, 12, 31),
                    "Web Design e Multimédia",
                    "Meio Período",
                    40.0
                );

                Trainer trainer3 = new Trainer(
                    3,
                    "marta.pereira",
                    "marta123",
                    "Marta Pereira",
                    "marta.pereira@email.com",
                    2800.0,
                    "Instrutora de Marketing Digital",
                    "Praça do Marketing, Coimbra",
                    "+351 934567890",
                    new DateTime(2024, 9, 30),
                    new DateTime(2023, 8, 31),
                    "Marketing e Publicidade",
                    "Período Integral",
                    45.0
                );

            //Add to lists
            Company.AddTrainer(trainer1);
            Company.AddTrainer(trainer2);
            Company.AddTrainer(trainer3);
        }

        //Coordinators
        public static void DefaultCoordinators()
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
                    DateTime.Now.Date.AddDays(60),
                    DateTime.Now.Date.AddDays(90)
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
                    DateTime.Now.Date.AddDays(60),
                    DateTime.Now.Date.AddDays(90)
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
                    DateTime.Now.Date.AddDays(60),
                    DateTime.Now.Date.AddDays(90)
                );

            //Add to lists
            Company.AddCoordinator(coordinator1);
            Company.AddCoordinator(coordinator2);
            Company.AddCoordinator(coordinator3);
        }

        //Directors
        public static void DefaultDirectors()
        {
                Director director1 = new Director(
                    1,
                    "john.doe",
                    "password123",
                    "John Doe",
                    "john@example.com",
                    5000,
                    "Director",
                    "456 Oak St",
                    "555-9876",
                    DateTime.Now.Date.AddDays(90),
                    DateTime.Now.Date.AddDays(180),
                    true,
                    1000,
                    true
                );

                Director director2 = new Director(
                    2,
                    "jane.smith",
                    "pass123",
                    "Jane Smith",
                    "jane@example.com",
                    6000,
                    "Director",
                    "789 Maple St",
                    "555-1234",
                    DateTime.Now.Date.AddDays(120),
                    DateTime.Now.Date.AddDays(210),
                    false,
                    1500,
                    false
                );

                Director director3 = new Director(
                    3,
                    "michael.johnson",
                    "mypass",
                    "Michael Johnson",
                    "michael@example.com",
                    5500,
                    "Director",
                    "321 Pine St",
                    "555-5678",
                    DateTime.Now.Date.AddDays(150),
                    DateTime.Now.Date.AddDays(240),
                    true,
                    1200,
                    true
                );

            //Add to lists
            Company.AddDirector(director1);
            Company.AddDirector(director2);
            Company.AddDirector(director3);
        }
        //Secretaries
        public static void DefaultSecretaries()
        {
                Secretary secretary1 = new Secretary(
                    1,
                    "susan_johnson",
                    "pass456",
                    "Susan Johnson",
                    "susan@example.com",
                    2500,
                    "Secretary",
                    "789 Oak St",
                    "555-7890",
                    DateTime.Now.Date.AddDays(90),
                    DateTime.Now.Date.AddDays(180),
                    "Michael Johnson",
                    "Administration"
                );

                Secretary secretary2 = new Secretary(
                    2,
                    "mary_smith",
                    "marypass",
                    "Mary Smith",
                    "mary@example.com",
                    2300,
                    "Secretary",
                    "123 Elm St",
                    "555-2345",
                    DateTime.Now.Date.AddDays(120),
                    DateTime.Now.Date.AddDays(210),
                    "John Doe",        
                    "HR"               
                );

                Secretary secretary3 = new Secretary(
                    3,
                    "robert_white",
                    "pass789",
                    "Robert White",
                    "robert@example.com",
                    2400,
                    "Secretary",
                    "456 Maple St",
                    "555-5678",
                    DateTime.Now.Date.AddDays(150),
                    DateTime.Now.Date.AddDays(240),
                    "Jane Smith",      
                    "Finance"          
                );

            Company.AddSecretary(secretary1);
            Company.AddSecretary(secretary2);
            Company.AddSecretary(secretary3);
        }

        //Training Sessions
        Training training1 = new Training(
        DateTime.Now.Date,
        DateTime.Now.Date.AddDays(60));

        Training training2 = new Training(
        DateTime.Now.Date.AddDays(30),
        DateTime.Now.Date.AddDays(50));

        Training training3 = new Training(
        DateTime.Now.Date.AddDays(90),
        DateTime.Now.Date.AddDays(27));


        //Assign Trainings



       

    }
}
