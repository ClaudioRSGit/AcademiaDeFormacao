using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AcademiaDeFormacao.UserControls
{
    public partial class SecretaryShowDirector : UserControl
    {
        public int SelectedDirectorId { get; private set; }

        public SecretaryShowDirector()
        {
            InitializeComponent();
            LoadDirectors();
        }

        private void LoadDirectors()
        {
            using (var context = new School())
            {
                List<Director> directors = context.Directors.ToList();

                foreach (Director director in directors)
                {
                    list_Directors.Items.Add(director.Name);
                }
            }
        }

        private void list_Directors_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (list_Directors.SelectedIndex != -1)
            {
                using (var context = new School())
                {
                    var selectedDirector = context.Directors.FirstOrDefault(d => d.Name == list_Directors.SelectedItem.ToString());
                    if (selectedDirector != null)
                    {
                        this.SelectedDirectorId = selectedDirector.EmployeeId;
                    }
                }
            }
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            this.Hide();

        }
    }
}
