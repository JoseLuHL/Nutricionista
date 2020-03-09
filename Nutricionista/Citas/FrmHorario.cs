using ApiCitasMedicas.Models;
using MaterialSkin;
using MaterialSkin.Controls;
using Nutricionista.Operaciones_Comun;
using Nutricionista.servicio;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nutricionista.Citas
{
    public partial class FrmHorario : MaterialForm
    {
        public FrmHorario()
        {
            InitializeComponent();
            MaterialSkinManager m = MaterialSkinManager.Instance;
            m.Theme = MaterialSkinManager.Themes.LIGHT;
            m.ColorScheme = new ColorScheme(Primary.Grey900, Primary.Grey900, Primary.Green700, Accent.Yellow700, TextShade.WHITE);
        }

        private async void FrmHorario_Load(object sender, EventArgs e)
        {
            txtMedico.Focus();
        }

        private void txtMedico_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {

        }

        private async void txtMedico_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var dni = txtMedico.Text;
                await MedicosAsync(dni);
            }
        }

        private async void Btn_LupaBuscar_Click(object sender, EventArgs e)
        {
            var dni = txtMedico.Text;
            await MedicosAsync(dni);
        }

        int medicoID;
        public async Task MedicosAsync(string dni)
        {
            if (string.IsNullOrEmpty(dni))
            {
                MessageBox.Show("Ingresar una identificación para continuar.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMedico.Focus();
                return;
            }

            IndicadorOcupado.Visible = true;
            DgvHorario.Rows.Clear();
            var apiHorario = new ApiHorario();
            var horarioMedico = await apiHorario.GetHorario(dni);
            var error = apiHorario.error;
            if (error == "OK")
            {
                var x = 0;
                LblNombre.Text = horarioMedico[0].Medico.Nombres + " " + horarioMedico[0].Medico.Apellidos;
                medicoID = horarioMedico[0].Medico.Id;
                foreach (Horarios item in horarioMedico)
                {
                    DgvHorario.Rows.Add(item.Id, item.Fechaatencion, item.Inicioatencion, item.Finatencion, item.Nota, item.Activo);
                    DgvHorario.Rows[x].ReadOnly = true;
                    //DgvHorario.Rows[x].DefaultCellStyle. = true;
                    x++;
                }
            }
            else
            {
                var apiMedico = new ApiMedico();
                var medico = await apiMedico.MedicosAsync(dni);
                var error2 = apiMedico.error;
                if (error2 == "OK")
                {
                    LblNombre.Text = medico.Nombres + " " + medico.Apellidos;
                    medicoID = medico.Id;
                }
                else
                {
                    IndicadorOcupado.Visible = false;
                    LblNombre.Text = "";
                    DgvHorario.Rows.Clear();
                    medicoID = 0;
                    MessageBox.Show(Mensajes.MensajeAlerta + "\n" + error);
                }
            }
            IndicadorOcupado.Visible = false;
            txtMedico.Focus();
            txtMedico.SelectAll();
        }

        int filamore = 0;
        private void BtnNuevaFila_Click(object sender, EventArgs e)
        {
            DgvHorario.Rows.Add(null, DateTime.Now.Date.AddDays(filamore), "8:00 a. m.", "04:00 a. m.", null, true);
            filamore++;
        }

        private void BtnEliminarFila_Click(object sender, EventArgs e)
        {
            if (DgvHorario.Rows.Count > 0)
            {
                if (DgvHorario.Rows[DgvHorario.Rows.Count - 1].Cells["DgvHorarioid"].Value == null)
                {
                    filamore--;
                    DgvHorario.Rows.RemoveAt(DgvHorario.Rows.Count - 1);

                }
                else
                    MessageBox.Show("La fila no se puede eliminar", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (medicoID <= 0)
            {
                MessageBox.Show("Se requiere que busque un medico para continuar", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (DgvHorario.Rows.Count <= 0)
            {
                MessageBox.Show("Se requiere que agregue una fecha continuar", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("¿Desea continuar?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }


            BtnGuardar.Focus();
            DgvHorario.CancelEdit();
            DgvHorario.ClearSelection();
            int fila = 0;
            var horariosPOST = new List<Horarios>();
            var horariosPUT = new List<Horarios>();

            
            






            foreach (DataGridViewRow item in DgvHorario.Rows)
            {
                

                if (string.IsNullOrEmpty(item.Cells["DgvHorariofecha"].Value.ToString()))
                {
                    DgvHorario.Rows[fila].Cells["DgvHorariofecha"].Style.BackColor = Color.Red;
                    MessageBox.Show("Ha dejado la fehca de la fila " + (fila + 1) + " vacia");
                    return;
                }

                if (item.Cells["DgvHorarioHorainicio"].Value == null || string.IsNullOrEmpty(item.Cells["DgvHorarioHorainicio"].Value.ToString()))
                {
                    DgvHorario.Rows[fila].Cells["DgvHorarioHorainicio"].Style.BackColor = Color.Red;
                    MessageBox.Show("Ha dejado la hora de inicio de la fila " + (fila + 1) + " vacia");
                    return;
                }

                if (string.IsNullOrEmpty(item.Cells["DgvHorarioHorafinal"].Value.ToString()))
                {
                    DgvHorario.Rows[fila].Cells["DgvHorarioHorafinal"].Style.BackColor = Color.Red;
                    MessageBox.Show("Ha dejado la hora final de la fila " + (fila + 1) + " vacia");
                    return;
                }

                

                var horaInicio = item.Cells["DgvHorarioHorainicio"].Value.ToString();
                var horaFinal = item.Cells["DgvHorarioHorafinal"].Value.ToString();
                var fechaHorario = item.Cells["DgvHorariofecha"].Value.ToString();
                var activo = Convert.ToBoolean(item.Cells["DgvHorarioActivar"].Value.ToString());
                var nota = item.Cells["DgvHorarioNota"].Value != null ? item.Cells["DgvHorarioNota"].Value.ToString() : null;
                var id = item.Cells["DgvHorarioid"].Value != null ? int.Parse(item.Cells["DgvHorarioid"].Value.ToString()) : 0;

                //Validar fechas
                if (Convert.ToDateTime(item.Cells["DgvHorariofecha"].Value.ToString()).Date < DateTime.Now.Date && id<=0)
                {
                    DgvHorario.Rows[fila].Cells["DgvHorariofecha"].Style.BackColor = Color.Red;
                    MessageBox.Show("La fehca de la fila " + (fila + 1) + " no puede ser menor a la fecha actual");
                    return;
                }


                if (!ValidarHora(horaInicio))
                {
                    DgvHorario.Rows[fila].Cells["DgvHorarioHorainicio"].Style.BackColor = Color.Red;
                    MessageBox.Show("La hora de inicio (" + horaInicio + ") de la fila " + (fila + 1) + "\nNo contiene el formato correcto" + "\nFormato: {12:00 a. m.}");
                    return;
                }
                if (!ValidarHora(horaFinal))
                {
                    DgvHorario.Rows[fila].Cells["DgvHorarioHorainicio"].Style.BackColor = Color.Red;
                    MessageBox.Show("La hora final (" + horaFinal + ") de la fila " + (fila + 1) + "\nNo contiene el formato correcto" + "\nFormato: {12:00 a. m.}");
                    return;
                }

                if (id <= 0)
                {

                    horariosPOST.Add(
                    new Horarios
                    {
                        Medicoid = medicoID,
                        Fechaatencion = Convert.ToDateTime(fechaHorario).Date.Date,
                        Inicioatencion = horaInicio,
                        Finatencion = horaFinal,
                        Nota = nota,
                        Fecharegistro = DateTime.Now.Date.Date,
                        Activo = Convert.ToBoolean(activo)
                    });
                }
                else
                {
                    if (item.DefaultCellStyle.BackColor==Color.WhiteSmoke)
                    {
                        horariosPUT.Add(
                    new Horarios
                    {
                        Id = id,
                        Medicoid = medicoID,
                        Fechaatencion = Convert.ToDateTime(fechaHorario).Date.Date,
                        Inicioatencion = horaInicio,
                        Finatencion = horaFinal,
                        Nota = nota,
                        Fecharegistro = DateTime.Now.Date.Date,
                        Activo = Convert.ToBoolean(activo)
                    });
                    }                    
                }

                fila++;
            }
            var apiHorario = new ApiHorario();
            if (horariosPOST.Count > 0)
            {
                var respuestaPOST = await apiHorario.PostHorario(horariosPOST);
                if (!respuestaPOST.Estado)
                {
                    MessageBox.Show($"{respuestaPOST.Mensaje} {respuestaPOST.Estado}");
                }
            }
            if (horariosPUT.Count > 0)
            {
                var respuestaPUT = await apiHorario.PutHorario(horariosPUT);
                if (!respuestaPUT.Estado)
                {
                    MessageBox.Show($"{respuestaPUT.Mensaje} {respuestaPUT.Estado}");
                }
            }
            var error = apiHorario.error;

            MessageBox.Show("Datos insertados correctamente.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public bool ValidarHora(string hora)
        {
            bool res = false;
            try
            {
                var horaC = Convert.ToDateTime(hora).ToShortTimeString();
                res = true;
            }
            catch (Exception)
            {
                res = false;
            }
            return res;
        }

        private void DgvHorario_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DgvHorario.Rows[e.RowIndex].ReadOnly==true)
            {
                DgvHorario.Rows[e.RowIndex].ReadOnly = false;
                DgvHorario.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.WhiteSmoke;
            }
            else
            {
                DgvHorario.Rows[e.RowIndex].ReadOnly = true;
                DgvHorario.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
            }
        }
    }
}
