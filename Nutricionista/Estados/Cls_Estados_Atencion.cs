using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nutricionista.Estados
{
   public static  class Cls_Estados_Atencion
    {
        

        public static int Pendiente =1;
        public static int Guardada = 2;
        public static int cerrada = 3;
        public static int Atendiendo = 4;
    }
    public class Cls_Estados_Atencion2
    {
        public  int EstAten_Codigo { get; set; }
        public string EstAten_Descripcion { get; set; }
    }
}
