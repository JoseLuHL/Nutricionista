using Nutricionista.Conexion;
using Nutricionista.Tablas;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nutricionista.Historia_Clinica
{
   public  class Cls_Insertar_Atencion
    {
        public string respuesta { get; set; }

        public void Insertar_Atencion (List<Cls_Atencion> _Atencion)
        {
            //string Query = "";
            SqlConnection cnn = new SqlConnection(CadenaConexion.cadena());
            //Abrimos la conexión()
            cnn.Open();
            SqlTransaction SQLtrans = cnn.BeginTransaction();
            try
            {
                SqlCommand comman = cnn.CreateCommand();
                comman.Transaction = SQLtrans;
                //PRIME SE INSERTA LA ENTRADA - INSERTAR EN ENTRADA - HISTORIA
                string NumeroEntrada = "";
                string QueryI = "DELETE FROM [dbo].[DiagnosticoPaciente]  WHERE DiagPaci_NumeroHistoria=" + NumeroEntrada;
                comman.CommandText = QueryI;
                comman.ExecuteNonQuery();

                QueryI = "DELETE FROM [dbo].[AccidenteLaboral]  WHERE AccLab_Entrada_Numero=" + NumeroEntrada;
                comman.CommandText = QueryI;
                comman.ExecuteNonQuery();

                QueryI = "DELETE FROM [dbo].[ExamenLaboratorio] WHERE ExaLabo_Entrada_Numero=" + NumeroEntrada;
                comman.CommandText = QueryI;
                comman.ExecuteNonQuery();

                QueryI = "DELETE FROM [dbo].[AntecedentePersonal] WHERE AntPer_Entrada_Numero=" + NumeroEntrada;
                comman.CommandText = QueryI;
                comman.ExecuteNonQuery();

                QueryI = "DELETE FROM [dbo].[AntecednteFamiliar] WHERE AntFam_Entrada_Numero =" + NumeroEntrada;
                comman.CommandText = QueryI;
                comman.ExecuteNonQuery();

                QueryI = "DELETE FROM [dbo].[CicloMenstrual] WHERE CicMens_Entrada_Numero=" + NumeroEntrada;
                comman.CommandText = QueryI;
                comman.ExecuteNonQuery();

                QueryI = "DELETE FROM [dbo].[EnfermedadProfesional] WHERE EnfPro_Entrada_Numero=" + NumeroEntrada;
                comman.CommandText = QueryI;
                comman.ExecuteNonQuery();

                QueryI = "DELETE FROM [dbo].[ExamenFisico] WHERE ExaFisi_Entrada_Numero=" + NumeroEntrada;
                comman.CommandText = QueryI;
                comman.ExecuteNonQuery();

                QueryI = "DELETE FROM [dbo].[ExamenPracticado] WHERE  ExaPrac_Examen_Codigo=" + NumeroEntrada;
                comman.CommandText = QueryI;
                comman.ExecuteNonQuery();

                QueryI = "DELETE FROM [dbo].[HabitoPaciente] WHERE HabPac_Entrada_Numero=" + NumeroEntrada;
                comman.CommandText = QueryI;
                comman.ExecuteNonQuery();

                QueryI = "DELETE FROM [dbo].[InformacionOcupacional] WHERE InfOcu_Entrada_Numero=" + NumeroEntrada;
                comman.CommandText = QueryI;
                comman.ExecuteNonQuery();

                QueryI = "DELETE FROM [dbo].[Inmunizar] WHERE Inmu_Entrada_Numero=" + NumeroEntrada;
                comman.CommandText = QueryI;
                comman.ExecuteNonQuery();

                QueryI = "DELETE FROM [dbo].[ProbabilidadRiego] WHERE ProbRiesg_Entrada_Numero=" + NumeroEntrada;
                comman.CommandText = QueryI;
                comman.ExecuteNonQuery();

                QueryI = "DELETE FROM [dbo].[RevisionSistema] WHERE RevSist_Entrada_Numero=" + NumeroEntrada;
                comman.CommandText = QueryI;
                comman.ExecuteNonQuery();

                QueryI = "DELETE FROM [dbo].[RiesgoOcupacional] WHERE RiegOcu_Entrada_Numero=" + NumeroEntrada;
                comman.CommandText = QueryI;
                comman.ExecuteNonQuery();

                QueryI = "DELETE FROM [dbo].[RecomendacionPaciente] WHERE RecoPac_Entrada_Numero=" + NumeroEntrada;
                comman.CommandText = QueryI;
                comman.ExecuteNonQuery();

                QueryI = "DELETE FROM [dbo].[EquilibroPaciente] WHERE EqiPa_HistoriaNumero=" + NumeroEntrada;
                comman.CommandText = QueryI;
                comman.ExecuteNonQuery();

                QueryI = "DELETE FROM [dbo].[ExamenPracticado] WHERE ExaPrac_Entrada_Numero=" + NumeroEntrada;
                comman.CommandText = QueryI;
                comman.ExecuteNonQuery();

                QueryI = "DELETE FROM [dbo].[Examen_Paciente] WHERE ExamPaci_Numero_Entrada=" + NumeroEntrada;
                comman.CommandText = QueryI;
                comman.ExecuteNonQuery();



            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
