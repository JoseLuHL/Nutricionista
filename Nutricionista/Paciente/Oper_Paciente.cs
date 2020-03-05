using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Nutricionista.Conexion;
using Nutricionista.Tablas;

namespace Nutricionista.Insertar
{
    public class Oper_Paciente
    {
        //Aqui se encuentra lo relacionado co ingresar, actualizar y buscar un paciente en el sistema
        public string error { get; set; }
        public void Insertar_Paciente(Cls_Paciente _Paciente)
        {
            //Establecemos el Objeto que nos va a permitir conectarnos a la base de Datos()
            SqlConnection cnn = new SqlConnection(CadenaConexion.cadena());
            //Abrimos la conexión()
            cnn.Open();
            //Comenzamos la transacción ()
            SqlTransaction SQLtrans = cnn.BeginTransaction();
            try
            {
                SqlCommand comman = cnn.CreateCommand();
                comman.Transaction = SQLtrans;
                string SQL = "INSERT INTO [dbo].[Paciente] " +
                                      "([Pac_TipoIdentificacion] " +
                                      ",[Pac_Identificacion]     " +
                                      ",[Pac_Nombre1]            " +
                                      ",[Pac_Nombre2]            " +
                                      ",[Pac_Apellido1]          " +
                                      ",[Pac_Apellido2]          " +
                                      ",[Pac_FechaNacimiento]    " +
                                      ",[Pac_CodGenero]      " +
                                      ",Pac_CodDepto " +
                                      ",Pac_CodCiudad " +
                                      ",[Pac_Direccion]          " +
                                      ",[Pac_CodNivelEducativo]     " +
                                      ",[Pac_CodProfesion]   " +
                                      ",[Pac_TipoSangre]         " +
                                      ",[Pac_EstadoCivil]        " +
                                      ",Pac_Telefono,Pac_Foto,Pac_Huella,Pac_Firma,Pac_Dominancia_Codigo,Pac_Fecha,Pac_CodEPS,          Pac_CodARL) " +
                                " VALUES (@TipoI,@ide,@n1,@n2,@a1,@a2,@fecha,@genero,@CodDepartamento,@CodCiudad,@dire,@nivel,@pro,@tipos,@estado,@tel,@foto1,@foto2,@firma,@dominancia,@fechaIngreso, @EPS, @ARL)";
                //  Pac_CodEPS = @EPS, Pac_CodARL = @ARL
                comman.CommandText = SQL;
                comman.Parameters.Add("@TipoI", SqlDbType.NVarChar);
                comman.Parameters.Add("@ide", SqlDbType.NVarChar);
                comman.Parameters.Add("@n1", SqlDbType.NVarChar);
                comman.Parameters.Add("@n2", SqlDbType.NVarChar);
                comman.Parameters.Add("@a1", SqlDbType.NVarChar);
                comman.Parameters.Add("@a2", SqlDbType.NVarChar);
                comman.Parameters.Add("@fecha", SqlDbType.Date);
                comman.Parameters.Add("@genero", SqlDbType.NVarChar);
                comman.Parameters.Add("@CodDepartamento", SqlDbType.NVarChar);
                comman.Parameters.Add("@CodCiudad", SqlDbType.NVarChar);
                comman.Parameters.Add("@dire", SqlDbType.NVarChar);
                comman.Parameters.Add("@nivel", SqlDbType.Int);
                comman.Parameters.Add("@pro", SqlDbType.NVarChar);
                comman.Parameters.Add("@tipos", SqlDbType.Int);
                comman.Parameters.Add("@estado", SqlDbType.Int);

                comman.Parameters.Add("@EPS", SqlDbType.Int);
                comman.Parameters.Add("@ARL", SqlDbType.Int);

                comman.Parameters.Add("@tel", SqlDbType.NVarChar);
                comman.Parameters.Add("@foto1", SqlDbType.Image);
                comman.Parameters.Add("@foto2", SqlDbType.Image);
                comman.Parameters.Add("@firma", SqlDbType.Image);
                comman.Parameters.Add("@dominancia", SqlDbType.Int);
                comman.Parameters.Add("@fechaIngreso", SqlDbType.Date);

                comman.Parameters["@TipoI"].Value = _Paciente.Pac_TipoIdentificacion.TipoIde_Codigo;
                comman.Parameters["@ide"].Value = _Paciente.Pac_Identificacion;
                comman.Parameters["@n1"].Value = _Paciente.Pac_Nombre1;
                comman.Parameters["@n2"].Value = _Paciente.Pac_Nombre2;
                comman.Parameters["@a1"].Value = _Paciente.Pac_Apellido1;
                comman.Parameters["@a2"].Value = _Paciente.Pac_Apellido2;

                //MessageBox.Show(_Paciente.Pac_FechaNacimiento.ToShortDateString());
                comman.Parameters["@fecha"].Value = _Paciente.Pac_FechaNacimiento.ToShortDateString();
                comman.Parameters["@genero"].Value = _Paciente.Pac_CodGenero.Gen_Codigo;
                comman.Parameters["@CodDepartamento"].Value = _Paciente.Pac_CodDepto.Dept_Codigo;
                comman.Parameters["@CodCiudad"].Value = _Paciente.Pac_CodCiudad.Ciud_Codigo;
                //comman.Parameters["@lugar"].Value = TxtLugarNacimiento.Text;
                comman.Parameters["@dire"].Value = _Paciente.Pac_Direccion;
                comman.Parameters["@nivel"].Value = _Paciente.Pac_CodNivelEducativo.NivEdu_Codigo;
                comman.Parameters["@pro"].Value = _Paciente.Pac_CodProfesion.Prof_Codigo;
                comman.Parameters["@tipos"].Value = _Paciente.Pac_TipoSangre.TipSan_Codigo;
                comman.Parameters["@estado"].Value = _Paciente.Pac_EstadoCivil.EstCivil_Codigo;
                comman.Parameters["@tel"].Value = _Paciente.Pac_Telefono;
                comman.Parameters["@dominancia"].Value = _Paciente.Pac_Dominancia_Codigo.Dom_Codigo;

                comman.Parameters["@EPS"].Value = _Paciente.Pac_CodEPS.Eps_Codigo;
                comman.Parameters["@ARL"].Value = _Paciente.Pac_CodARL.Arl_Codigo;

                string fecha = DateTime.Now.Date.ToShortDateString();
                //MessageBox.Show(DateTime.Now.Date.ToShortDateString());
                comman.Parameters["@fechaIngreso"].Value = fecha;
                if (_Paciente.Pac_Huella != null)
                {
                    comman.Parameters["@foto2"].Value = _Paciente.Pac_Huella.GetBuffer();
                }
                else
                    comman.Parameters["@foto2"].Value = DBNull.Value;
                if (_Paciente.Pac_Foto != null)
                {
                    comman.Parameters["@foto1"].Value = _Paciente.Pac_Foto.GetBuffer();
                }
                else
                    comman.Parameters["@foto1"].Value = DBNull.Value;

                if (_Paciente.Pac_Foto != null)
                {
                    comman.Parameters["@firma"].Value = _Paciente.Pac_Foto.GetBuffer();
                }

                else
                    comman.Parameters["@firma"].Value = DBNull.Value;

                comman.ExecuteNonQuery();
                SQLtrans.Commit();
                error = "Datos guardados";
            }
            catch (Exception ex)
            {
                error = ex.Message;
                try
                { SQLtrans.Rollback(); }
                catch (Exception)
                {
                }
            }
        }
        public void Actualizar_Paciente(Cls_Paciente _Paciente, string identificacion)
        {
            SqlConnection cnn = new SqlConnection(CadenaConexion.cadena());
            cnn.Open();
            SqlTransaction SQLtrans = cnn.BeginTransaction();
            try
            {
                //Guardar_o_Modificar = false;
                SqlCommand comman = cnn.CreateCommand();
                comman.Transaction = SQLtrans;
                string Query = "UPDATE [dbo].[Paciente] " +
                    "SET [Pac_Identificacion]= @identi, [Pac_TipoIdentificacion] = @TipoI" +
                    ",[Pac_Nombre1] = @n1" +
                    ",[Pac_Nombre2] = @n2" +
                    ",[Pac_Apellido1] = @a1" +
                    ",[Pac_Apellido2] = @a2" +
                    ",[Pac_FechaNacimiento] = @fecha" +
                    ",[Pac_CodGenero] =   @genero" +
                    ",Pac_CodDepto = @CodDepartamento " +
                    ",Pac_CodCiudad = @CodCiudad " +
                    ",[Pac_Direccion] = @dire" +
                    ",[Pac_CodNivelEducativo] = @nivel" +
                    ",[Pac_CodProfesion] = @pro" +
                    ",[Pac_TipoSangre] = @tipos" +
                    ",[Pac_EstadoCivil] = @estado" +
                    ",[Pac_Telefono] = @tel, Pac_Foto=@foto1, Pac_Huella=@foto2, " +
                    " Pac_Firma=@firma, Pac_Dominancia_Codigo=@dominancia, Pac_CodEPS=@EPS, Pac_CodARL=@ARL " +
                    " WHERE [Pac_Identificacion]= @ide";

                comman.CommandText = Query;
                comman.Parameters.Add("@TipoI", SqlDbType.NVarChar);
                comman.Parameters.Add("@ide", SqlDbType.NVarChar);
                comman.Parameters.Add("@identi", SqlDbType.NVarChar);
                comman.Parameters.Add("@n1", SqlDbType.NVarChar);
                comman.Parameters.Add("@n2", SqlDbType.NVarChar);
                comman.Parameters.Add("@a1", SqlDbType.NVarChar);
                comman.Parameters.Add("@a2", SqlDbType.NVarChar);
                comman.Parameters.Add("@fecha", SqlDbType.Date);
                comman.Parameters.Add("@genero", SqlDbType.NVarChar);
                comman.Parameters.Add("@CodDepartamento", SqlDbType.NVarChar);
                comman.Parameters.Add("@CodCiudad", SqlDbType.NVarChar);
                comman.Parameters.Add("@dire", SqlDbType.NVarChar);
                comman.Parameters.Add("@nivel", SqlDbType.Int);
                comman.Parameters.Add("@pro", SqlDbType.NVarChar);
                comman.Parameters.Add("@tipos", SqlDbType.Int);
                comman.Parameters.Add("@estado", SqlDbType.Int);

                comman.Parameters.Add("@EPS", SqlDbType.Int);
                comman.Parameters.Add("@ARL", SqlDbType.Int);

                comman.Parameters.Add("@tel", SqlDbType.NVarChar);
                comman.Parameters.Add("@foto1", SqlDbType.Image);
                comman.Parameters.Add("@foto2", SqlDbType.Image);
                comman.Parameters.Add("@firma", SqlDbType.Image);
                comman.Parameters.Add("@dominancia", SqlDbType.Int);
                //comman.Parameters.Add("@fechaIngreso", SqlDbType.Date);

                comman.Parameters["@TipoI"].Value = _Paciente.Pac_TipoIdentificacion.TipoIde_Codigo;
                comman.Parameters["@ide"].Value = identificacion;
                comman.Parameters["@identi"].Value = _Paciente.Pac_Identificacion;
                comman.Parameters["@n1"].Value = _Paciente.Pac_Nombre1;
                comman.Parameters["@n2"].Value = _Paciente.Pac_Nombre2;
                comman.Parameters["@a1"].Value = _Paciente.Pac_Apellido1;
                comman.Parameters["@a2"].Value = _Paciente.Pac_Apellido2;

                //MessageBox.Show(_Paciente.Pac_FechaNacimiento.ToShortDateString());
                comman.Parameters["@fecha"].Value = _Paciente.Pac_FechaNacimiento.ToShortDateString();
                comman.Parameters["@genero"].Value = _Paciente.Pac_CodGenero.Gen_Codigo;
                comman.Parameters["@CodDepartamento"].Value = _Paciente.Pac_CodDepto.Dept_Codigo;
                comman.Parameters["@CodCiudad"].Value = _Paciente.Pac_CodCiudad.Ciud_Codigo;
                //comman.Parameters["@lugar"].Value = TxtLugarNacimiento.Text;
                comman.Parameters["@dire"].Value = _Paciente.Pac_Direccion;
                comman.Parameters["@nivel"].Value = _Paciente.Pac_CodNivelEducativo.NivEdu_Codigo;
                comman.Parameters["@pro"].Value = _Paciente.Pac_CodProfesion.Prof_Codigo;
                comman.Parameters["@tipos"].Value = _Paciente.Pac_TipoSangre.TipSan_Codigo;
                comman.Parameters["@estado"].Value = _Paciente.Pac_EstadoCivil.EstCivil_Codigo;
                comman.Parameters["@tel"].Value = _Paciente.Pac_Telefono;
                comman.Parameters["@dominancia"].Value = _Paciente.Pac_Dominancia_Codigo.Dom_Codigo;

                comman.Parameters["@EPS"].Value = _Paciente.Pac_CodEPS.Eps_Codigo;
                comman.Parameters["@ARL"].Value = _Paciente.Pac_CodARL.Arl_Codigo;

                if (_Paciente.Pac_Huella != null)
                {
                    comman.Parameters["@foto2"].Value = _Paciente.Pac_Huella.GetBuffer();
                }
                else
                    comman.Parameters["@foto2"].Value = DBNull.Value;

                if (_Paciente.Pac_Foto != null)
                {
                    comman.Parameters["@foto1"].Value = _Paciente.Pac_Foto.GetBuffer();
                }
                else
                    comman.Parameters["@foto1"].Value = DBNull.Value;

                if (_Paciente.Pac_Foto != null)
                {
                    comman.Parameters["@firma"].Value = _Paciente.Pac_Foto.GetBuffer();
                }

                else
                    comman.Parameters["@firma"].Value = DBNull.Value;

                comman.ExecuteNonQuery();
                SQLtrans.Commit();
                error = "Datos Actualizados";
            }
            catch (Exception ex)
            {
                error = ex.Message;
                try
                { SQLtrans.Rollback(); }
                catch (Exception)
                {
                }
            }
        }
        public  Cls_Paciente Buscar_Paciente_(string Documento_)
        {
            string Query = "SELECT	dbo.Paciente.Pac_TipoIdentificacion, dbo.Paciente.Pac_Identificacion, dbo.Paciente.Pac_Nombre1,     " +
                            "dbo.Paciente.Pac_Nombre2, dbo.Paciente.Pac_Apellido1, dbo.Paciente.Pac_Apellido2,                          " +
                            "dbo.Paciente.Pac_FechaNacimiento, dbo.Paciente.Pac_CodGenero, dbo.Paciente.Pac_CodDepto,                   " +
                            "dbo.Paciente.Pac_CodCiudad, dbo.Paciente.Pac_Direccion, dbo.Paciente.Pac_CodNivelEducativo,                " +
                            "dbo.Paciente.Pac_CodProfesion, dbo.Paciente.Pac_TipoSangre, dbo.Paciente.Pac_EstadoCivil,                  " +
                            "dbo.Paciente.Pac_Telefono, dbo.Paciente.Pac_Foto, dbo.Paciente.Pac_Huella, dbo.Paciente.Pac_Firma,         " +
                            "dbo.Paciente.Pac_Dominancia_Codigo, dbo.Paciente.Pac_Fecha, dbo.Paciente.Pac_CodEPS,                       " +
                            "dbo.Paciente.Pac_CodARL, dbo.Ciudad.Ciud_CodDepto, dbo.Ciudad.Ciud_Codigo, dbo.Ciudad.Ciud_Nombre,         " +
                            "dbo.Departamento.Dept_Codigo, dbo.Departamento.Dept_Nombre, dbo.TipoDocumento.TipoIde_Codigo,              " +
                            "dbo.TipoDocumento.TipoIde_Descripcion, dbo.Genero.Gen_Codigo, dbo.Genero.Gen_Descripcion,                  " +
                            "dbo.NivelEducativo.NivEdu_Codigo, dbo.NivelEducativo.NivEdu_Descripcion, dbo.Profesion.Prof_Codigo,        " +
                            "dbo.Profesion.Prof_Descripcion, dbo.EstadoCivil.EstCivil_Codigo, dbo.EstadoCivil.EstCivil_Descripcion,     " +
                            "dbo.TipoSangre.TipSan_Codigo, dbo.TipoSangre.TipSan_Descripcion, dbo.Dominancia.Dom_Codigo,                " +
                            "dbo.Dominancia.Dom_Descripcion, dbo.ARL.Arl_Descripcion, dbo.ARL.Arl_Codigo, dbo.EPS.Eps_Codigo,           " +
                            "dbo.EPS.Eps_Descripcion                                                                                    " +
                            "FROM    dbo.Departamento INNER JOIN                                                                        " +
                            "dbo.Ciudad ON dbo.Departamento.Dept_Codigo = dbo.Ciudad.Ciud_CodDepto INNER JOIN                           " +
                            "dbo.TipoDocumento INNER JOIN                                                                               " +
                            "dbo.Paciente ON dbo.TipoDocumento.TipoIde_Codigo = dbo.Paciente.Pac_TipoIdentificacion INNER JOIN          " +
                            "dbo.EPS ON dbo.Paciente.Pac_CodEPS = dbo.EPS.Eps_Codigo INNER JOIN                                         " +
                            "dbo.ARL ON dbo.Paciente.Pac_CodARL = dbo.ARL.Arl_Codigo INNER JOIN                                         " +
                            "dbo.Profesion ON dbo.Paciente.Pac_CodProfesion = dbo.Profesion.Prof_Codigo ON                              " +
                            "dbo.Ciudad.Ciud_CodDepto = dbo.Paciente.Pac_CodDepto AND                                                   " +
                            "dbo.Ciudad.Ciud_Codigo = dbo.Paciente.Pac_CodCiudad INNER JOIN                                             " +
                            "dbo.Genero ON dbo.Paciente.Pac_CodGenero = dbo.Genero.Gen_Codigo INNER JOIN                                " +
                            "dbo.Dominancia ON dbo.Paciente.Pac_Dominancia_Codigo = dbo.Dominancia.Dom_Codigo INNER JOIN                " +
                            "dbo.NivelEducativo ON dbo.Paciente.Pac_CodNivelEducativo = dbo.NivelEducativo.NivEdu_Codigo INNER JOIN     " +
                            "dbo.EstadoCivil ON dbo.Paciente.Pac_EstadoCivil = dbo.EstadoCivil.EstCivil_Codigo INNER JOIN               " +
                            "dbo.TipoSangre ON dbo.Paciente.Pac_TipoSangre = dbo.TipoSangre.TipSan_Codigo                               " +
                            "WHERE Pac_Identificacion='" + Documento_ + "'";
            DataTable tablaPaciente2 = new DataTable();
            var _Paciente = new Cls_Paciente();
            tablaPaciente2 = ClsSqlServer.LlenarTabla(Query); 
            if (tablaPaciente2.Rows.Count > 0)
            {
                _Paciente.Pac_TipoIdentificacion = new Cls_TipoDocumento { TipoIde_Codigo = tablaPaciente2.Rows[0]["Pac_TipoIdentificacion"].ToString(), TipoIde_Descripcion = tablaPaciente2.Rows[0]["TipoIde_Descripcion"].ToString() };
                _Paciente.Pac_Identificacion = Documento_;

                _Paciente.Pac_Nombre1 = tablaPaciente2.Rows[0]["Pac_Nombre1"].ToString();
                _Paciente.Pac_Nombre2 = tablaPaciente2.Rows[0]["Pac_Nombre2"].ToString();
                _Paciente.Pac_Apellido1 = tablaPaciente2.Rows[0]["Pac_Apellido1"].ToString();
                _Paciente.Pac_Apellido2 = tablaPaciente2.Rows[0]["Pac_Apellido2"].ToString();

                _Paciente.Pac_FechaNacimiento = Convert.ToDateTime(tablaPaciente2.Rows[0]["Pac_FechaNacimiento"].ToString());
                _Paciente.Pac_Fecha = Convert.ToDateTime(tablaPaciente2.Rows[0]["Pac_Fecha"]);
                _Paciente.Pac_CodGenero = new Cls_Genero { Gen_Codigo = tablaPaciente2.Rows[0]["Pac_CodGenero"].ToString(), Gen_Descripcion = tablaPaciente2.Rows[0]["Gen_Descripcion"].ToString() };
                _Paciente.Pac_CodDepto = new Cls_Departamento { Dept_Codigo = tablaPaciente2.Rows[0]["Pac_CodDepto"].ToString(), Dept_Nombre = tablaPaciente2.Rows[0]["Dept_Nombre"].ToString() };
                _Paciente.Pac_CodCiudad = new Cls_Ciudad { Ciud_Codigo = tablaPaciente2.Rows[0]["Pac_CodCiudad"].ToString(), Ciud_Nombre = tablaPaciente2.Rows[0]["Ciud_Nombre"].ToString() };

                _Paciente.Pac_Direccion = tablaPaciente2.Rows[0]["Pac_Direccion"].ToString();
                _Paciente.Pac_CodNivelEducativo = new Cls_NivelEducativo { NivEdu_Codigo = int.Parse(tablaPaciente2.Rows[0]["Pac_CodNivelEducativo"].ToString()), NivEdu_Descripcion = tablaPaciente2.Rows[0]["NivEdu_Descripcion"].ToString() };
                _Paciente.Pac_CodProfesion = new Cls_Profesion { Prof_Codigo = int.Parse(tablaPaciente2.Rows[0]["Pac_CodProfesion"].ToString()), Prof_Descripcion = tablaPaciente2.Rows[0]["Prof_Descripcion"].ToString() };
                _Paciente.Pac_TipoSangre = new Cls_TipoSangre { TipSan_Codigo = int.Parse(tablaPaciente2.Rows[0]["Pac_TipoSangre"].ToString()), TipSan_Descripcion = tablaPaciente2.Rows[0]["TipSan_Descripcion"].ToString() };
                _Paciente.Pac_EstadoCivil = new Cls_EstadoCivil { EstCivil_Codigo = Convert.ToInt32(tablaPaciente2.Rows[0]["Pac_EstadoCivil"].ToString()), EstCivil_Descripcion = tablaPaciente2.Rows[0]["EstCivil_Descripcion"].ToString() };

                _Paciente.Pac_Telefono = tablaPaciente2.Rows[0]["Pac_Telefono"].ToString();
                _Paciente.Pac_Dominancia_Codigo = new Cls_Dominancia { Dom_Codigo = Convert.ToInt32(tablaPaciente2.Rows[0]["Pac_Dominancia_Codigo"].ToString()), Dom_Descripcion = tablaPaciente2.Rows[0]["Dom_Descripcion"].ToString() };
                _Paciente.Pac_CodEPS = new Cls_Eps { Eps_Codigo = Convert.ToInt32(tablaPaciente2.Rows[0]["Pac_CodEPS"].ToString()), Eps_Descripcion = tablaPaciente2.Rows[0]["Eps_Descripcion"].ToString() };
                _Paciente.Pac_CodARL = new Cls_Arl { Arl_Codigo = Convert.ToInt32(tablaPaciente2.Rows[0]["Pac_CodARL"].ToString()), Arl_Descripcion = tablaPaciente2.Rows[0]["Arl_Descripcion"].ToString() };

                string[] fecha = DateTime.Now.ToString().Split(' ');
                _Paciente.Pac_Fecha = DateTime.Now;
                if (tablaPaciente2.Rows[0]["Pac_Huella"].ToString() != "")
                {
                    byte[] imageBuffer1 = (byte[])tablaPaciente2.Rows[0]["Pac_Huella"];
                    System.IO.MemoryStream ms1 = new System.IO.MemoryStream(imageBuffer1);
                    _Paciente.Pac_Huella = ms1;
                }
                else
                    _Paciente.Pac_Huella = null;
                if (tablaPaciente2.Rows[0]["Pac_Foto"].ToString() != "")
                {
                    byte[] imageBuffer1 = (byte[])tablaPaciente2.Rows[0]["Pac_Foto"];
                    System.IO.MemoryStream ms1 = new System.IO.MemoryStream(imageBuffer1);
                    _Paciente.Pac_Foto = ms1;
                }
                else
                    _Paciente.Pac_Foto = null;
                if (tablaPaciente2.Rows[0]["Pac_firma"].ToString() != "")
                {
                    byte[] imageBuffer1 = (byte[])tablaPaciente2.Rows[0]["Pac_firma"];
                    System.IO.MemoryStream ms1 = new System.IO.MemoryStream(imageBuffer1);
                    _Paciente.Pac_Firma = ms1;
                }
                else
                    _Paciente.Pac_Firma = null;
            }
            return _Paciente;
        }
    }
}
