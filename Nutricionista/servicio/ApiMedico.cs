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

namespace Nutricionista.servicio
{
    public class ApiMedico
    {
        private string url = ConfigurationManager.AppSettings["url"].ToString() + "Medicos/";
        public  string error = "";
        public async Task<Medicos> MedicosAsync(string id)
        {
            //Se configura la petición.
            HttpWebRequest peticion;
            peticion = WebRequest.Create($"{url}{id}") as HttpWebRequest;
            peticion.ContentType = "application/json; charset=utf-8";
            peticion.Method = "GET";
            var Medicos = new Medicos();

            try
            {
                HttpWebResponse respuesta = peticion.GetResponse() as HttpWebResponse;
                if ((int)respuesta.StatusCode == 200)
                {
                    var reader = new StreamReader(respuesta.GetResponseStream());
                    string s = reader.ReadToEnd();
                    await Task.Run(() => { Medicos = JsonConvert.DeserializeObject<Medicos>(s); });
                    error = respuesta.StatusCode.ToString();
                }
                else
                    error = $" Error {respuesta.StatusCode}";
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            return Medicos;
        }
    }
}