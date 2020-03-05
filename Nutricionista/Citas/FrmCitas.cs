using ApiCitasMedicas.Models;
using MaterialSkin;
using MaterialSkin.Controls;
using Nutricionista.servicio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nutricionista.Citas
{
    public partial class FrmCitas : MaterialForm
    {
        public FrmCitas()
        {
            InitializeComponent();
            MaterialSkinManager m = MaterialSkinManager.Instance;
            m.Theme = MaterialSkinManager.Themes.LIGHT;
            m.ColorScheme = new ColorScheme(Primary.Grey900, Primary.Grey900, Primary.Green700, Accent.Yellow700, TextShade.WHITE);
        }

        List<MedicosEspecialidades> MedicoEspecialidad = new List<MedicosEspecialidades>();
        private async void FrmCitas_Load(object sender, EventArgs e)
        {
            ////CboEspecialidad.DataSource = db.ESPECIALIDADES.ToList();
            ////CboEspecialidad.DisplayMember = "NOMBRE";
            ////CboEspecialidad.ValueMember = "ID";
            //var especialidad = new List<ESPECIALIDADES>();
            //await Task.Run(() => { especialidad = db.ESPECIALIDADES.ToList(); });
            //CboEspecialidad2.DataSource = especialidad;
            //CboEspecialidad2.DisplayMember = "NOMBRE";
            //CboEspecialidad2.ValueMember = "ID";me




            var especialidades = new ApiEspecialidad();
            await especialidades.EspecialidadAsync();
            var error = especialidades.error;
            if (error == "OK")
            {
                var ObjEspecia = especialidades.Especialidad;
                CboEspecialidad2.DataSource = ObjEspecia;
                CboEspecialidad2.DisplayMember = "NOMBRE";
                CboEspecialidad2.ValueMember = "ID";
            }
            else
                MessageBox.Show(error);



        }
        HistoriaClinica_NutricionistaEntities db = new HistoriaClinica_NutricionistaEntities();
        private void txtIdentificacion_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private async void Btn_LupaBuscar_Click(object sender, EventArgs e)
        {
            await GetPaciente();
        }

        private async void txtIdentificacion_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                await GetPaciente();
            }
        }

        async Task GetPaciente()
        {

            txtIdentificacion.Enabled = false;
            if (txtIdentificacion.Text == string.Empty)
            {
                LimpiarControles();
                txtIdentificacion.Enabled = true;
                MessageBox.Show("Ingese un numero de identificación", "Vacio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var identificacionPaciente = txtIdentificacion.Text.Trim();

            var paciente = new ApiPaciente(); //OBJETO DEL SERVICIO  
            var pacientesAsync = await paciente.PacienteAsync(identificacionPaciente); //LLAMADA DEL METODO
            var error = paciente.error; //ERROR DEVUELTO

            if (error == "OK")
            {
                if (paciente == null)
                {
                    LimpiarControles();
                    txtIdentificacion.Enabled = true;
                    MessageBox.Show("No se han encontrado resultados para la identificación", "Vacio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                lblTipoD.Text = pacientesAsync.PacIdentificacion;
                lblNombreCompleto.Text = $"{pacientesAsync.PacNombre1} {pacientesAsync.PacNombre2} {pacientesAsync.PacApellido1} {pacientesAsync.PacApellido2}";
                lblFechaNacimiento.Text = pacientesAsync.PacFechaNacimiento.ToShortDateString();
                lblGenero.Text = pacientesAsync.GenDescripcion;
                LblEdad.Text = edad(pacientesAsync.PacFechaNacimiento);
                
            }
            else
                MessageBox.Show(error);
            txtIdentificacion.Enabled = true;
            txtIdentificacion.Focus();
            txtIdentificacion.SelectAll();


        }
        void LimpiarControles()
        {
            lblTipoD.Text = "";
            lblNombreCompleto.Text = "";
            lblFechaNacimiento.Text = "";
            lblGenero.Text = "";
            LblEdad.Text = "";
        }
        private int EdadPersona(DateTime FechaNacimiento)
        {
            if (FechaNacimiento.Year == DateTime.Today.Year)
                return 0;
            return 1 + EdadPersona(FechaNacimiento.AddYears(1));
        }
        string edad(DateTime fecha)
        {
            //dateTimePicker1.Value: 23/10/1997
            int edad = EdadPersona(fecha);

            if (fecha > DateTime.Today.AddYears(-edad))
                edad -= 1;
            return string.Format("{0} años", edad);
            //MessageBox.Show();
            //Resultado: Tienes 18 años
        }

        private async void CboEspecialidad2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var apiMedicoEspecialidad = new ApiMedicosEspecialidades();
            var especialidad = CboEspecialidad2.SelectedValue.ToString();
            MedicoEspecialidad = new List<MedicosEspecialidades>();
            MedicoEspecialidad = await apiMedicoEspecialidad.MedicoEspecialidadAsync(especialidad);
            var error = apiMedicoEspecialidad.error;
            if (error == "OK")
            {
                CboMedicos.DataSource = MedicoEspecialidad;
                CboMedicos.DisplayMember = "nombreApellido";
                CboMedicos.ValueMember = "Medicoid";
            }
            else
                MessageBox.Show(error);
        }
    }
}
