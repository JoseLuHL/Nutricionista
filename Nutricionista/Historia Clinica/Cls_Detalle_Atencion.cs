using Nutricionista.Conexion;
using Nutricionista.Tablas;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nutricionista.Historia_Clinica
{
   public class Cls_Detalle_Atencion
    {
        public  List<Cls_HabitoDetalle> _HabitoDetalle(int NumeroAtencion)
        {
            string sql;
            var _Habito_D = new List<Cls_HabitoDetalle>();
            sql = "SELECT	dbo.Atencion_Historia.Entr_Numero, dbo.Atencion_Historia.Entr_IdPaciente,               " +
        "dbo.Atencion_Historia.Entr_FechaEntrada, dbo.Atencion_Historia.Entr_Hora,                       " +
        "dbo.Atencion_Historia.Entr_Diagnostico,                                                         " +
        "dbo.Atencion_Historia.Entr_Concepto_Codigo, dbo.Atencion_Historia.Entr_Recomendacion,           " +
        "dbo.Atencion_Historia.Entr_Reubicacion, dbo.Atencion_Historia.Entr_TipoExamenCodigo,            " +
        "dbo.Atencion_Historia.Ent_Enfasis, dbo.Atencion_Historia.Ent_Estado,                            " +
        "dbo.Atencion_Historia.Ent_conceptoAptitud, dbo.Atencion_Historia.Ent_CodEPS,                    " +
        "dbo.Atencion_Historia.Ent_CodARL,                                                               " +
        "dbo.Atencion_Historia.Ent_MotivoConsulta, dbo.Atencion_Historia.Ent_CodMedico,                  " +
        "dbo.HabitoDetalle.HabPac_Habito_Codigo, dbo.HabitoDetalle.HabPac_Entrada_Numero,                " +
        "dbo.HabitoDetalle.HabPac_Caracteristica, dbo.HabitoDetalle.HabPac_Frecuencia,                   " +
        "dbo.HabitoDetalle.HabPac_Tiempo, dbo.HabitoDetalle.HabPac_Observacion, dbo.HABITOS.HAB_CODIGO,  " +
        "dbo.HABITOS.HAB_DESCRIPCION                                                                     " +
        "FROM    dbo.HABITOS INNER JOIN                                                                  " +
        "dbo.HabitoDetalle ON dbo.HABITOS.HAB_CODIGO = dbo.HabitoDetalle.HabPac_Habito_Codigo INNER JOIN " +
        "dbo.Atencion_Historia ON dbo.HabitoDetalle.HabPac_Entrada_Numero = dbo.Atencion_Historia.Entr_Numero WHERE Entr_Numero=" +NumeroAtencion;
            DataTable tablaHabitoD = new DataTable();
            tablaHabitoD = ClsSqlServer.LlenarTabla(sql);
            foreach (DataRow item_h in tablaHabitoD.Rows)
            {
                _Habito_D.Add(new Cls_HabitoDetalle
                {
                    HabPac_Caracteristica = item_h["HabPac_Caracteristica"].ToString(),
                    HabPac_Entrada_Numero = Convert.ToInt32(item_h["Entr_Numero"].ToString()),
                    HabPac_Frecuencia = item_h["HabPac_Frecuencia"].ToString(),
                    HabPac_Habito_Codigo = new Cls_Habitos { HAB_CODIGO = Convert.ToInt32(item_h["HAB_CODIGO"].ToString()), HAB_DESCRIPCION = item_h["HAB_DESCRIPCION"].ToString() },
                    HabPac_Observacion = item_h["HabPac_Observacion"].ToString(),
                    HabPac_Tiempo = item_h["HabPac_Tiempo"].ToString()
                });
            }
            return _Habito_D;
        }


        public List<Cls_AntecedenteFamiliar> _AntecedenteFamiliar_Detalle(int NumeroAtencion)
        {
            string sql;
            var _AntecedenteFamiliar = new List<Cls_AntecedenteFamiliar>();
            sql = "SELECT	dbo.Atencion_Historia.Entr_Numero, dbo.Atencion_Historia.Entr_IdPaciente,           "+
                    "dbo.Atencion_Historia.Entr_FechaEntrada, dbo.Atencion_Historia.Entr_Hora,                  "+
		            "dbo.Atencion_Historia.Entr_Diagnostico,                                                    "+
		            "dbo.Atencion_Historia.Entr_Concepto_Codigo,                                                "+
		            "dbo.Atencion_Historia.Entr_Recomendacion,                                                  "+
		            "dbo.Atencion_Historia.Entr_Reubicacion,                                                    "+
		            "dbo.Atencion_Historia.Entr_TipoExamenCodigo,                                               "+
		            "dbo.Atencion_Historia.Ent_Enfasis, dbo.Atencion_Historia.Ent_Estado,                       "+
		            "dbo.Atencion_Historia.Ent_conceptoAptitud, dbo.Atencion_Historia.Ent_CodEPS,               "+
		            "dbo.Atencion_Historia.Ent_CodARL,                                                          "+
		            "dbo.Atencion_Historia.Ent_MotivoConsulta, dbo.Atencion_Historia.Ent_CodMedico,             "+
		            "dbo.AntecednteFamiliar.AntFam_Numero, dbo.AntecednteFamiliar.AntFam_Enfermedad_Codigo,     "+
		            "dbo.AntecednteFamiliar.AntFam_Entrada_Numero, dbo.AntecednteFamiliar.AntFam_Parentesco,    "+
		            "dbo.AntecednteFamiliar.AntFam_Mortalidad, dbo.AntecedentesF.AnteF_Codigo,                  "+
		            "dbo.AntecedentesF.AnteF_Descripcion                                                        "+
                    "FROM    dbo.AntecedentesF INNER JOIN                                                       "+
                    "dbo.AntecednteFamiliar ON dbo.AntecedentesF.AnteF_Codigo =                                 "+
                    "dbo.AntecednteFamiliar.AntFam_Enfermedad_Codigo INNER JOIN                                 "+
                    "dbo.Atencion_Historia ON dbo.AntecednteFamiliar.AntFam_Entrada_Numero =                    "+
                    "dbo.Atencion_Historia.Entr_Numero                                                          "+
                    "WHERE Entr_Numero=" + NumeroAtencion;

            DataTable tablaHabitoD = new DataTable();
            tablaHabitoD = ClsSqlServer.LlenarTabla(sql);
            foreach (DataRow item_h in tablaHabitoD.Rows)
            {
                _AntecedenteFamiliar.Add(new Cls_AntecedenteFamiliar
                {
                    AntFam_Enfermedad_Codigo= new Cls_AntecedentesFP
                    {
                        AnteP_Codigo = Convert.ToInt32(item_h["AnteF_Codigo"].ToString()),
                        AnteP_Descripcion = item_h["AnteF_Descripcion"].ToString()
                    },
                    AntFam_Entrada_Numero   = Convert.ToInt32(item_h["AntFam_Entrada_Numero"].ToString()),
                    AntFam_Mortalidad       = Convert.ToBoolean(item_h["AntFam_Mortalidad"].ToString()),
                    AntFam_Numero           = Convert.ToInt32(item_h["Entr_Numero"].ToString()),
                    AntFam_Parentesco       = item_h["AntFam_Parentesco"].ToString(),
                });
            }
            return _AntecedenteFamiliar;
        }

        public List<Cls_AntecedentesPersonales> _AntecedentePersonales_Detalle(int NumeroAtencion)
        {
            string sql;
            var _AntecedentePersonales = new List<Cls_AntecedentesPersonales>();
            sql = "SELECT	dbo.Atencion_Historia.Entr_Numero, dbo.Atencion_Historia.Entr_IdPaciente, "+
                    "dbo.Atencion_Historia.Entr_FechaEntrada, dbo.Atencion_Historia.Entr_Hora,        "+
		            "dbo.Atencion_Historia.Entr_Diagnostico,                                          "+
		            "dbo.Atencion_Historia.Entr_Concepto_Codigo,                                      "+
		            "dbo.Atencion_Historia.Entr_Recomendacion,                                        "+
		            "dbo.Atencion_Historia.Entr_Reubicacion,                                          "+
		            "dbo.Atencion_Historia.Entr_TipoExamenCodigo,                                     "+
		            "dbo.Atencion_Historia.Ent_Enfasis,                                               "+
		            "dbo.Atencion_Historia.Ent_Estado,                                                "+
		            "dbo.Atencion_Historia.Ent_conceptoAptitud,                                       "+
		            "dbo.Atencion_Historia.Ent_CodEPS,                                                "+
		            "dbo.Atencion_Historia.Ent_CodARL,                                                "+
		            "dbo.Atencion_Historia.Ent_MotivoConsulta,                                        "+
		            "dbo.Atencion_Historia.Ent_CodMedico,                                             "+
		            "dbo.AntecedentePersonal.AntPer_Numero,                                           "+
		            "dbo.AntecedentePersonal.AntPer_Antecedende_Codigo,                               "+
		            "dbo.AntecedentePersonal.AntPer_Entrada_Numero,                                   "+
		            "dbo.AntecedentePersonal.AntPer_Diagnostico,                                      "+
		            "dbo.AntecedentePersonal.AntPer_Observacion,                                      "+
		            "dbo.AntecedentesP.AnteP_Codigo,                                                  "+
		            "dbo.AntecedentesP.AnteP_Descripcion                                              "+
                    "FROM    dbo.AntecedentePersonal INNER JOIN                                       "+
                    "dbo.AntecedentesP ON dbo.AntecedentePersonal.AntPer_Antecedende_Codigo =         "+
                    "dbo.AntecedentesP.AnteP_Codigo INNER JOIN                                        "+
                    "dbo.Atencion_Historia ON dbo.AntecedentePersonal.AntPer_Entrada_Numero =         "+
                    "dbo.Atencion_Historia.Entr_Numero                                                "+
                    "WHERE Entr_Numero=" + NumeroAtencion;

            DataTable tablaHabitoD = new DataTable();
            tablaHabitoD = ClsSqlServer.LlenarTabla(sql);
            foreach (DataRow item_h in tablaHabitoD.Rows)
            {
                _AntecedentePersonales.Add(new Cls_AntecedentesPersonales
                {
                    AntPer_Antecedende_Codigo = new Cls_AntecedentesFP
                    {
                        AnteP_Codigo = Convert.ToInt32(item_h["AnteP_Codigo"].ToString()),
                        AnteP_Descripcion = item_h["AnteP_Descripcion"].ToString()
                    },
                    AntPer_Entrada_Numero = Convert.ToInt32(item_h["AntPer_Entrada_Numero"].ToString()),
                    AntPer_Numero = Convert.ToInt32(item_h["AntPer_Numero"].ToString()),
                    AntPer_Diagnostico = item_h["AntPer_Diagnostico"].ToString(),
                    AntPer_Observacion = item_h["AntPer_Observacion"].ToString(),
                });
            }
            return _AntecedentePersonales;
        }

        public List<Cls_Historial_Peso> _HistorialPeso_Detalle(int NumeroAtencion)
        {
            string sql;
            var _Historial_Peso = new List<Cls_Historial_Peso>();
            sql = "SELECT	dbo.HistorialPeso.HistPes_Codigo,    "+
                    "dbo.HistorialPeso.HistPes_NumeroAtencion,   "+
		            "dbo.HistorialPeso.HistPes_EdadSobrepeso,    "+
		            "dbo.HistorialPeso.HistPes_Problema,         "+
		            "dbo.HistorialPeso.HistPes_PesoMaximo,       "+
		            "dbo.HistorialPeso.HistPes_PesoMinimo,       "+
		            "dbo.Atencion_Historia.Entr_Numero           "+
                    "FROM    dbo.HistorialPeso INNER JOIN        "+
                    "dbo.Atencion_Historia ON                    "+
                    "dbo.HistorialPeso.HistPes_NumeroAtencion =  "+
                    "dbo.Atencion_Historia.Entr_Numero           "+
                    " WHERE Entr_Numero=" + NumeroAtencion;

            DataTable tablaHabitoD = new DataTable();
            tablaHabitoD = ClsSqlServer.LlenarTabla(sql);
            foreach (DataRow item_h in tablaHabitoD.Rows)
            {
                _Historial_Peso.Add(new Cls_Historial_Peso
                {
                    HistPes_Codigo= Convert.ToInt32(item_h["HistPes_Codigo"].ToString()),
                    HistPes_EdadSobrepeso= item_h["HistPes_EdadSobrepeso"].ToString(),
                    HistPes_NumeroAtencion= Convert.ToInt32(item_h["HistPes_NumeroAtencion"].ToString()),
                    HistPes_PesoMaximo= item_h["HistPes_PesoMaximo"].ToString(),
                    HistPes_PesoMinimo= item_h["HistPes_PesoMinimo"].ToString(),
                    HistPes_Problema= item_h["HistPes_Problema"].ToString()
                });
            }
            return _Historial_Peso;
        }

        public List<Cls_Antropometria> _Antropometria_Detalle(int NumeroAtencion)
        {
            string sql;
            var _Antropometria = new List<Cls_Antropometria>();
            sql = "SELECT	dbo.Antropometria.Antr_Codigo,      "+
                    "dbo.Antropometria.Antr__NumeroAtencion,    "+
		            "dbo.Antropometria.Antr_Peso,               "+
		            "dbo.Antropometria.Antr_Talla,              "+
		            "dbo.Antropometria.Antr_IMC,                "+
		            "dbo.Antropometria.Antr_PesoIdeal,          "+
		            "dbo.Antropometria.Antr_ExcesoPeso,         "+
		            "dbo.Atencion_Historia.Entr_Numero          "+
                    "FROM    dbo.Atencion_Historia INNER JOIN   "+
                    "dbo.Antropometria ON                       "+
                    "dbo.Atencion_Historia.Entr_Numero =        "+
                    "dbo.Antropometria.Antr__NumeroAtencion     "+
                    " WHERE Entr_Numero=" + NumeroAtencion;

            DataTable tablaHabitoD = new DataTable();
            tablaHabitoD = ClsSqlServer.LlenarTabla(sql);
            foreach (DataRow item_h in tablaHabitoD.Rows)
            {
                _Antropometria.Add(new Cls_Antropometria
                {
                    Antr_Codigo = Convert.ToInt32(item_h["Antr_Codigo"].ToString()),
                    Antr_Peso = item_h["Antr_Peso"].ToString(),
                    Antr__NumeroAtencion= Convert.ToInt32(item_h["Antr__NumeroAtencion"].ToString()),
                    Antr_ExcesoPeso= item_h["Antr_ExcesoPeso"].ToString(),
                    Antr_IMC= item_h["Antr_IMC"].ToString(),
                    Antr_PesoIdeal= item_h["Antr_PesoIdeal"].ToString(),
                    Antr_Talla= item_h["Antr_Talla"].ToString()
                });
            }
            return _Antropometria;
        }

        public List<Cls_Recordatorio> _Recordatorio_Detalle(int NumeroAtencion)
        {
            string sql;
            var _Recordatorio = new List<Cls_Recordatorio>();
            sql = "SELECT	dbo.Atencion_Historia.Entr_Numero, dbo.Recordatorio.Record_Codigo, "+
                    "dbo.Recordatorio.Record_NumeroAtencion,                                   "+
		            "dbo.Recordatorio.Record_CodComida, dbo.Recordatorio.Record_Hora,          "+
		            "dbo.Recordatorio.Record_Preparacion, dbo.Recordatorio.Record_Cantidad,    "+
		            "dbo.Comida.Comd_Codigo, dbo.Comida.Comd_Descripcion                       "+
                    "FROM  dbo.Atencion_Historia INNER JOIN                                  "+
                    "dbo.Recordatorio ON dbo.Atencion_Historia.Entr_Numero =                   "+
                    "dbo.Recordatorio.Record_NumeroAtencion INNER JOIN                         "+
                    "dbo.Comida ON dbo.Recordatorio.Record_CodComida = dbo.Comida.Comd_Codigo  "+
                    " WHERE Entr_Numero=" + NumeroAtencion;

            DataTable tablaHabitoD = new DataTable();
            tablaHabitoD = ClsSqlServer.LlenarTabla(sql);
            foreach (DataRow item_h in tablaHabitoD.Rows)
            {
                _Recordatorio.Add(new Cls_Recordatorio
                {
                    Record_Codigo= Convert.ToInt32(item_h["Record_Codigo"].ToString()),
                    Record_NumeroAtencion= Convert.ToInt32(item_h["Record_NumeroAtencion"].ToString()),
                    Record_Hora= item_h["Record_Hora"].ToString(),
                    Record_CodComida= new Cls_Comida
                    {
                        Comd_Codigo = Convert.ToInt32(item_h["Record_CodComida"].ToString()),
                        Comd_Descripcion = item_h["Comd_Descripcion"].ToString()
                    },
                    Record_Cantidad = Convert.ToInt32(item_h["Record_Cantidad"].ToString()),
                    Record_Preparacion = item_h["Record_Preparacion"].ToString(),
                });
            }
            return _Recordatorio;
        }

        public List<Cls_Frecuencia_Consumo> _FrecuenciaConsumo_Detalle(int NumeroAtencion)
        {
            string sql;
            var _FrecuenciaConsumo = new List<Cls_Frecuencia_Consumo>();
            sql = "SELECT	dbo.Frecuencia_Consmo.FreCon_Codigo, dbo.Frecuencia_Consmo.FreCon_CodAlimento,                    "+
                    "dbo.Frecuencia_Consmo.FreCon_NumeroAtencion, dbo.Frecuencia_Consmo.FreCon_Diario,                        "+
		            "dbo.Frecuencia_Consmo.FreCon_Semanal, dbo.Frecuencia_Consmo.FreCon_Quincenal,                            "+
		            "dbo.Frecuencia_Consmo.FreCon_Mensual, dbo.Frecuencia_Consmo.FreCon_Nunca,                                "+
		            "dbo.Atencion_Historia.Entr_Numero,                                                                       "+
		            "dbo.Alimento.Alim_Codigo, dbo.Alimento.Alim_Descripcion                                                  "+
                    "FROM    dbo.Frecuencia_Consmo INNER JOIN                                                                 "+
                    "dbo.Alimento ON dbo.Frecuencia_Consmo.FreCon_CodAlimento = dbo.Alimento.Alim_Codigo INNER JOIN           "+
                    "dbo.Atencion_Historia ON dbo.Frecuencia_Consmo.FreCon_NumeroAtencion = dbo.Atencion_Historia.Entr_Numero "+
                    " WHERE Entr_Numero=" + NumeroAtencion;

            DataTable tablaHabitoD = new DataTable();
            tablaHabitoD = ClsSqlServer.LlenarTabla(sql);
            foreach (DataRow item_h in tablaHabitoD.Rows)
            {
                _FrecuenciaConsumo.Add(new Cls_Frecuencia_Consumo
                {
                    FreCon_Codigo = Convert.ToInt32(item_h["FreCon_Codigo"].ToString()),
                    FreCon_NumeroAtencion = Convert.ToInt32(item_h["Entr_Numero"].ToString()),
                    FreCon_Diario = item_h["FreCon_Diario"].ToString(),
                    FreCon_CodAlimento = new Cls_Alimento
                    {
                        Alim_Codigo = Convert.ToInt32(item_h["Alim_Codigo"].ToString()),
                        Alim_Descripcion = item_h["Alim_Descripcion"].ToString()
                    },
                    FreCon_Semanal = item_h["FreCon_Semanal"].ToString(),
                    FreCon_Quincenal = item_h["FreCon_Quincenal"].ToString(),
                    FreCon_Mensual= item_h["FreCon_Mensual"].ToString(),
                    FreCon_Nunca= item_h["FreCon_Nunca"].ToString()
                });
            }
            return _FrecuenciaConsumo;
        }

    }
}
