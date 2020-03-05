using Nutricionista.Estados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nutricionista.Tablas
{
   public class Cls_Atencion
   {
        public int Entr_Numero { get; set; }
        public Cls_Paciente Entr_IdPaciente { get; set; }
        public DateTime Entr_FechaEntrada { get; set; }
        public DateTime Entr_Hora { get; set; }
        public string Entr_Diagnostico { get; set; }
        public int Entr_Concepto_Codigo { get; set; }
        public string Entr_Recomendacion { get; set; }
        public int Entr_Reubicacion { get; set; }
        public string Entr_TipoExamenCodigo { get; set; }
        public int Ent_Enfasis { get; set; }
        public Cls_Estados_Atencion2 Ent_Estado { get; set; }
        public string Ent_conceptoAptitud { get; set; }
        public string Ent_MotivoConsulta { get; set; }
        public Cls_Medico Ent_CodMedico { get; set; }
        //public List<Cls_Habitos> Habitos_Detalle { get; set; }
        public Cls_Eps Ent_CodEPS { get; set; }
        public Cls_Arl Ent_CodARL { get; set; }

        public List<Cls_HabitoDetalle> Ent_Habito_Detalle { get; set; }
        public List<Cls_AntecedenteFamiliar> Ent_AntecedenteFamiliar_Detalle { get; set; }
        public List<Cls_AntecedentesPersonales> Ent_Antecedentepersonales_Detalle { get; set; }
        public List<Cls_Historial_Peso> Ent_HistoriaPeso_Detalle { get; set; }
        public List<Cls_Antropometria> Ent_Antropometria_Detalle { get; set; }
        public List<Cls_Recordatorio> Ent_Recordatorio_Detalle { get; set; }
        public List<Cls_Frecuencia_Consumo> Ent_FrecuenciaConsumo_Detalle { get; set; }
        
        //public int Ent_CodEPS { get; set; }
        //public int Ent_CodARL { get; set; }

    }
}
