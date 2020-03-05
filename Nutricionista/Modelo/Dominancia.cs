using System;
using System.Collections.Generic;

namespace ApiCitasMedicas.Models
{
    public partial class Dominancia
    {
        public Dominancia()
        {
            Paciente = new HashSet<paciente>();
        }

        public int DomCodigo { get; set; }
        public string DomDescripcion { get; set; }

        public virtual ICollection<paciente> Paciente { get; set; }
    }
}
