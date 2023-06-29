using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace AcademiaDeFormacao
{
    internal class Funcionario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Morada { get; set; }
        public string Contacto { get; set; }
        public DateTime DataFimContrato { get; set; }
        public DateTime DataRegistoCriminal { get; set; }

        public Funcionario(int id, string nome, string morada, string contacto, DateTime fimContrato, DateTime registoCriminal)
        {
            Id = id;
            Nome = nome;
            Morada = morada;
            Contacto = contacto;
            DataFimContrato = fimContrato;
            DataRegistoCriminal = registoCriminal;
        }
        public override string ToString()
         {
            return $"Novo Funcionario criado! Id: {Id}";
         }

    }


}
