using Nutricionista.Conexion;
using Nutricionista.Estados;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nutricionista.Historia_Clinica
{
    public class Cls_Actualizar_Estado_Atencion
    {
        public string error { get; set; }

        public void Actualizar_estado(int NumeroAtencion)
        {
            SqlConnection cnn = new SqlConnection(CadenaConexion.cadena());
            cnn.Open();
            SqlTransaction SQLtrans = cnn.BeginTransaction();
            try
            {
                SqlCommand command = cnn.CreateCommand();
                command.Transaction = SQLtrans;
                string sql = "UPDATE [dbo].[Atencion_Historia] SET [Ent_Estado] = @Estado  WHERE Entr_Numero="+NumeroAtencion;
                command.CommandText = sql;
                command.Connection = cnn;
                //command.Parameters.AddWithValue("", _Atencion.Entr_Numero);
                command.Parameters.AddWithValue("@Estado", Cls_Estados_Atencion.Atendiendo);
                command.ExecuteNonQuery();

                SQLtrans.Commit();
                error = "Datos guardados";
            }
            catch (Exception ex)
            {
                error = ex.ToString();
                try
                { SQLtrans.Rollback(); }
                catch (Exception)
                {
                }

            }
        }

    }
}
