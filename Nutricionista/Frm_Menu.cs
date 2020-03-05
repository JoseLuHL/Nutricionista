using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nutricionista
{
    public partial class Frm_Menu : Form
    {
        public Frm_Menu()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {

        }

        private void BtnGestionPaciente_Click(object sender, EventArgs e)
        {
            Frm_Paciente f = new Frm_Paciente();
            f.ShowDialog();
        }

        private void BtnAtencion_Click(object sender, EventArgs e)
        {
            Frm_Pacientes_Pendientes f = new Frm_Pacientes_Pendientes();
            f.ShowDialog();
            //Frm_Atencion f = new Frm_Atencion();
            //f.ShowDialog();
        }
    }
}
