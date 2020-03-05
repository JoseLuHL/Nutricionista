using MaterialSkin.Controls;
using Nutricionista.Memoria;
using Nutricionista.Tablas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Nutricionista.Cargar_Datos;
using Nutricionista.Historia_Clinica;

namespace Nutricionista
{
    public partial class Frm_Pacientes_Pendientes : MaterialForm
    {
        public Frm_Pacientes_Pendientes()
        {
            InitializeComponent();
        }
        Cls_Colecciones_Datos colecciones_Datos = new Cls_Colecciones_Datos();
        private  void CargarAtencionesPendientes()
        {            
            DgvPendientes.Rows.Clear();
            int x = 0;
            //aqui se van a cargar los pacientes que estan agendados
            foreach (Cls_Atencion item in Cls_AtencionAgregada.Atencion_Cargadas_Pendientes)
            {
                DgvPendientes.Rows.Add(
                    item.Entr_Numero,
                    item.Entr_IdPaciente.Pac_Identificacion,
                    item.Entr_IdPaciente.Pac_Nombre_Completo,
                    item.Entr_FechaEntrada.ToShortDateString(),
                    item.Entr_Hora.ToShortTimeString(),
                    item.Ent_MotivoConsulta,
                    item.Ent_CodMedico.Medic_Identificacion,
                    item.Ent_Estado.EstAten_Codigo
                    );
                DgvPendientes.Rows[x].Cells["DgvPendientesColDocumento"].ReadOnly = true;
                DgvPendientes.Rows[x].DefaultCellStyle.BackColor = Color.WhiteSmoke;
                x++;
            }
        }

        private async void Frm_Pacientes_Pendientes_Load(object sender, EventArgs e)
        {
            var _Medicos = await colecciones_Datos.Cargar_Medico();
            DgvPendientesProfesional.DataSource = _Medicos;
            DgvPendientesProfesional.DisplayMember = "Medic_NombreCompleto";
            DgvPendientesProfesional.ValueMember = "Medic_Identificacion";

            //if (Cls_AtencionAgregada.Atencion_Cargadas_Pendientes.Count <= 0)
            await Cls_AtencionAgregada.CargarAtenciones_Pendientes();
            //MessageBox.Show(Cls_Atenc/*i*/onAgregada.Atencion_Cargadas.Count.ToString());
            CargarAtencionesPendientes();
        }

        private void DgvPendientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show(DgvPendientes.Rows[e.RowIndex].Cells["DgvPendientesColDocumento"].Value.ToString());
            if (MessageBox.Show("¿Esta seguro que sea realizar la atención?","Continuar",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
            {
                //Ingresar codigo de actualizar el estado de la atencion
                //Siempre al abrir una atencion hay que verificar su estado para saber si no esta siendo atendida 
                var _Actualizar_Estado = new Cls_Actualizar_Estado_Atencion();
                int Numero = Convert.ToInt32(DgvPendientes.Rows[e.RowIndex].Cells["DgvPendientesColNumero"].Value.ToString());
                _Actualizar_Estado.Actualizar_estado(Numero);
                Frm_Atencion frm_ = new Frm_Atencion(DgvPendientes.Rows[e.RowIndex].Cells["DgvPendientesColDocumento"].Value.ToString());
                frm_.ShowDialog();
            }            
        }
    }
}
