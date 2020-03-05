using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nutricionista.Operaciones_Comun
{
  public  class ConsultasComun
    {
        HistoriaClinica_NutricionistaEntities db;
        public ConsultasComun()
        {
            db = new HistoriaClinica_NutricionistaEntities();
        }

    }
}
