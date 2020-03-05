using MaterialSkin;
using MaterialSkin.Controls;
using Nutricionista.Cargar_Datos;
using Nutricionista.Conexion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using Nutricionista.Tablas;
using Nutricionista.Insertar;
using Nutricionista.Memoria;
using Nutricionista.Estados;
using Nutricionista.Conversiones;
using Nutricionista.Historia_Clinica;

namespace Nutricionista
{
    public partial class Frm_Paciente : MaterialForm
    {
        public Frm_Paciente()
        {
            InitializeComponent();
            MaterialSkinManager m = MaterialSkinManager.Instance;
            m.Theme = MaterialSkinManager.Themes.LIGHT;
            m.ColorScheme = new ColorScheme(Primary.Grey900, Primary.Grey900, Primary.Green700, Accent.Yellow700, TextShade.WHITE);
        }

        Cls_Colecciones_Datos colecciones_Datos = new Cls_Colecciones_Datos();
        public void Limpiar()
        {
            TxtNombre1.Clear();
            TxtNombre2.Clear();
            TxtApellido1.Clear();
            TxtApellido2.Clear();
            TxtDireccion.Clear();
            TxtTelefono.Clear();
            PctHuella.Image = null;
            PctFoto.Image = null;
            Pt_Firma.Image = null;
            TxtEdad.Text = "";
            DtFechaNacimiento.Value = DateTime.Now.Date;
            ModoEdicion.Visible = false;

        }
        string documentoPaciente = "";
        string Accion = "guardar";
        public async  void BuscarPaciente_(string Documento_)
        {
            Oper_Paciente oper_Paciente = new Oper_Paciente();
            var _paciente =  oper_Paciente.Buscar_Paciente_(TxtDocumento.Text);
            if (_paciente.Pac_TipoIdentificacion == null)
            {
                documentoPaciente = TxtDocumento.Text;
                Accion = "guardar";
                Guardar_o_Modificar = true;
                IndicadorOcupado.Visible = false;
                ModoEdicion.Visible = false;
                Limpiar();
                MessageBox.Show("No se ha encontrado paciente");
                return;
            }
            documentoPaciente = TxtDocumento.Text;
            Accion = "modificar";
            ModoEdicion.Visible = true;
            IdPacienteTra = TxtDocumento.Text;
            Guardar_o_Modificar = false;
            CboTipoDocumento.SelectedValue = _paciente.Pac_TipoIdentificacion.TipoIde_Codigo;
            Cbo_Departamento.SelectedValue = _paciente.Pac_CodDepto.Dept_Codigo;
            //CARGAR COMBO DE CIUDADES
            IndicadorOcupado.Visible = true;
            //MessageBox.Show(Cbo_Departamento.SelectedValue.ToString());
            var _Ciudad = await colecciones_Datos.Cargar_Ciudad(Cbo_Departamento.SelectedValue.ToString());
            Cbo_Municipio.DataSource = _Ciudad;
            Cbo_Municipio.DisplayMember = "Ciud_Nombre";
            Cbo_Municipio.ValueMember = "Ciud_Codigo";
            IndicadorOcupado.Visible = false;
            Cbo_Municipio.SelectedValue = _paciente.Pac_CodCiudad.Ciud_Codigo;
            Cbo_NiverEducativo.SelectedValue = _paciente.Pac_CodNivelEducativo.NivEdu_Codigo;
            Cbo_Profesion.SelectedValue = _paciente.Pac_CodProfesion.Prof_Codigo;
            CboEPS.SelectedValue = _paciente.Pac_CodEPS.Eps_Codigo;
            CboARL.SelectedValue = _paciente.Pac_CodARL.Arl_Codigo;
            numeroDocumentoPaciete = Documento_;
            TxtNombre1.Text = _paciente.Pac_Nombre1;
            TxtNombre2.Text = _paciente.Pac_Nombre2;
            TxtApellido1.Text = _paciente.Pac_Apellido1;
            TxtApellido2.Text = _paciente.Pac_Apellido2;
            DtFechaNacimiento.Text = _paciente.Pac_FechaNacimiento.ToString();
            TxtEdad.Text = CalcularEdad(Convert.ToDateTime(DtFechaNacimiento.Text)).ToString();
            CboGenero.SelectedValue = _paciente.Pac_CodGenero.Gen_Codigo;
            TxtDireccion.Text = _paciente.Pac_Direccion;
            CboTipoSangre.SelectedValue = _paciente.Pac_TipoSangre.TipSan_Codigo;
            CboEstadoCivil.SelectedValue = _paciente.Pac_EstadoCivil.EstCivil_Codigo;
            TxtTelefono.Text = _paciente.Pac_Telefono;
            CboDominancia.SelectedValue = _paciente.Pac_Dominancia_Codigo.Dom_Codigo;
            // El campo productImage primero se almacena en un buffer
            if (_paciente.Pac_Foto != null)
            {
                // Se utiliza el MemoryStream para extraer la imagen
                this.PctFoto.Image = Image.FromStream(_paciente.Pac_Foto);
            }
            if (_paciente.Pac_Huella != null)
            {
                // Se utiliza el MemoryStream para extraer la imagen
                this.PctHuella.Image = Image.FromStream(_paciente.Pac_Huella);
            }
            if (_paciente.Pac_Firma != null)
            {
                // Se utiliza el MemoryStream para extraer la imagen
                this.Pt_Firma.Image = Image.FromStream(_paciente.Pac_Firma);
            }
        }
        DataTable tablaPaciente = new DataTable();
        public void CargarDatosEmpresa()
        {
            SqlConnection conexion = new SqlConnection(CadenaConexion.cadena());
            conexion.Open();
            AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();
            string consulta = @"SELECT [Empr_Codigo] ,[Empre_Nit] as nit ,[Empre_RazonSocial] as nombre FROM [dbo].[Empresa]";
            SqlCommand cmd = new SqlCommand(consulta, conexion);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows == true)
            {
                while (dr.Read())
                {
                    namesCollection.Add(dr["nombre"].ToString());
                    namesCollection.Add(dr["nit"].ToString() + "-" + dr["nombre"].ToString());
                }
            }

