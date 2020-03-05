using System;
using System.Collections.Generic;

namespace ApiCitasMedicas.Models
{
    public partial class MedicosEspecialidades
    {
        public int Id { get; set; }
        public int Medicoid { get; set; }
        public int Especialidadid { get; set; }
        public DateTime? Fecharegistro { get; set; }
        public bool? Activo { get; set; }
        public string nombreMedico { get; set; }
        public string apellidoMedico { get; set; }
        public string nombreApellido { get; set; }
        public string Dni { get; set; }
        public string nombreEspecialidad { get; set; }
        public string Descripcion { get; set; }
        public virtual Especialidades Especialidad { get; set; }
        public virtual Medicos Medico { get; set; }
    }
}
