using System;
using System.Collections.Generic;

namespace ApiCitasMedicas.Models
{
    public partial class TipoDocumento
    {
        public TipoDocumento()
        {
            Paciente = new HashSet<paciente>();
        }

        public string TipoIdeCodigo { get; set; }
        public string TipoIdeDescripcion { get; set; }

        public virtual ICollection<paciente> Paciente { get; set; }
    }
}
