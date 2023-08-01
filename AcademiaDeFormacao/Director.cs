using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiaDeFormacao
{
    internal class Director : Employee
    {
        //Director's csv folder path
        public static readonly string DIRECTORSPATH = Path.Combine(School.RUNTIMEPATH, "CSV/Diretor");
        //add the director's csv file
        public static readonly string DIRECTORSFILE = Path.Combine(DIRECTORSFILE, "Diretor.csv");
        public bool TimeExemption { get; set; }
        public double MonthlyBonus { get; set; }
        public bool CompanyCar { get; set; }

        public Director(
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
            DateTime criminalRecordEndDate,
            bool timeExemption,
            double monthlyBonus,
            bool companyCar) : base(employeeId, username, password, name, email, salary, role, address, contact, contractEndDate, contractEndDate)
        {
            TimeExemption = timeExemption;
            MonthlyBonus = monthlyBonus;
            CompanyCar = companyCar;
        }



        /*public static List<string> SaveDiretorToFile()
        {
            List<string> lines = new List<string>();

            Directory.CreateDirectory(DIRETORESPATH);
            using (var sw = new StreamWriter(DIRETORESFILE, false, Encoding.UTF8))
            {
                //Salva para lista global
                lines.Add("DIRETORES:");
                lines.Add("");

                sw.WriteLine("QUALQUER EDIÇÃO DE CONTEUDO DESTE FICHEIRO IRÁ DANIFICAR IRRECUPERAVÉLMENTE A BD");
                foreach (var diretor in Empresa.GetDiretorList())
                {
                    //Salva para lista global
                    lines.Add($"- {diretor.EmployeeId}, {diretor.Nome}, {diretor.Morada}, {diretor.Contacto}, {diretor.DataFimContrato.ToString("yyyy/MM/dd")}, {diretor.DataRegistoCriminal.ToString("yyyy/MM/dd")}, {diretor.Salario},{diretor.Cargo}, {diretor.IsencaoHorario}, {diretor.BonusMensal}, {diretor.CarroEmpresa};");

                    //Salva diretor
                    sw.WriteLine($"{diretor.EmployeeId},{diretor.Nome},{diretor.Morada},{diretor.Contacto},{diretor.DataFimContrato.ToString("yyyy/MM/dd")},{diretor.DataRegistoCriminal.ToString("yyyy/MM/dd")},{diretor.Salario},{diretor.Cargo},{diretor.IsencaoHorario},{diretor.BonusMensal},{diretor.CarroEmpresa}");
                }
                lines.Add("");
            }
            lines.Add("-----------------------------------------------------------------");
            return lines;
        }*/
    }
}
