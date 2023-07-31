using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiaDeFormacao
{
    internal class Company
    {
        //System Paths
        //Exe location
        public static readonly string RUNTIMEPATH = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Runtime");

        //vai buscar o caminho da pasta principal do programa e acrescenta a pasta Reservados/Id ao caminho
        public static readonly string SETTINGSPATH = Path.Combine(RUNTIMEPATH, "Reservados/Settings");

        //acrescenta o ficheiro ao caminho
        public static readonly string SETTINGSFILE = Path.Combine(SETTINGSPATH, "Settings.csv");

        //Object Lists
        private static List<Secretary> secretaryList = new List<Secretary>();
        private static List<Director> directorList = new List<Director>();
        private static List<Coordinator> coordinatorList = new List<Coordinator>();
        private static List<Trainer> trainerList = new List<Trainer>();

        //Add to list
        public static void AddCoordinator(Coordinator coordinator)
        {
            coordinatorList.Add(coordinator);
        }
        public static void AddTrainer(Trainer trainer)
        {
            trainerList.Add(trainer);
        }
        public static void AddSecretary(Secretary secretary)
        {
            secretaryList.Add(secretary);
        }

        public static void AddDirector(Director director)
        {
            directorList.Add(director);
        }

        //Remove from list
        public static void RemoveSecretaryById(int id)
        {
            var secretaryToRemove = secretaryList.FirstOrDefault(s => s.EmployeeId == id);
            if (secretaryToRemove != null)
            {
                secretaryList.Remove(secretaryToRemove);
            }
        }

        public static void RemoveDirectorById(int id)
        {
            var directorToRemove = directorList.FirstOrDefault(d => d.EmployeeId == id);
            if (directorToRemove != null)
            {
                directorList.Remove(directorToRemove);
            }
        }

        public static void RemoveCoordinatorById(int id)
        {
            var coordinatorToRemove = coordinatorList.FirstOrDefault(c => c.EmployeeId == id);
            if (coordinatorToRemove != null)
            {
                coordinatorList.Remove(coordinatorToRemove);
            }
        }
    }
}
