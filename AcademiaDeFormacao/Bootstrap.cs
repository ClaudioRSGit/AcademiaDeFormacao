using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiaDeFormacao
{
    internal class Bootstrap
    {
        //Trainers
        public static void DefaultFormadores()
        {
            Trainer trainer1 = new Trainer(
            1234,
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

            // Exemplo 2:
            Trainer trainer2 = new Trainer(
                5678,
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

            // Exemplo 3:
            Trainer trainer3 = new Trainer(
                91011,
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
        }

        //Trainings
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