            dr.Close();
            conexion.Close();

            TxtApellido1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            TxtApellido1.AutoCompleteSource = AutoCompleteSource.CustomSource;
            TxtApellido1.AutoCompleteCustomSource = namesCollection;
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
        async Task CARGAR_COMBOS()
        {
            try
            {
                //CARGAR COMBO DE TIPO DOCUMENTO
                var _TipoDocumento = await colecciones_Datos.Cargar_TipoDocumento();
                CboTipoDocumento.DataSource = _TipoDocumento;
                CboTipoDocumento.DisplayMember = "TipoIde_Descripcion";
                CboTipoDocumento.ValueMember = "TipoIde_Codigo";

                //CARGAR COMBO DE TIPO GENERO
                var _Genero = await colecciones_Datos.Cargar_Genero();
                CboGenero.DataSource = _Genero;
                CboGenero.DisplayMember = "Gen_Descripcion";
                CboGenero.ValueMember = "Gen_Codigo";

                //CARGAR COMBO DE ESTADO CIVIL
                var _EstadoCivil = await colecciones_Datos.Cargar_EstadoCivil();
                CboEstadoCivil.DataSource = _EstadoCivil;
                CboEstadoCivil.DisplayMember = "EstCivil_Descripcion";
                CboEstadoCivil.ValueMember = "EstCivil_Codigo";

                //CARGAR COMBO DE TIPOS DE SANGRE
                var _TipoSangre = await colecciones_Datos.Cargar_TipoSangre();
                CboTipoSangre.DataSource = _TipoSangre;
                CboTipoSangre.DisplayMember = "TipSan_Descripcion";
                CboTipoSangre.ValueMember = "TipSan_Codigo";

                //CARGAR COMBO DE TIPOS DE DOMINANCIA
                var _Dominancia = await colecciones_Datos.Cargar_Dominancia();
                CboDominancia.DataSource = _Dominancia;
                CboDominancia.DisplayMember = "Dom_Descripcion";
                CboDominancia.ValueMember = "Dom_Codigo";

                ////CARGAR COMBO DE TIPOS DE NIVEL EDUCATIVO
                var _NuvelEducativo = await colecciones_Datos.Cargar_NivelEducativo();
                Cbo_NiverEducativo.DataSource = _NuvelEducativo;
                Cbo_NiverEducativo.DisplayMember = "NivEdu_Descripcion";
                Cbo_NiverEducativo.ValueMember = "NivEdu_Codigo";

                //CARGAR COMBO DE DEPARTAMENTO
                var _Departamento = await colecciones_Datos.Cargar_Departamento();
                Cbo_Departamento.DataSource = _Departamento;
                Cbo_Departamento.DisplayMember = "Dept_Nombre";
                Cbo_Departamento.ValueMember = "Dept_Codigo";

                //CARGAR COMBO DE PRFESIÓN
                var _Profesion = await colecciones_Datos.Cargar_Profesiones();
                Cbo_Profesion.DataSource = _Profesion;
                Cbo_Profesion.DisplayMember = "Prof_Descripcion";
                Cbo_Profesion.ValueMember = "Prof_Codigo";

                //CARGAR COMBO DE TIPOS DE EPS
                var _Eps = await colecciones_Datos.Cargar_Eps();
                CboEPS.DataSource = _Eps;
                CboEPS.DisplayMember = "Eps_Descripcion";
                CboEPS.ValueMember = "Eps_Codigo";

                var _Medicos = await colecciones_Datos.Cargar_Medico();
                DgvPendientesProfesional.DataSource = _Medicos;
                DgvPendientesProfesional.DisplayMember = "Medic_NombreCompleto";
                DgvPendientesProfesional.ValueMember = "Medic_Identificacion";

                //CARGAR COMBO DE TIPOS DE ARL
                var _Arl = await colecciones_Datos.Cargar_Arl();
                CboARL.DataSource = _Arl;
                CboARL.DisplayMember = "Arl_Descripcion";
                CboARL.ValueMember = "Arl_Codigo";
            }
            catch (Exception)
            {
                MessageBox.Show(ClsSqlServer.error);
            }
        }
        private async void Form1_Load(object sender, EventArgs e)
        {
            IndicadorOcupado.Visible = true;
            await CARGAR_COMBOS();
            IndicadorOcupado.Visible = false;
            Limpiar();
            TxtDocumento.Focus();

            //Se cargan las atenciones 
            if (Cls_AtencionAgregada.Atencion_Cargadas_Pendientes.Count <= 0)
               await  Cls_AtencionAgregada.CargarAtenciones_Pendientes();
        }
        private  void BtnGuardar_Click(object sender, EventArgs e)
        {
            //IndicadorOcupado.Visible = true;
            if (TxtDocumento.Text.Trim() == "")
            {
                TxtDocumento.Focus();
                MessageBox.Show("Ingrese un numero de documento");
                return;
            }
            if (TxtNombre1.Text.Trim() == "")
            {
                TxtNombre1.Focus();
                MessageBox.Show("Ingrese el primer nombre del paciente");
                return;
            }
            if (TxtApellido1.Text.Trim() == "")
            {
                TxtApellido1.Focus();
                MessageBox.Show("Ingrese el primer apellido del paciente");
                return;
            }
            if (Cbo_Municipio.SelectedValue == null)
            {
                Cbo_Municipio.Focus();
                MessageBox.Show("Seleccionar un municipio");
                return;
            }
            if (MessageBox.Show("¿Desea " + Accion + " el paciente?", "Continuar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            //se comiensa a guardar los datos del paciente que sera agregado
            var _Paciente = new Cls_Paciente();
            _Paciente.Pac_TipoIdentificacion = new Cls_TipoDocumento { TipoIde_Codigo = CboTipoDocumento.SelectedValue.ToString(), TipoIde_Descripcion = CboTipoDocumento.Text };
            _Paciente.Pac_Identificacion = TxtDocumento.Text;

            _Paciente.Pac_Nombre1 = TxtNombre1.Text;
            _Paciente.Pac_Nombre2 = TxtNombre2.Text;
            _Paciente.Pac_Apellido1 = TxtApellido1.Text;
            _Paciente.Pac_Apellido2 = TxtApellido2.Text;
            _Paciente.Pac_FechaNacimiento = Convert.ToDateTime(DtFechaNacimiento.Value.ToShortDateString());
            _Paciente.Pac_Fecha = Convert.ToDateTime(DtFechaNacimiento.Value.ToShortDateString());
            _Paciente.Pac_CodGenero = new Cls_Genero { Gen_Codigo = CboGenero.SelectedValue.ToString(), Gen_Descripcion = CboGenero.Text };
            _Paciente.Pac_CodDepto = new Cls_Departamento { Dept_Codigo = Cbo_Departamento.SelectedValue.ToString(), Dept_Nombre = Cbo_Departamento.Text };
            _Paciente.Pac_CodCiudad = new Cls_Ciudad { Ciud_Codigo = Cbo_Municipio.SelectedValue.ToString(), Ciud_Nombre = Cbo_Municipio.Text };

            _Paciente.Pac_Direccion = TxtDireccion.Text;
            _Paciente.Pac_CodNivelEducativo = new Cls_NivelEducativo { NivEdu_Codigo = int.Parse(Cbo_NiverEducativo.SelectedValue.ToString()), NivEdu_Descripcion = Cbo_NiverEducativo.Text };
            _Paciente.Pac_CodProfesion = new Cls_Profesion { Prof_Codigo = int.Parse(Cbo_Profesion.SelectedValue.ToString()), Prof_Descripcion = Cbo_Profesion.Text };
            _Paciente.Pac_TipoSangre = new Cls_TipoSangre { TipSan_Codigo = int.Parse(CboTipoSangre.SelectedValue.ToString()), TipSan_Descripcion = CboTipoSangre.Text };
            _Paciente.Pac_EstadoCivil = new Cls_EstadoCivil { EstCivil_Codigo = Convert.ToInt32(CboEstadoCivil.SelectedValue), EstCivil_Descripcion = CboEstadoCivil.Text };

            _Paciente.Pac_Telefono = TxtTelefono.Text;
            _Paciente.Pac_Dominancia_Codigo = new Cls_Dominancia { Dom_Codigo = Convert.ToInt32(CboDominancia.SelectedValue), Dom_Descripcion = CboDominancia.Text };
            _Paciente.Pac_CodEPS = new Cls_Eps { Eps_Codigo = Convert.ToInt32(CboEPS.SelectedValue), Eps_Descripcion = CboEPS.Text };
            _Paciente.Pac_CodARL = new Cls_Arl { Arl_Codigo = Convert.ToInt32(CboARL.SelectedValue), Arl_Descripcion = CboARL.Text };

            string[] fecha = DateTime.Now.ToString().Split(' ');
            _Paciente.Pac_Fecha = DateTime.Now;
            if (PctHuella.Image != null)
            {
                System.IO.MemoryStream ms1 = new System.IO.MemoryStream();
                PctHuella.Image.Save(ms1, System.Drawing.Imaging.ImageFormat.Jpeg);
                _Paciente.Pac_Huella = ms1;
            }
            else
                _Paciente.Pac_Huella = null;
            if (PctFoto.Image != null)
            {
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                PctFoto.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                _Paciente.Pac_Foto = ms;
            }
            else
                _Paciente.Pac_Foto = null;

            if (Pt_Firma.Image != null)
            {
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                Pt_Firma.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                _Paciente.Pac_Firma = ms;
            }

            else
                _Paciente.Pac_Firma = null;
            //Fin

            //Se crea el objeto que contiene los metodos de agregar, actualizar y cargar
            Oper_Paciente oper_Paciente = new Oper_Paciente();

            //Guardar_o_Modificar indica que operacion se va a realizar... True agrega y False actualiza
            if (Guardar_o_Modificar == true)
            {
                //Se agrega el paciente
                oper_Paciente.Insertar_Paciente(_Paciente);
                //Confirmamos que la operacion finalizada correctamente para almacenar el paciente en la lista 
                if (oper_Paciente.error == "Datos guardados")
                    //Se agrega el paciente a la lista
                    Cls_PacienteAgregado.cls_PacienteNuevos.Add(_Paciente);
                else
                    //Si no se finaliza correctamente retornamos al metodo
                    return;
            }
            else
                //Actualiza los datos del paciente si es el caso
                oper_Paciente.Actualizar_Paciente(_Paciente, documentoPaciente);

            //Mostramos el mensaje que nos devuelve la clase
            MessageBox.Show(oper_Paciente.error);

            //Limpiamos los campos
            Limpiar();
            //Se activa el focus de control del documento
            TxtDocumento.Focus();
        }
        //4014489
        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            TxtDocumento.Enabled = true;
            TxtDocumento.Clear();
            Limpiar();
            TxtDocumento.Focus();
            Btn_LupaBuscar.Enabled = true;
            Guardar_o_Modificar = true;
        }
        private void Btn_LupaBuscar_Click(object sender, EventArgs e)
        {
            //Se verifica que no este vacio en control donde se ingresa el documento
            if (TxtDocumento.Text != "")
            {
                //Mostramos el control que infica que la aplicación esta ocupada 
                IndicadorOcupado.Visible = true;
                //Metodo que busca al paciente
                BuscarPaciente_(TxtDocumento.Text);
                //se Oculta el control que infica que la aplicación esta ocupada 
                IndicadorOcupado.Visible = false;
            }
            else
            {
                TxtDocumento.Focus();
                MessageBox.Show("Ingrese un número de documento", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        string IdPacienteTra = "";
        string numeroDocumentoPaciete;
        private void TxtDocumento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (TxtDocumento.Text != "")
                {
                    //Mostramos el control que infica que la aplicación esta ocupada 
                    IndicadorOcupado.Visible = true;
                    //Metodo que busca al paciente
                    BuscarPaciente_(TxtDocumento.Text);
                    //se Oculta el control que infica que la aplicación esta ocupada 
                    IndicadorOcupado.Visible = false;
                }
                else
                {
                    TxtDocumento.Focus();
                    MessageBox.Show("Ingrese un número de documento", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void LblFoto_Click(object sender, EventArgs e)
        {
            // Se crea el OpenFileDialog
            OpenFileDialog dialog = new OpenFileDialog();
            // Se muestra al usuario esperando una acción
            DialogResult result = dialog.ShowDialog();

            // Si seleccionó un archivo (asumiendo que es una imagen lo que seleccionó)
            // la mostramos en el PictureBox de la inferfaz
            if (result == DialogResult.OK)
            {
                this.PctFoto.Image = Image.FromFile(dialog.FileName);
                //MessageBox.Show(System.Drawing.Imaging.ImageFormat.Jpeg.ToString());
                //this.PctFoto.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
        }
        private void LblHuella_Click(object sender, EventArgs e)
        {
            // Se crea el OpenFileDialog
            OpenFileDialog dialog = new OpenFileDialog();
            // Se muestra al usuario esperando una acción
            DialogResult result = dialog.ShowDialog();

            // Si seleccionó un archivo (asumiendo que es una imagen lo que seleccionó)
            // la mostramos en el PictureBox de la inferfaz
            if (result == DialogResult.OK)
            {
                this.PctHuella.Image = Image.FromFile(dialog.FileName);
            }
        }
        private void LblFirma_Click(object sender, EventArgs e)
        {
            // Se crea el OpenFileDialog
            OpenFileDialog dialog = new OpenFileDialog();
            // Se muestra al usuario esperando una acción
            DialogResult result = dialog.ShowDialog();

            // Si seleccionó un archivo (asumiendo que es una imagen lo que seleccionó)
            // la mostramos en el PictureBox de la inferfaz
            if (result == DialogResult.OK)
            {
                this.Pt_Firma.Image = Image.FromFile(dialog.FileName);
            }
        }
        private void BtnLimpiar_Click(object sender, EventArgs e)
        {

        }
        private void BtnLimpFirma_Click(object sender, EventArgs e)
        {
            Pt_Firma.Image = null;
        }
        private void BtnLimpHuella_Click(object sender, EventArgs e)
        {
            PctHuella.Image = null;
        }
        Boolean Guardar_o_Modificar = true; //si es true es para guardar
        private void BtnLimpFoto_Click(object sender, EventArgs e)
        {
            PctFoto.Image = null;
        }
        private void TxtDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            ClsSqlServer.Solo_Numeros(e);
        }
        private void DtFechaNacimiento_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                TxtEdad.Text = CalcularEdad(DtFechaNacimiento.Value).ToString();
            }
            catch (Exception)
            { }
        }
        private async void Cbo_Departamento_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                //CARGAR COMBO DE CIUDADES
                IndicadorOcupado.Visible = true;
                var _Ciudad = await colecciones_Datos.Cargar_Ciudad(Cbo_Departamento.SelectedValue.ToString());
                Cbo_Municipio.DataSource = _Ciudad;
                Cbo_Municipio.DisplayMember = "Ciud_Nombre";
                Cbo_Municipio.ValueMember = "Ciud_Codigo";
                IndicadorOcupado.Visible = false;
            }
            catch (Exception)
            {
                MessageBox.Show(ClsSqlServer.error);
            }
        }
        private void TxtDocumento_TextChanged(object sender, EventArgs e)
        {
            if (TxtDireccion.Text == "")
            {
                if (Guardar_o_Modificar == true)
                {
                    Limpiar();
                    ModoEdicion.Visible = false;
                }
            }
        }
        private void BtnLimpiar_Click_1(object sender, EventArgs e)
        {
            TxtDocumento.Clear();
            Limpiar();
            TxtDocumento.Focus();
        }
        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Se verifica que la pagina selecionada sea la de Datos de la consulta
            if (tabControl1.SelectedTab.Name == "TabDatosConsulta")
            {

                int x = 0; //indica la fila del DGV
                //si no hay paciente agregados recientemente 
                if (Cls_PacienteAgregado.cls_PacienteNuevos.Count <= 0)
                {
                    //Se indica si desea cargar los pacientes agendados
                    DgvPendientes.Rows.Clear();
                    //aqui se van a cargar los pacientes que estan agendados
                    foreach (Cls_Atencion item in Cls_AtencionAgregada.Atencion_Cargadas_Pendientes)
                    {
                        DgvPendientes.Rows.Add(
                            item.Entr_IdPaciente.Pac_Identificacion,
                            item.Entr_IdPaciente.Pac_Nombre_Completo,
                            item.Entr_FechaEntrada.ToShortDateString(),
                            item.Entr_Hora.ToShortTimeString(),
                            item.Ent_MotivoConsulta,
                            item.Ent_CodMedico.Medic_Identificacion
                            );
                        DgvPendientes.Rows[x].Cells["DgvPendientesColDocumento"].ReadOnly = true;
                        DgvPendientes.Rows[x].DefaultCellStyle.BackColor = Color.WhiteSmoke;
                        x++;
                    }
                    BtnGuardar_Pendi.Enabled = false;
                    return;
                }

                BtnGuardar_Pendi.Enabled = true;

                DgvPendientes.Rows.Clear();
                x = 0;
                string fecha = DateTime.Now.Date.ToShortDateString();
                string hora = DateTime.Now.Date.ToShortTimeString();
                //Agregamos al dgv los pacientes que se agregaron recientemente
                foreach (Cls_Paciente item in Cls_PacienteAgregado.cls_PacienteNuevos)
                {
                    DgvPendientes.Rows.Add(item.Pac_Identificacion, item.Pac_Apellido1, fecha, hora);
                    DgvPendientes.Rows[x].Cells["DgvPendientesColDocumento"].ReadOnly = true;
                    x++;
                }
            }
        }
        private async void BtnGuardar_Pendi_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea continuar?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            //int x = 0;
            //Se hace el recorrido del DGV
            foreach (DataGridViewRow item in DgvPendientes.Rows)
            {
                //Obtenemos los valores de las filas que son no estan de color WhiteSmoke ya que estan son las que contienen la información del paciente que se le va a realizar la atención 
                if (item.DefaultCellStyle.BackColor != Color.WhiteSmoke)
                {
                    string Identificacion = Cls_Convertir.Convertir_Null_String(item.Cells["DgvPendientesColDocumento"]);
                    string motivo = Cls_Convertir.Convertir_Null_String(item.Cells["DgvPendientesMotivo"]);
                    string profesional = Cls_Convertir.Convertir_Null_String(item.Cells["DgvPendientesProfesional"]);
                    string fechaentrada = (Cls_Convertir.Convertir_Null_String(item.Cells["DgvPendientesFecha"]));
                    string Medico = Cls_Convertir.Convertir_Null_String(item.Cells["DgvPendientesProfesional"]);
                    string Hora = Cls_Convertir.Convertir_Null_String(item.Cells["DgvPendientesHora"]);
                    string nombre = Cls_Convertir.Convertir_Null_String(item.Cells["DgvPendientesNombrecompleto"]);
                    int Eps = Convert.ToInt32(CboEPS.SelectedValue);
                    int Arl = Convert.ToInt32(CboARL.SelectedValue);

                    if (Identificacion != "" && motivo != "" && Medico != "" && nombre != "")
                    {
                        //MessageBox.Show(fechaentrada);
                        //Se cambia la fila de color
                        item.DefaultCellStyle.BackColor = Color.WhiteSmoke;
                        //Agregamos el paciente a nuela coleccion generica 
                        Cls_AtencionAgregada.Cls_Atencions.Add(new Cls_Atencion
                        {
                            Entr_Numero = 23,
                            Ent_MotivoConsulta = motivo,
                            Entr_FechaEntrada = Convert.ToDateTime(fechaentrada),
                            Ent_Estado = new Cls_Estados_Atencion2 {EstAten_Codigo = Cls_Estados_Atencion.Pendiente },
                            Entr_Hora = Convert.ToDateTime(Hora),
                            Entr_Diagnostico = "",
                            Entr_Concepto_Codigo = 0,
                            Entr_Recomendacion = "",
                            Entr_Reubicacion = 1,
                            Entr_TipoExamenCodigo = "",
                            Ent_CodARL = new Cls_Arl { Arl_Codigo = Eps, Arl_Descripcion = "" },
                            Ent_CodEPS = new Cls_Eps { Eps_Codigo = Arl, Eps_Descripcion = "" },
                            Ent_conceptoAptitud = "",
                            Ent_Enfasis = 0,
                            Ent_CodMedico = new Cls_Medico { Medic_Identificacion = Medico },
                            Entr_IdPaciente = new Cls_Paciente { Pac_Identificacion = Identificacion }  //Cls_PacienteAgregado.cls_PacienteNuevos[x]
                        });
                    }
                }
            }

            //Confirmamos que la coleccion tenga pacientes agregados
            if (Cls_AtencionAgregada.Cls_Atencions.Count > 0)
            {
                //Instanciamos la clase que contiene nuestro metodo de insertar paciente
                var _Insertar_PacientePendiente = new Cls_Insertar_Paiente_Pendiente();
                //llamamos al metodo y le enviamos el parametro que contiene los pacientes
                _Insertar_PacientePendiente.Insertar_PacientesPendientes(Cls_AtencionAgregada.Cls_Atencions);
                //Limpiamos los pacientes que fueron agregados recientemente
                Cls_PacienteAgregado.cls_PacienteNuevos.Clear();
                //Mostramos el mensaje devuelto
                MessageBox.Show(_Insertar_PacientePendiente.error);
                //Cargamos la colección de pacientes por atender
                 await Cls_AtencionAgregada.CargarAtenciones_Pendientes();
            }
        }
        private void Frm_Paciente_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Cls_PacienteAgregado.cls_PacienteNuevos.Count > 0)
                if (MessageBox.Show("No se han agendado los pacientes agregados ¿Desea salir?", "Continuar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    e.Cancel = true;
        }
        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            string fecha = DateTime.Now.Date.ToShortDateString();
            string hora = DateTime.Now.ToShortTimeString();
            DgvPendientes.Rows.Add();
            DgvPendientes.Rows[DgvPendientes.Rows.Count - 1].Cells["DgvPendientesColDocumento"].ReadOnly = false;
            DgvPendientes.Rows[DgvPendientes.Rows.Count - 1].Cells["DgvPendientesFecha"].Value = fecha;
            DgvPendientes.Rows[DgvPendientes.Rows.Count - 1].Cells["DgvPendientesHora"].Value = hora;
            BtnGuardar_Pendi.Enabled = true;
        }

