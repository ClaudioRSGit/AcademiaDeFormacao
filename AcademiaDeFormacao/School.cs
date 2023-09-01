using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace AcademiaDeFormacao
{ 
    internal class School : DbContext
    {
        //Implementar os DBSet
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Secretary> Secretaries { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<Coordinator> Coordinators { get; set; }
        public DbSet<Training> TrainingSessions { get; set; }

    }
}

