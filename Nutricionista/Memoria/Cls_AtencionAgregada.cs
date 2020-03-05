using Nutricionista.Conexion;
using Nutricionista.Tablas;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Nutricionista.Estados;
using Nutricionista.Insertar;
using Nutricionista.Historia_Clinica;

namespace Nutricionista.Memoria
{
    public static class Cls_AtencionAgregada
    {
        //Se utiliza para guardar las atenciones ingresadas recientes 
        public static List<Cls_Atencion> Cls_Atencions = new List<Cls_Atencion>();
        //Se utiliza para guardar las atenciones que estan en el sistema
        public static List<Cls_Atencion> Atencion_Cargadas_Pendientes = new List<Cls_Atencion>();
        public static List<Cls_Atencion> Atencion_Cargadas_Atendidas = new List<Cls_Atencion>();

        public static List<Cls_Atencion> Historia_Atenciones = new List<Cls_Atencion>();

        //carga las atenciones en la lista "Atencion_Cargadas"
        public static async Task CargarAtenciones_Pendientes()
        {
            Atencion_Cargadas_Pendientes.Clear();
            string sql = "SELECT dbo.Atencion_Historia.Entr_Numero," +
                         "dbo.Atencion_Historia.Entr_IdPaciente,                " +
                         "dbo.Atencion_Historia.Entr_FechaEntrada,              " +
                         "dbo.Atencion_Historia.Entr_Hora,                      " +
                         "dbo.Atencion_Historia.Ent_Estado,                     " +
                         "dbo.Atencion_Historia.Ent_MotivoConsulta,             " +
                         "dbo.Atencion_Historia.Ent_CodMedico,                  " +
                         "dbo.Paciente.Pac_Nombre1,                             " +
                         "dbo.Paciente.Pac_Nombre2,                             " +
                         "dbo.Paciente.Pac_Apellido1,                           " +
                         "dbo.Paciente.Pac_Apellido2                            " +
                         "FROM    dbo.Atencion_Historia INNER JOIN              " +
                         "dbo.Paciente ON dbo.Atencion_Historia.Entr_IdPaciente " +
                         "= dbo.Paciente.Pac_Identificacion WHERE Ent_Estado=" + Cls_Estados_Atencion.Pendiente + " OR Ent_Estado=" + Cls_Estados_Atencion.Atendiendo;

            List<Cls_Habitos> _Habitos = new List<Cls_Habitos>();
            DataTable tabla = new DataTable();
            await Task.Run(() => { tabla = ClsSqlServer.LlenarTabla(sql); });
            if (tabla.Rows.Count > 0)
            {
                foreach (DataRow item in tabla.Rows)
                    Atencion_Cargadas_Pendientes.Add(new Cls_Atencion
                    {
                        Entr_Numero = Convert.ToInt32(item["Entr_Numero"]),
                        Entr_IdPaciente = new Cls_Paciente
                        {
                            Pac_Identificacion = item["Entr_IdPaciente"].ToString(),
                            Pac_Nombre1 = item["Pac_Nombre1"].ToString(),
                            Pac_Nombre2 = item["Pac_Nombre2"].ToString(),
                            Pac_Apellido1 = item["Pac_Apellido1"].ToString(),
                            Pac_Apellido2 = item["Pac_Apellido2"].ToString(),
                        },
                        Entr_FechaEntrada = Convert.ToDateTime(item["Entr_FechaEntrada"].ToString()),
                        Entr_Hora = Convert.ToDateTime(item["Entr_Hora"].ToString()),
                        Ent_MotivoConsulta = item["Ent_MotivoConsulta"].ToString(),
                        Ent_Estado = new Cls_Estados_Atencion2 { EstAten_Codigo = Convert.ToInt32(item["Ent_Estado"].ToString()) },
                        Ent_CodMedico = new Cls_Medico { Medic_Identificacion = item["Ent_CodMedico"].ToString() }
                    });
            }

        }

