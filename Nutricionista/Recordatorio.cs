//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Nutricionista
{
    using System;
    using System.Collections.Generic;
    
    public partial class Recordatorio
    {
        public int Record_Codigo { get; set; }
        public Nullable<int> Record_NumeroAtencion { get; set; }
        public Nullable<int> Record_CodComida { get; set; }
        public string Record_Hora { get; set; }
        public string Record_Preparacion { get; set; }
        public Nullable<int> Record_Cantidad { get; set; }
    
        public virtual Atencion_Historia Atencion_Historia { get; set; }
        public virtual Comida Comida { get; set; }
    }
}