using Nutricionista.Conexion;
using Nutricionista.Tablas;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nutricionista.Historia_Clinica
{
    public class Cls_Insertar_Paiente_Pendiente
    {
        public string error = "";
        //Inserta un paciente el cual sera agendado
        public void Insertar_PacientesPendientes(List<Cls_Atencion> _Atencion)
        {
            SqlConnection cnn = new SqlConnection(CadenaConexion.cadena());
            //SqlCommand command = new SqlCommand();
            //Abrimos la conexión()
            cnn.Open();
            SqlTransaction SQLtrans = cnn.BeginTransaction();
            try
            {
                SqlCommand command = cnn.CreateCommand();
                command.Transaction = SQLtrans;
                string sql = "INSERT INTO [dbo].[Atencion_Historia] " +
                          "([Entr_IdPaciente],[Entr_FechaEntrada],[Entr_Hora] ,[Entr_Diagnostico],[Entr_Concepto_Codigo]   " +
                          ",[Entr_Recomendacion] ,[Entr_Reubicacion] ,[Entr_TipoExamenCodigo] ,[Ent_Enfasis] ,[Ent_Estado] " +
                          " ,[Ent_conceptoAptitud],[Ent_CodEPS] ,[Ent_CodARL] ,[Ent_MotivoConsulta] ,[Ent_CodMedico])      " +
                          "VALUES (@Entr_IdPaciente,@Entr_FechaEntrada,@Entr_Hora,@Entr_Diagnostico,@Entr_Concepto_Codigo," +
                          "@Entr_Recomendacion,@Entr_Reubicacion,@Entr_TipoExamenCodigo,@Ent_Enfasis,@Ent_Estado," +
                          "@Ent_conceptoAptitud,@Ent_CodEPS,@Ent_CodARL,@Ent_MotivoConsulta,@Ent_CodMedico)";
                command.CommandText = sql;
                command.Connection = cnn;
                //command.Parameters.AddWithValue("", _Atencion.Entr_Numero);
                command.Parameters.AddWithValue("@Entr_IdPaciente", _Atencion[0].Entr_IdPaciente.Pac_Identificacion);
                command.Parameters.AddWithValue("@Entr_FechaEntrada", DateTime.Now.Date.ToShortDateString());
                command.Parameters.AddWithValue("@Entr_Hora", DateTime.Now);
                command.Parameters.AddWithValue("@Entr_Diagnostico", _Atencion[0].Entr_Diagnostico);
                command.Parameters.AddWithValue("@Entr_Concepto_Codigo", _Atencion[0].Entr_Concepto_Codigo);
                command.Parameters.AddWithValue("@Entr_Recomendacion", _Atencion[0].Entr_Recomendacion);
                command.Parameters.AddWithValue("@Entr_Reubicacion", _Atencion[0].Entr_Reubicacion);
                command.Parameters.AddWithValue("@Entr_TipoExamenCodigo", _Atencion[0].Entr_TipoExamenCodigo);
                command.Parameters.AddWithValue("@Ent_Enfasis", _Atencion[0].Ent_Enfasis);
                command.Parameters.AddWithValue("@Ent_Estado", _Atencion[0].Ent_Estado.EstAten_Codigo);
                command.Parameters.AddWithValue("@Ent_conceptoAptitud", _Atencion[0].Ent_conceptoAptitud);
                command.Parameters.AddWithValue("@Ent_CodEPS", _Atencion[0].Ent_CodEPS.Eps_Codigo);
                command.Parameters.AddWithValue("@Ent_CodARL", _Atencion[0].Ent_CodARL.Arl_Codigo);
                command.Parameters.AddWithValue("@Ent_MotivoConsulta", _Atencion[0].Ent_MotivoConsulta);
                command.Parameters.AddWithValue("@Ent_CodMedico", _Atencion[0].Ent_CodMedico.Medic_Identificacion);
                command.ExecuteNonQuery();

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
    }
}