        public static void CargarAtenciones_Atendidas(string Identiicacion)
        {
            Atencion_Cargadas_Atendidas.Clear();
            string sql = "SELECT dbo.Atencion_Historia.Entr_Numero," +
                         "dbo.Atencion_Historia.Entr_IdPaciente,                " +
                         "dbo.Atencion_Historia.Entr_FechaEntrada,              " +
                         "dbo.Atencion_Historia.Entr_Hora,                      " +
                         "dbo.Atencion_Historia.Ent_Estado,                     " +
                         "dbo.Atencion_Historia.Ent_MotivoConsulta,             " +
                         "dbo.Atencion_Historia.Ent_CodMedico,                  " +
                         "dbo.Paciente.Pac_Nombre1,                             " +
                         "dbo.Paciente.Pac_Nombre2,                             " +
                         "dbo.Paciente.Pac_Apellido1,                           " +
                         "dbo.Paciente.Pac_Apellido2                            " +
                         "FROM    dbo.Atencion_Historia INNER JOIN              " +
                         "dbo.Paciente ON dbo.Atencion_Historia.Entr_IdPaciente " +
                         "= dbo.Paciente.Pac_Identificacion WHERE Pac_Identificacion='" + Identiicacion + "'";// and Ent_Estado<>" + Cls_Estados_Atencion.Pendiente;

            DataTable tablaAtencion = new DataTable();
            tablaAtencion = ClsSqlServer.LlenarTabla(sql);
            Oper_Paciente oper_Paciente = new Oper_Paciente();
            var _Paciente = oper_Paciente.Buscar_Paciente_(Identiicacion);
            var _Atencion_Detalle = new Cls_Detalle_Atencion();
           

            if (tablaAtencion.Rows.Count > 0)
            {
                foreach (DataRow item in tablaAtencion.Rows)
                {
                    Atencion_Cargadas_Atendidas.Add(new Cls_Atencion
                    {
                        Entr_Numero = Convert.ToInt32(item["Entr_Numero"]),
                        Entr_IdPaciente = _Paciente,
                        Entr_FechaEntrada = Convert.ToDateTime(item["Entr_FechaEntrada"].ToString()),
                        Entr_Hora = Convert.ToDateTime(item["Entr_Hora"].ToString()),
                        Ent_MotivoConsulta = item["Ent_MotivoConsulta"].ToString(),
                        Ent_Estado = new Cls_Estados_Atencion2 { EstAten_Codigo = Convert.ToInt32(item["Ent_Estado"].ToString()) },
                        Ent_CodMedico = new Cls_Medico { Medic_Identificacion = item["Ent_CodMedico"].ToString(), Medic_Nombre1 = "Falta asignar el nombre" },
                        Ent_Habito_Detalle = _Atencion_Detalle._HabitoDetalle(Convert.ToInt32(item["Entr_Numero"])),
                        Ent_AntecedenteFamiliar_Detalle= _Atencion_Detalle._AntecedenteFamiliar_Detalle(Convert.ToInt32(item["Entr_Numero"])),
                        Ent_Antecedentepersonales_Detalle= _Atencion_Detalle._AntecedentePersonales_Detalle(Convert.ToInt32(item["Entr_Numero"])),
                        Ent_HistoriaPeso_Detalle= _Atencion_Detalle._HistorialPeso_Detalle(Convert.ToInt32(item["Entr_Numero"])),
                        Ent_Antropometria_Detalle=_Atencion_Detalle._Antropometria_Detalle(Convert.ToInt32(item["Entr_Numero"])),
                        Ent_Recordatorio_Detalle=_Atencion_Detalle._Recordatorio_Detalle(Convert.ToInt32(item["Entr_Numero"])),
                        Ent_FrecuenciaConsumo_Detalle=_Atencion_Detalle._FrecuenciaConsumo_Detalle(Convert.ToInt32(item["Entr_Numero"]))
                    });
                }
            }
            else
                Atencion_Cargadas_Atendidas.Add(new Cls_Atencion
                {
                    Entr_IdPaciente = _Paciente
                });


        }

    }
}
