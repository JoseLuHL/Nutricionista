using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nutricionista.Tablas
{
  public  class Cls_HabitoDetalle
    {
        public Cls_Habitos HabPac_Habito_Codigo { get; set; }
        public int HabPac_Entrada_Numero { get; set; }
        public string HabPac_Caracteristica { get; set; }
        public string HabPac_Frecuencia { get; set; }
        public string HabPac_Tiempo { get; set; }
        public string HabPac_Observacion { get; set; }

    }
}
