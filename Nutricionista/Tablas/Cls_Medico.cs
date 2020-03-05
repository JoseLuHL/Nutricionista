using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nutricionista.Tablas
{
   public class Cls_Medico
    {
        public string Medic_TipoIdentificacion { get; set; }
        public string Medic_Identificacion { get; set; }
        public string Medic_Nombre1 { get; set; }
        public string Medic_Nombre2 { get; set; }
        public string Medic_Apellido1 { get; set; }
        public string Medic_Apellido2 { get; set; }
        public string Medic_NombreCompleto
        {
            get { return $"{Medic_Nombre1} {Medic_Nombre2} {Medic_Apellido1} {Medic_Apellido2}"; }
        }
        //private string nombreCompleto;

        //public string Medic_NombreCompleto
        //{
        //    get { return nombreCompleto; }
        //    set { nombreCompleto = $"{Medic_Nombre1} {Medic_Nombre2} {Medic_Apellido1} {Medic_Apellido2}"; }
        //}

        public Image Medic_Foto { get; set; }
        public Image Medic_Huella { get; set; }
        public Image Medic_Firma { get; set; }

    }
}
