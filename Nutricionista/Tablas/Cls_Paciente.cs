using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nutricionista.Tablas
{
   public class Cls_Paciente
    {
        public Cls_TipoDocumento Pac_TipoIdentificacion { get; set; }
        public string Pac_Identificacion { get; set; }
        public string Pac_Nombre1 { get; set; }
        public string Pac_Nombre2 { get; set; }
        public string Pac_Apellido1 { get; set; }
        public string Pac_Apellido2 { get; set; }

        public string Pac_Nombre_Completo
        {
            get { return $"{Pac_Nombre1} {Pac_Nombre2} {Pac_Apellido1} {Pac_Apellido2}"; }
        }

        public DateTime Pac_FechaNacimiento { get; set; }
        public Cls_Genero Pac_CodGenero { get; set; }
        public Cls_Departamento Pac_CodDepto { get; set; }
        public Cls_Ciudad Pac_CodCiudad { get; set; }
        public string Pac_Direccion { get; set; }
        public Cls_NivelEducativo Pac_CodNivelEducativo { get; set; }
        public Cls_Profesion Pac_CodProfesion { get; set; }
        public Cls_TipoSangre Pac_TipoSangre { get; set; }
        public Cls_EstadoCivil Pac_EstadoCivil { get; set; }
        public string Pac_Telefono { get; set; }
        public MemoryStream Pac_Foto { get; set; }
        public MemoryStream Pac_Huella { get; set; }
        public MemoryStream Pac_Firma { get; set; }
        public Cls_Dominancia Pac_Dominancia_Codigo { get; set; }
        public DateTime Pac_Fecha { get; set; }
        public Cls_Eps Pac_CodEPS { get; set; }
        public Cls_Arl Pac_CodARL { get; set; }

        public string Pac_Edad
        {
            get { return $"{CalcularEdad(Pac_FechaNacimiento)} {"años"}"  ; }
           
        }

        public static int CalcularEdad(DateTime fechaNacimiento)
        {
            // Obtiene la fecha actual:
            DateTime fechaActual = DateTime.Today;


            // Comprueba que la se haya introducido una fecha válida; si
            // la fecha de nacimiento es mayor a la fecha actual se muestra mensaje
            // de advertencia:
            if (fechaNacimiento > fechaActual)
            {
                //Console.WriteLine("La fecha de nacimiento es mayor que la actual.");
                return -1;
            }
            else
            {
                int edad = fechaActual.Year - fechaNacimiento.Year;
                // Comprueba que el mes de la fecha de nacimiento es mayor
                // que el mes de la fecha actual:
                if (fechaNacimiento.Month > fechaActual.Month)
                {
                    --edad;
                }

                return edad;
            }
        }

    }
}
