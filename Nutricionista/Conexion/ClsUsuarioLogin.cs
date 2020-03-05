using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nutricionista.Conexion
{
   public static class ClsUsuarioLogin
    {
       public static string Usuario;
       public static string Medico;
       
       public static void ConsultarMedico(string usuario)
       {
           //ClsSqlServer ObjServer = new ClsSqlServer();
           string Query = "SELECT [Medic_Identificacion] " +
                          ",[Medic_Identificacion] " +
                          ",[Medic_Nombre1]        " +
                          ",[Medic_Nombre2]        " +
                          ",[Medic_Apellido1]      " +
                          ",[Medic_Apellido2]      " +
                          ",[Medic_Foto]           " +
                          ",[Medic_Firma]          " +
                          "FROM [dbo].[Medico]     " +
                    "WHERE Medic_Identificacion='" + usuario + "'";
           MessageBox.Show(Query);
           DataTable tablaMedico = new DataTable();
           tablaMedico = ClsSqlServer.LlenarTabla(Query);
           //MessageBox.Show(tablaMedico.Rows.Count.ToString());
           if (tablaMedico.Rows.Count > 0)
               Medico = tablaMedico.Rows[0]["Medic_Identificacion"].ToString();
           else
               Medico = "";
       }     
    }
}
