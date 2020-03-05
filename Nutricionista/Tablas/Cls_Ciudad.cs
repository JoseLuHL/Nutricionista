using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nutricionista.Tablas
{
   public class Cls_Ciudad
    {
        public string Ciud_Codigo { get; set; }
        public string Ciud_Nombre { get; set; }
        public Cls_Departamento Ciud_CodDepto { get; set; }
    }
}
