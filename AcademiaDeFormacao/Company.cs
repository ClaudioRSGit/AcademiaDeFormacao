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
        private static List<Secretary> _secretariaList = new List<Secretary>();
        private static List<Director> _diretorList = new List<Director>();
        private static List<Coordinator> _coordenadorList = new List<Coordinator>();
        private static List<Trainer> _formadorList = new List<Trainer>();
    }
}
