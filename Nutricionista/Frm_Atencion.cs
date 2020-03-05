using MaterialSkin.Controls;
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
using Nutricionista.Conexion;
using Nutricionista.Cargar_Datos;
using Nutricionista.Historia_Clinica;
using Nutricionista.Estados;

namespace Nutricionista
{
    public partial class Frm_Atencion : MaterialForm
    {
        string Identificacion_Paciente;
        public Frm_Atencion(string Identidicacion)
        {
            InitializeComponent();
            this.Identificacion_Paciente = Identidicacion;
        }
        public static int CalcularEdad(DateTime fechaNacimiento)
        {
            // Obtiene la fecha actual:
            DateTime fechaActual = DateTime.Today;


            // Comprueba que la se haya introducido una fecha válida; si
            // la fecha de nacimiento es mayor a la fecha actual se muestra mensaje
            // de advertencia:
            if (fechaNacimiento > fechaActual)
            {
                Console.WriteLine("La fecha de nacimiento es mayor que la actual.");
                return -1;
            }
            else
            {
                int edad = fechaActual.Year - fechaNacimiento.Year;
                // Comprueba que el mes de la fecha de nacimiento es mayor
                // que el mes de la fecha actual:
                if (fechaNacimiento.Month > fechaActual.Month)
                {
                    --edad;
                }
                return edad;
            }
        }
        private async void Frm_Atencion_Load(object sender, EventArgs e)
        {
            //Carga la Historia del paciente
            Cls_Consultar_Historia.Cargar_Historia(Identificacion_Paciente);

            var _Datos_Historia = Cls_Consultar_Historia.Historia_Paciente;
            //MessageBox.Show(_Datos_Historia.Count.ToString());
            //comienzo de asignar los datos del paciente a los respectivos controles
            LblIdentificacion.Text = _Datos_Historia[0].Entr_IdPaciente.Pac_Identificacion;
            LblNombreCompleto.Text = _Datos_Historia[0].Entr_IdPaciente.Pac_Nombre_Completo;
            LblTipoDocumento.Text = _Datos_Historia[0].Entr_IdPaciente.Pac_TipoIdentificacion.TipoIde_Codigo;
            LblGenero.Text = _Datos_Historia[0].Entr_IdPaciente.Pac_CodGenero.Gen_Descripcion;
            LblFechaNacimiento.Text = _Datos_Historia[0].Entr_IdPaciente.Pac_FechaNacimiento.ToShortDateString();
            LblMunicipio.Text = _Datos_Historia[0].Entr_IdPaciente.Pac_CodCiudad.Ciud_Nombre;
            LblEdad.Text = _Datos_Historia[0].Entr_IdPaciente.Pac_Edad;
            if (_Datos_Historia[0].Entr_IdPaciente.Pac_Foto != null)
                // Se utiliza el MemoryStream para extraer la imagen
                this.PctFoto.Image = Image.FromStream(_Datos_Historia[0].Entr_IdPaciente.Pac_Foto);

            //Comienzo de asignacion de los datos correspondientes a la Atencion

            int x = 0;
            if (_Datos_Historia[0].Entr_Numero > 0)
                foreach (Cls_Atencion item in _Datos_Historia)
                {
                    DgvPendientes.Rows.Add(
                        item.Entr_Numero,
                        item.Entr_FechaEntrada.ToShortDateString(),
                        item.Entr_Hora.ToShortTimeString(),
                        item.Ent_MotivoConsulta,
                        item.Ent_CodMedico.Medic_NombreCompleto
                        );
                    if (item.Ent_Estado.EstAten_Codigo==Cls_Estados_Atencion.Atendiendo || item.Ent_Estado.EstAten_Codigo == Cls_Estados_Atencion.cerrada)
                        DgvPendientes.Rows[x].DefaultCellStyle.BackColor = Color.CadetBlue;

                    else
                    {
                        DgvPendientes.Rows[x].DefaultCellStyle.BackColor = Color.White;
                        DgvPendientes.Rows[x].ReadOnly = true;
                    }
                    x++;

                    int y = 0;
                    foreach (Cls_HabitoDetalle item_habito in item.Ent_Habito_Detalle)
                    {
                        DgvHabitos.Rows.Add
                            (
                            item_habito.HabPac_Habito_Codigo.HAB_CODIGO,
                            item_habito.HabPac_Habito_Codigo.HAB_DESCRIPCION,
                            "SI",
                            item_habito.HabPac_Caracteristica,
                            item_habito.HabPac_Frecuencia,
                            item_habito.HabPac_Tiempo,
                            item_habito.HabPac_Observacion
                            );
                        //DgvHabitos.Rows[y].DefaultCellStyle.BackColor = Color.WhiteSmoke;
                        //DgvHabitos.Rows[y].ReadOnly=true;
                        y++;
                    }

                    foreach (Cls_AntecedenteFamiliar item_Ant_Familiar in item.Ent_AntecedenteFamiliar_Detalle)
                    {
                        DgvAntecedenteFamiliar.Rows.Add
                            (
                            item_Ant_Familiar.AntFam_Enfermedad_Codigo.AnteP_Codigo,
                            item_Ant_Familiar.AntFam_Enfermedad_Codigo.AnteP_Descripcion,
                            item_Ant_Familiar.AntFam_Parentesco,
                            item_Ant_Familiar.AntFam_Mortalidad
                            );
                    }
                    //Cargar los antecedentes Pesonales
                    foreach (Cls_AntecedentesPersonales item_Ant_Personales in item.Ent_Antecedentepersonales_Detalle)
                    {
                        DgvAntecedentePersonal.Rows.Add
                            (
                            item_Ant_Personales.AntPer_Antecedende_Codigo.AnteP_Codigo,
                            item_Ant_Personales.AntPer_Antecedende_Codigo.AnteP_Descripcion,
                            item_Ant_Personales.AntPer_Diagnostico,
                            item_Ant_Personales.AntPer_Observacion
                            );
                    }
                    //Cargar el Historial de peso
                    foreach (Cls_Historial_Peso item_Historial_Peso in item.Ent_HistoriaPeso_Detalle)
                    {
                        DgvHistoriaPeso.Rows.Add
                            (
                            item_Historial_Peso.HistPes_EdadSobrepeso,
                            item_Historial_Peso.HistPes_Problema,
                            item_Historial_Peso.HistPes_PesoMaximo,
                            item_Historial_Peso.HistPes_PesoMinimo
                            );
                    }

                    //Cargar antropometria 
                    foreach (Cls_Antropometria item_Antropometria in item.Ent_Antropometria_Detalle)
                    {
                        DgvAntropometria.Rows.Add
                            (
                            item_Antropometria.Antr_Peso,
                            item_Antropometria.Antr_Talla,
                            item_Antropometria.Antr_IMC,
                            item_Antropometria.Antr_PesoIdeal,
                            item_Antropometria.Antr_ExcesoPeso
                            );
                    }
                    //Cargar recorgatorio
                    foreach (Cls_Recordatorio item_Recordatorio in item.Ent_Recordatorio_Detalle)
                    {
                        DgvRecordatorio.Rows.Add
                            (
                            item_Recordatorio.Record_CodComida.Comd_Codigo,
                            item_Recordatorio.Record_CodComida.Comd_Descripcion,
                            item_Recordatorio.Record_Hora,
                            item_Recordatorio.Record_Preparacion,
                            item_Recordatorio.Record_Cantidad);
                    }
                    //Cargar Frecuencia de Consumo
                    foreach (Cls_Frecuencia_Consumo item_FrecuenciaC in item.Ent_FrecuenciaConsumo_Detalle)
                    {
                        DgvFrecuenciaConsumo.Rows.Add
                            (
                            item_FrecuenciaC.FreCon_CodAlimento.Alim_Codigo,
                            item_FrecuenciaC.FreCon_CodAlimento.Alim_Descripcion,
                            item_FrecuenciaC.FreCon_Diario,
                            item_FrecuenciaC.FreCon_Semanal,
                            item_FrecuenciaC.FreCon_Quincenal,
                            item_FrecuenciaC.FreCon_Mensual,
                            item_FrecuenciaC.FreCon_Nunca
                            );
                    }
                    //Cargar Alimentos
                    //foreach (Cls_Alimento item_Alimento in collection)
                    //{

                    //}

                }
            //Cargar los Habitos
            var Cargar_Datos = new Cls_Colecciones_Datos(); //Contiene los metodos para cargar los datos para llenar los DGV
            var _Comidas = await Cargar_Datos.Cargar_Comidas();
            //Consultar y llenar los habitos, antecedentes familiares y personales
            var Habitos_Cargar = await Cargar_Datos.Cargar_Habitos();
            var AntecedentesF = await Cargar_Datos.Cargar_AntecedentesF();
            var AntecedentesP = await Cargar_Datos.Cargar_AntecedentesP();
            var _Alimentos = await Cargar_Datos.Cargar_Alimentos();
            
            //Cargar los habitos al DGV
            foreach (Cls_Habitos item in Habitos_Cargar)
                DgvHabitos.Rows.Add(item.HAB_CODIGO, item.HAB_DESCRIPCION);
            
            //Cargar los Antecedentes Familiares al DGV
            foreach (Cls_AntecedentesFP item in AntecedentesF)
                DgvAntecedenteFamiliar.Rows.Add(item.AnteP_Codigo, item.AnteP_Descripcion);
            
            //Cargar los Antecedentes Personales al DGV
            foreach (Cls_AntecedentesFP item in AntecedentesP)
                DgvAntecedentePersonal.Rows.Add(item.AnteP_Codigo, item.AnteP_Descripcion);

            foreach (Cls_Comida item in _Comidas)
                DgvRecordatorio.Rows.Add(item.Comd_Codigo, item.Comd_Descripcion);

            foreach (Cls_Alimento item in _Alimentos)
                DgvFrecuenciaConsumo.Rows.Add(item.Alim_Codigo, item.Alim_Descripcion);

        }
    }
}
