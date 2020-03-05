using ApiCitasMedicas.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
//using Nutricionista.modelo
namespace Nutricionista.servicio
{
    class ApiMedicosEspecialidades
    {
        private string url = ConfigurationManager.AppSettings["url"].ToString() + "MedicosEspecialidades/";
        public string error = "";
        public async Task<List<MedicosEspecialidades>> MedicoEspecialidadAsync(string id)
        {
            //Se configura la petición.
            var resp = new List<MedicosEspecialidades>();
            HttpWebRequest peticion;
            peticion = WebRequest.Create($"{url}{id}") as HttpWebRequest;
            peticion.ContentType = "application/json; charset=utf-8";
            peticion.Method = "GET";
            try
            {
                HttpWebResponse respuesta = peticion.GetResponse() as HttpWebResponse;
                if ((int)respuesta.StatusCode == 200)
                {
                    var reader = new StreamReader(respuesta.GetResponseStream());
                    string s = reader.ReadToEnd();
                    await Task.Run(() => { resp = JsonConvert.DeserializeObject<List<MedicosEspecialidades>>(s); });
                    error = respuesta.StatusCode.ToString();
                }
                else
                    error = $" Error {respuesta.StatusCode}";
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            return resp;
        }
    }
}
