using System;
using System.Collections.Generic;

namespace ApiCitasMedicas.Models
{
    public partial class Eps
    {
        public Eps()
        {
            Paciente = new HashSet<paciente>();
        }

        public int EpsCodigo { get; set; }
        public string EpsDescripcion { get; set; }

        public virtual ICollection<paciente> Paciente { get; set; }
    }
}
