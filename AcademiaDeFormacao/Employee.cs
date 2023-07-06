using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace AcademiaDeFormacao
{
    internal class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public string Contact { get; set; }
        public DateTime DateEndContract { get; set; }
        public DateTime DateCriminalRegistration { get; set; }

        public Employee(int id, string name, string adress, string contact, DateTime endContract, DateTime criminalRecord)
        {
            Id = id;
            Name = name;
            Adress = adress;
            Contact = contact;
            DateEndContract = endContract;
            DateCriminalRegistration = criminalRecord;
        }
        public override string ToString()
         {
            return $"New Employee Created! Id: {Id}";
         }

    }


}
