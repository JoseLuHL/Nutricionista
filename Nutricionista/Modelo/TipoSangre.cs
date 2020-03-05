using System;
using System.Collections.Generic;

namespace ApiCitasMedicas.Models
{
    public partial class TipoSangre
    {
        public TipoSangre()
        {
            Paciente = new HashSet<paciente>();
        }

        public int TipSanCodigo { get; set; }
        public string TipSanDescripcion { get; set; }

        public virtual ICollection<paciente> Paciente { get; set; }
    }
}
