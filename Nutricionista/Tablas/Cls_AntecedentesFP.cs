using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nutricionista.Tablas
{
   public class Cls_AntecedentesFP
    {
        public int AnteP_Codigo { get; set; }
        public string AnteP_Descripcion { get; set; }
    }

    public class Cls_AntecedenteFamiliar
    {
        public int AntFam_Numero { get; set; }
        public Cls_AntecedentesFP AntFam_Enfermedad_Codigo { get; set; }
        public int AntFam_Entrada_Numero { get; set; }
        public string AntFam_Parentesco { get; set; }
        public Boolean AntFam_Mortalidad { get; set; }
    }

    public class Cls_AntecedentesPersonales
    {
        public int AntPer_Numero { get; set; }
        public Cls_AntecedentesFP AntPer_Antecedende_Codigo { get; set; }
        public int AntPer_Entrada_Numero { get; set; }
        public string AntPer_Diagnostico { get; set; }
        public string AntPer_Observacion { get; set; }
    }

    public class Cls_Historial_Peso
    {
        public int HistPes_Codigo { get; set; }
        public int HistPes_NumeroAtencion { get; set; }
        public string HistPes_EdadSobrepeso { get; set; }
        public string HistPes_Problema { get; set; }
        public string HistPes_PesoMaximo { get; set; }
        public string HistPes_PesoMinimo { get; set; }
    }

    public class Cls_Antropometria
    {
        public int Antr_Codigo { get; set; }
        public int Antr__NumeroAtencion { get; set; }
        public string Antr_Peso { get; set; }
        public string Antr_Talla { get; set; }
        public string Antr_IMC { get; set; }
        public string Antr_PesoIdeal { get; set; }
        public string Antr_ExcesoPeso { get; set; }
    }

    public class Cls_Recordatorio
    {
        public int Record_Codigo { get; set; }
        public int Record_NumeroAtencion { get; set; }
        public Cls_Comida Record_CodComida { get; set; }
        public string Record_Hora { get; set; }
        public string Record_Preparacion { get; set; }
        public int Record_Cantidad { get; set; }       
    }

    public class Cls_Alimento
    {
        public int Alim_Codigo { get; set; }
        public string Alim_Descripcion { get; set; }
    }

    public class  Cls_Frecuencia_Consumo
    {
        public int FreCon_Codigo { get; set; }
        public Cls_Alimento FreCon_CodAlimento { get; set; }
        public int FreCon_NumeroAtencion { get; set; }
        public string FreCon_Diario { get; set; }
        public string FreCon_Semanal { get; set; }
        public string FreCon_Quincenal { get; set; }
        public string FreCon_Mensual { get; set; }
        public string FreCon_Nunca { get; set; }
    }
}
