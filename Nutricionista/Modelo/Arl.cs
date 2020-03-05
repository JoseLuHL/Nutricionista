using System;
using System.Collections.Generic;

namespace ApiCitasMedicas.Models
{
    public partial class Arl
    {
        public Arl()
        {
            Paciente = new HashSet<paciente>();
        }

        public int ArlCodigo { get; set; }
        public string ArlDescripcion { get; set; }

        public virtual ICollection<paciente> Paciente { get; set; }
    }
}
