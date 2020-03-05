using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nutricionista.Conexion
{
   public static class CadenaConexion
    {

       public static string cadena()
           {
               string conexionTxt;

               conexionTxt = Application.StartupPath + @"\conexion\conexion.txt"; //ARCHIVO DE TEXTO PARA GUARDAR DATOS
               string[] lines = System.IO.File.ReadAllLines(conexionTxt);
               string[] conexion = System.IO.File.ReadAllLines(conexionTxt);
               return conexion[0];
           }
       public static Boolean SaberHacerCopiaSeguridad()
       {
           Boolean retornar = false;
           string conexionTxt;
           conexionTxt = Application.StartupPath + @"\conexion\conexion.txt"; //ARCHIVO DE TEXTO PARA GUARDAR DATOS
           string[] lines = System.IO.File.ReadAllLines(conexionTxt);
           string[] conexion = System.IO.File.ReadAllLines(conexionTxt);
           if (conexion[1] == "S")
               retornar = true;
           return retornar;
       }

        public async static Task<string> cadenaAsync()
        {
            string conexionTxt;
            string[] conexion = new string[50];
            await Task.Run(() =>
            {
                conexionTxt = Application.StartupPath + @"\conexion\conexion.txt"; //ARCHIVO DE TEXTO PARA GUARDAR DATOS
                string[] lines = System.IO.File.ReadAllLines(conexionTxt);
                conexion = System.IO.File.ReadAllLines(conexionTxt);
            });
            return conexion[0];
        }
    }
}
