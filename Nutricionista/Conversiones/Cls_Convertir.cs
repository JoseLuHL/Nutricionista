using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nutricionista.Conversiones
{
    public static class Cls_Convertir
    {
        public static string Convertir_Null_String(DataGridViewCell valor)
        {
            string retornar = "";
            if (valor.Value == null)
                retornar = "";
            else
                retornar = valor.Value.ToString();
            return retornar;
        }
    }
}
