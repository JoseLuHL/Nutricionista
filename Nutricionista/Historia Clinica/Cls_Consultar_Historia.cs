using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nutricionista.Tabalas_Atencion;
using Nutricionista.Insertar;
using System.Windows.Forms;
using Nutricionista.Tablas;
using Nutricionista.Memoria;
using Nutricionista.Cargar_Datos;

namespace Nutricionista.Historia_Clinica
{
    public static class Cls_Consultar_Historia
    {
        //public static Cls_Historia_Paciente Historial_Paciente { get; set; }
        public static List<Cls_Atencion> Historia_Paciente = new List<Cls_Atencion>();
        public static  void Cargar_Historia(string Identificacion_Paciente)
        {
            Historia_Paciente.Clear();
            //Instanciamos la clase que carga los datos del paciente
            var _Medico = new Cls_Colecciones_Datos();
            Oper_Paciente oper_Paciente = new Oper_Paciente();
            var _Paciente = oper_Paciente.Buscar_Paciente_(Identificacion_Paciente);
            Cls_AtencionAgregada.CargarAtenciones_Atendidas(Identificacion_Paciente);
            var Atenciones_Atendidas = Cls_AtencionAgregada.Atencion_Cargadas_Atendidas;
            foreach (Cls_Atencion item in Atenciones_Atendidas)
            {
                Historia_Paciente.Add(item);
            }
        }
    }
}