        private void DgvPendientes_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (DgvPendientes.CurrentCell.ColumnIndex == DgvPendientesColDocumento.Index)
            {
                DataGridViewTextBoxEditingControl dText = (DataGridViewTextBoxEditingControl)e.Control;
                dText.KeyUp -= new KeyEventHandler(text_KeyUp);
                dText.KeyUp += new KeyEventHandler(text_KeyUp);
            }
        }

        void  text_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (DgvPendientes.CurrentCell.ColumnIndex == DgvPendientesColDocumento.Index)
                {
                    Oper_Paciente _Paciente = new Oper_Paciente();
                    var _pacienteD = new Cls_Paciente();
                    _pacienteD = _Paciente.Buscar_Paciente_(Cls_Convertir.Convertir_Null_String(DgvPendientes.Rows[DgvPendientes.CurrentRow.Index].Cells["DgvPendientesColDocumento"]));
                    if (_pacienteD.Pac_Identificacion != null)
                    {
                        DgvPendientes.Rows[DgvPendientes.CurrentRow.Index].Cells["DgvPendientesNombrecompleto"].Value = _pacienteD.Pac_Nombre_Completo;
                        DgvPendientes.CurrentCell = DgvPendientes.Rows[DgvPendientes.CurrentRow.Index].Cells["DgvPendientesMotivo"];
                    }
                    else
                    {
                        MessageBox.Show("Sin resultados");
                        DgvPendientes.CurrentCell = DgvPendientes.Rows[DgvPendientes.CurrentRow.Index].Cells["DgvPendientesColDocumento"];
                    }
                }
            }
        }
    }
}
