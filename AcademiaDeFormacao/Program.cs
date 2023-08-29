using AcademiaDeFormacao;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TryProject
{
    internal static class Program
    {

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            using (var context = new School())
            {
                context.Database.Initialize(true);
            }
            /*Bootstrap.DefaultTrainings();
            Bootstrap.DefaultCoordinators();
            Bootstrap.DefaultDirectors();
            Bootstrap.DefaultSecretaries();
            Bootstrap.DefaultTrainers();*/


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
        }
    }
}
