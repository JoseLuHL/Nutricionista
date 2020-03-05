using Nutricionista.Conexion;
using Nutricionista.Tablas;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nutricionista.Cargar_Datos
{
    public class Cls_Colecciones_Datos
    {
        //ClsSqlServer clsSqlServer = new ClsSqlServer();
        public Cls_Colecciones_Datos()
        {
            ClsSqlServer.Conectar();
        }
        //CARGA LOS HABITOS QUE SE VAN A VISUALIZAR EN EL DGV
        public async Task<List<Cls_Habitos>> Cargar_Habitos()
        {
            List<Cls_Habitos> _Habitos = new List<Cls_Habitos>();
            DataTable tabla = new DataTable();
            await Task.Run(() => { tabla = ClsSqlServer.LlenarTabla("SELECT [HAB_CODIGO]  ,[HAB_DESCRIPCION]  FROM [dbo].[HABITOS]"); });
            if (tabla.Rows.Count > 0)
                foreach (DataRow item in tabla.Rows)
                    _Habitos.Add(new Cls_Habitos
                    {
                        HAB_CODIGO = Convert.ToInt32(item["HAB_CODIGO"]),
                        HAB_DESCRIPCION = item["HAB_DESCRIPCION"].ToString()
                    });
            return _Habitos;
        }
        //CARGA LOS ANTECEDENTES FAMILIARES QUE SE VAN A VISUALIZAR EN EL DGV
        public async Task<List<Cls_Comida>> Cargar_Comidas()
        {
            List<Cls_Comida> _Comida = new List<Cls_Comida>();
            DataTable tabla = new DataTable();
            await Task.Run(() => { tabla = ClsSqlServer.LlenarTabla("SELECT [Comd_Codigo] ,[Comd_Descripcion] FROM [dbo].[Comida]"); });
            if (tabla.Rows.Count > 0)
                foreach (DataRow item in tabla.Rows)
                    _Comida.Add(new Cls_Comida
                    {
                        Comd_Codigo = Convert.ToInt32(item["Comd_Codigo"]),
                        Comd_Descripcion = item["Comd_Descripcion"].ToString()
                    });
            return _Comida;
        }
        public async Task<List<Cls_Alimento>> Cargar_Alimentos()
        {
            List<Cls_Alimento> _Alimento = new List<Cls_Alimento>();
            DataTable tabla = new DataTable();
            await Task.Run(() => { tabla = ClsSqlServer.LlenarTabla("SELECT [Alim_Codigo] ,[Alim_Descripcion]  FROM [dbo].[Alimento]"); });
            if (tabla.Rows.Count > 0)
                foreach (DataRow item in tabla.Rows)
                    _Alimento.Add(new Cls_Alimento
                    {
                        Alim_Codigo = Convert.ToInt32(item["Alim_Codigo"]),
                        Alim_Descripcion = item["Alim_Descripcion"].ToString()
                    });
            return _Alimento;
        }
        public async Task<List<Cls_AntecedentesFP>> Cargar_AntecedentesF()
        {
            List<Cls_AntecedentesFP> _AntecedentesF = new List<Cls_AntecedentesFP>();
            DataTable tabla = new DataTable();
            await Task.Run(() => { tabla = ClsSqlServer.LlenarTabla("SELECT [AnteF_Codigo] ,[AnteF_Descripcion] FROM [AntecedentesF]"); });
            if (tabla.Rows.Count > 0)
                foreach (DataRow item in tabla.Rows)
                    _AntecedentesF.Add(new Cls_AntecedentesFP
                    {
                        AnteP_Codigo = Convert.ToInt32(item["AnteF_Codigo"]),
                        AnteP_Descripcion = item["AnteF_Descripcion"].ToString()
                    });
            return _AntecedentesF;
        }
        //CARGA LOS ANTECEDENTES PERSONALES QUE SE VAN A VISUALIZAR EN EL DGV
        public async Task<List<Cls_AntecedentesFP>> Cargar_AntecedentesP()
        {
            List<Cls_AntecedentesFP> _AntecedentesP = new List<Cls_AntecedentesFP>();
            DataTable tabla = new DataTable();
            await Task.Run(() => { tabla = ClsSqlServer.LlenarTabla("SELECT [AnteP_Codigo] ,[AnteP_Descripcion] FROM [dbo].[AntecedentesP]"); });
            if (tabla.Rows.Count > 0)
                foreach (DataRow item in tabla.Rows)
                    _AntecedentesP.Add(new Cls_AntecedentesFP
                    {
                        AnteP_Codigo = Convert.ToInt32(item["AnteP_Codigo"]),
                        AnteP_Descripcion = item["AnteP_Descripcion"].ToString()
                    });
            return _AntecedentesP;
        }
        //CARGA LOS DEPARTAMENTOS
        public async Task<List<Cls_Departamento>> Cargar_Departamento()
        {
            var _Departamentos = new List<Cls_Departamento>();
            DataTable tabla = new DataTable();
            await Task.Run(() => { tabla = ClsSqlServer.LlenarTabla("SELECT [Dept_Codigo] AS Codigo,[Dept_Nombre] AS Descripcion FROM [dbo].[Departamento] ORDER BY Descripcion"); });
            if (tabla.Rows.Count > 0)
                foreach (DataRow item in tabla.Rows)
                    _Departamentos.Add(new Cls_Departamento
                    {
                        Dept_Codigo = item["Codigo"].ToString(),
                        Dept_Nombre = item["Descripcion"].ToString()
                    });
            return _Departamentos;
        }
        //CARGAR LAS CIUDADES
        public async Task<List<Cls_Ciudad>> Cargar_Ciudad(string _DepartamentoCodigo)
        {
            var _Ciudads = new List<Cls_Ciudad>();
            DataTable tabla = new DataTable();
            await Task.Run(() => { tabla = ClsSqlServer.LlenarTabla("SELECT [Ciud_CodDepto] AS CODDEPARTAMENTO,[Ciud_Codigo] As Codigo,[Ciud_Nombre] AS Descripcion FROM [dbo].[Ciudad] WHERE [Ciud_CodDepto] ='" + _DepartamentoCodigo + "'"); });
            if (tabla.Rows.Count > 0)
                foreach (DataRow item in tabla.Rows)
                    _Ciudads.Add(new Cls_Ciudad
                    {
                        Ciud_Codigo = item["Codigo"].ToString(),
                        Ciud_Nombre = item["Descripcion"].ToString(),
                        Ciud_CodDepto = new Cls_Departamento { Dept_Codigo = item["CODDEPARTAMENTO"].ToString() }
                    });
            return _Ciudads;
        }
        //CARGAR LAS PROFESIONES
        public async Task<List<Cls_Profesion>> Cargar_Profesiones()
        {
            var _Profesions = new List<Cls_Profesion>();
            DataTable tabla = new DataTable();
            await Task.Run(() => { tabla = ClsSqlServer.LlenarTabla("SELECT [Prof_Codigo] AS Codigo,[Prof_Descripcion] AS Descripcion FROM [dbo].[Profesion] ORDER BY Descripcion"); });
            if (tabla.Rows.Count > 0)
                foreach (DataRow item in tabla.Rows)
                    _Profesions.Add(new Cls_Profesion
                    {
                        Prof_Codigo = int.Parse(item["Codigo"].ToString()),
                        Prof_Descripcion = item["Descripcion"].ToString(),
                    });
            return _Profesions;
        }
        public async Task<List<Cls_TipoDocumento>> Cargar_TipoDocumento()
        {
            var _TipoDocumentos = new List<Cls_TipoDocumento>();
            DataTable tabla = new DataTable();
            string Sql = "SELECT [TipoIde_Codigo] As Codigo ,[TipoIde_Descripcion] As Descripcion FROM [dbo].[TipoDocumento]";
            await Task.Run(() => { tabla = ClsSqlServer.LlenarTabla(Sql); });
            if (tabla.Rows.Count > 0)
                foreach (DataRow item in tabla.Rows)
                    _TipoDocumentos.Add(new Cls_TipoDocumento
                    {
                        TipoIde_Codigo = item["Codigo"].ToString(),
                        TipoIde_Descripcion = item["Descripcion"].ToString(),
                    });
            return _TipoDocumentos;
        }
        public async Task<List<Cls_Genero>> Cargar_Genero()
        {
            var _Genero = new List<Cls_Genero>();
            DataTable tabla = new DataTable();
            string Sql = "SELECT [Gen_Codigo] As Codigo, [Gen_Descripcion] As Descripcion  FROM [dbo].[Genero] ORDER BY Descripcion";
            await Task.Run(() => { tabla = ClsSqlServer.LlenarTabla(Sql); });
            if (tabla.Rows.Count > 0)
                foreach (DataRow item in tabla.Rows)
                    _Genero.Add(new Cls_Genero
                    {
                        Gen_Codigo = item["Codigo"].ToString(),
                        Gen_Descripcion = item["Descripcion"].ToString(),
                    });
            return _Genero;
        }
        public async Task<List<Cls_EstadoCivil>> Cargar_EstadoCivil()
        {
            var _EstadoCivils = new List<Cls_EstadoCivil>();
            DataTable tabla = new DataTable();
            string Sql = "SELECT [EstCivil_Codigo] As Codigo ,[EstCivil_Descripcion] As Descripcion  FROM [dbo].[EstadoCivil] ORDER BY Descripcion";
            await Task.Run(() => { tabla = ClsSqlServer.LlenarTabla(Sql); });
            if (tabla.Rows.Count > 0)
                foreach (DataRow item in tabla.Rows)
                    _EstadoCivils.Add(new Cls_EstadoCivil
                    {
                        EstCivil_Codigo = int.Parse(item["Codigo"].ToString()),
                        EstCivil_Descripcion = item["Descripcion"].ToString(),
                    });
            return _EstadoCivils;
        }
        public async Task<List<Cls_TipoSangre>> Cargar_TipoSangre()
        {
            var _TipoSangres = new List<Cls_TipoSangre>();
            DataTable tabla = new DataTable();
            string Sql = "SELECT [TipSan_Codigo] As Codigo ,[TipSan_Descripcion] As Descripcion  FROM [dbo].[TipoSangre] ORDER BY Descripcion";
            await Task.Run(() => { tabla = ClsSqlServer.LlenarTabla(Sql); });
            if (tabla.Rows.Count > 0)
                foreach (DataRow item in tabla.Rows)
                    _TipoSangres.Add(new Cls_TipoSangre
                    {
                        TipSan_Codigo = int.Parse(item["Codigo"].ToString()),
                        TipSan_Descripcion = item["Descripcion"].ToString(),
                    });
            return _TipoSangres;
        }
        public async Task<List<Cls_Dominancia>> Cargar_Dominancia()
        {
            var _Dominancias = new List<Cls_Dominancia>();
            DataTable tabla = new DataTable();
            string Sql = "SELECT [Dom_Codigo] As Codigo ,[Dom_Descripcion] As Descripcion FROM [dbo].[Dominancia] ORDER BY Descripcion";
            await Task.Run(() => { tabla = ClsSqlServer.LlenarTabla(Sql); });
            if (tabla.Rows.Count > 0)
                foreach (DataRow item in tabla.Rows)
                    _Dominancias.Add(new Cls_Dominancia
                    {
                        Dom_Codigo = int.Parse(item["Codigo"].ToString()),
                        Dom_Descripcion = item["Descripcion"].ToString(),
                    });
            return _Dominancias;
        }
        public async Task<List<Cls_NivelEducativo>> Cargar_NivelEducativo()
        {
            var _NivelEducativos = new List<Cls_NivelEducativo>();
            DataTable tabla = new DataTable();
            string Sql = "SELECT [NivEdu_Codigo] AS Codigo,[NivEdu_Descripcion] AS Descripcion FROM [dbo].[NivelEducativo] ORDER BY Codigo";
            await Task.Run(() => { tabla = ClsSqlServer.LlenarTabla(Sql); });
            if (tabla.Rows.Count > 0)
                foreach (DataRow item in tabla.Rows)
                    _NivelEducativos.Add(new Cls_NivelEducativo
                    {
                        NivEdu_Codigo = int.Parse(item["Codigo"].ToString()),
                        NivEdu_Descripcion = item["Descripcion"].ToString()
                    });
            return _NivelEducativos;
        }
        public async Task<List<Cls_Medico>> Cargar_Medico()
        {
            var _Medico = new List<Cls_Medico>();
            DataTable tabla = new DataTable();
            string Sql = "SELECT [Medic_TipoIdentificacion] ,[Medic_Identificacion] ,[Medic_Nombre1] ,[Medic_Nombre2],[Medic_Apellido1],[Medic_Apellido2],[Medic_Foto],[Medic_Huella],[Medic_Firma]FROM[dbo].[Medico] Order By [Medic_Identificacion] ,[Medic_Nombre1] ,[Medic_Nombre2],[Medic_Apellido1],[Medic_Apellido2]";
            await Task.Run(() => { tabla = ClsSqlServer.LlenarTabla(Sql); });
            if (tabla.Rows.Count > 0)
                foreach (DataRow item in tabla.Rows)
                    _Medico.Add(new Cls_Medico
                    {
                        Medic_Identificacion = item["Medic_Identificacion"].ToString(),
                        Medic_Nombre1 = item["Medic_Nombre1"].ToString(),
                        Medic_Nombre2 = item["Medic_Nombre2"].ToString(),
                        Medic_Apellido1 = item["Medic_Apellido1"].ToString(),
                        Medic_Apellido2 = item["Medic_Apellido2"].ToString()
                    });
            return _Medico;
        }
        public List<Cls_Medico> Cargar_Medico(string Identificacion)
        {
            var _Medico = new List<Cls_Medico>();
            DataTable tabla = new DataTable();
            string Sql = "SELECT [Medic_TipoIdentificacion] ,[Medic_Identificacion] ,[Medic_Nombre1] ,[Medic_Nombre2],[Medic_Apellido1],[Medic_Apellido2],[Medic_Foto],[Medic_Huella],[Medic_Firma]FROM[dbo].[Medico] Order By [Medic_Identificacion] ,[Medic_Nombre1] ,[Medic_Nombre2],[Medic_Apellido1],[Medic_Apellido2] WHERE Medic_Identificacion ='" + Identificacion + "'";
            tabla = ClsSqlServer.LlenarTabla(Sql);
            if (tabla.Rows.Count > 0)
                foreach (DataRow item in tabla.Rows)
                    _Medico.Add(new Cls_Medico
                    {
                        Medic_Identificacion = item["Medic_Identificacion"].ToString(),
                        Medic_Nombre1 = item["Medic_Nombre1"].ToString(),
                        Medic_Nombre2 = item["Medic_Nombre2"].ToString(),
                        Medic_Apellido1 = item["Medic_Apellido1"].ToString(),
                        Medic_Apellido2 = item["Medic_Apellido2"].ToString()
                    });
            return _Medico;
        }
        public async Task<List<Cls_Eps>> Cargar_Eps()
        {
            var _Eps = new List<Cls_Eps>();
            DataTable tabla = new DataTable();
            string Sql = "SELECT [Eps_Codigo] ,[Eps_Descripcion] FROM [dbo].[EPS]";
            await Task.Run(() => { tabla = ClsSqlServer.LlenarTabla(Sql); });
            if (tabla.Rows.Count > 0)
                foreach (DataRow item in tabla.Rows)
                    _Eps.Add(new Cls_Eps
                    {
                        Eps_Codigo = int.Parse(item["Eps_Codigo"].ToString()),
                        Eps_Descripcion = item["Eps_Descripcion"].ToString(),
                    });
            return _Eps;
        }
        public async Task<List<Cls_Arl>> Cargar_Arl()
        {
            var _Arl = new List<Cls_Arl>();
            DataTable tabla = new DataTable();
            string Sql = "SELECT [Arl_Codigo] ,[Arl_Descripcion]  FROM [dbo].[ARL]";
            await Task.Run(() => { tabla = ClsSqlServer.LlenarTabla(Sql); });
            if (tabla.Rows.Count > 0)
                foreach (DataRow item in tabla.Rows)
                    _Arl.Add(new Cls_Arl
                    {
                        Arl_Codigo = int.Parse(item["Arl_Codigo"].ToString()),
                        Arl_Descripcion = item["Arl_Descripcion"].ToString(),
                    });
            return _Arl;
        }
    }
}
