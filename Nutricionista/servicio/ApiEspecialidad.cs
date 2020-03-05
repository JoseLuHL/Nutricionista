using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace Nutricionista.servicio
{
    public class ApiEspecialidad
    {
        private  string url = ConfigurationManager.AppSettings["url"].ToString()+ "Especialidades";
        public  List< ESPECIALIDADES> Especialidad { get; set; }
        public  string error = "";
        public async Task EspecialidadAsync()
        {
            
            //Se configura la petición.
            HttpWebRequest peticion;
            peticion = WebRequest.Create(url) as HttpWebRequest;
            peticion.ContentType = "application/json; charset=utf-8";
            peticion.Method = "GET";

            try
            {
                HttpWebResponse respuesta = peticion.GetResponse() as HttpWebResponse;
                if ((int)respuesta.StatusCode == 200)
                {
                    var reader = new StreamReader(respuesta.GetResponseStream());
                    string s = reader.ReadToEnd();
                    await Task.Run(() => { Especialidad = JsonConvert.DeserializeObject<List<ESPECIALIDADES>>(s); });
                    error = respuesta.StatusCode.ToString();
                }
                else
                    error = $" Error {respuesta.StatusCode}";
            }
            catch (Exception ex)
            {
                error= ex.Message;
            }
        }

    }
}
