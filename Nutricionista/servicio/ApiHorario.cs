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
    public class ApiHorario
    {
        private string url = ConfigurationManager.AppSettings["url"].ToString() + "Horarios";
        public string error = "";
        public async Task<Errores.Errores> MedicoEspecialidadAsync(string id)
        {
            //Se configura la petición.
            var resp = new Errores.Errores();
            HttpWebRequest peticion;
            peticion = WebRequest.Create(url) as HttpWebRequest;
            peticion.ContentType = "application/json; charset=utf-8";
            peticion.Method = "POST";
            try
            {
                HttpWebResponse respuesta = peticion.GetResponse() as HttpWebResponse;
                if ((int)respuesta.StatusCode == 200)
                {
                    var reader = new StreamReader(respuesta.GetResponseStream());
                    string s = reader.ReadToEnd();
                    await Task.Run(() => { resp = JsonConvert.DeserializeObject<Errores.Errores>(s); });
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

        public async Task<List<Horarios>> GetHorario(string dni)
        {
            //Se configura la petición.
            var resp = new List<Horarios>();
            HttpWebRequest peticion;
            peticion = WebRequest.Create(url + "/" + dni) as HttpWebRequest;
            peticion.ContentType = "application/json; charset=utf-8";
            peticion.Method = "GET";
            try
            {
                HttpWebResponse respuesta = peticion.GetResponse() as HttpWebResponse;
                if ((int)respuesta.StatusCode == 200)
                {
                    var reader = new StreamReader(respuesta.GetResponseStream());
                    string s = reader.ReadToEnd();
                    await Task.Run(() => { resp = JsonConvert.DeserializeObject<List<Horarios>>(s); });
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

        public async Task<Errores.Errores> PostHorario(List<Horarios> horarios)
        {
            string json_data = JsonConvert.SerializeObject(horarios);
            var resp = new Errores.Errores();
            //Se define la url del método de la api.
            //string token = "tu token de acceso";

            //Se configura la petición.
            System.Net.HttpWebRequest peticion;
            peticion = System.Net.WebRequest.Create(url) as System.Net.HttpWebRequest;
            //peticion.Headers.Add("access_token", token);
            peticion.ContentType = "application/json; charset=utf-8";
            peticion.Method = "POST";

            //Body de la petición
            using (var streamWriter = new StreamWriter(peticion.GetRequestStream()))
            {
                streamWriter.Write(json_data);
                streamWriter.Flush();
                streamWriter.Close();
            }

            try
            {
                // Respuesta
                System.Net.HttpWebResponse respuesta = await peticion.GetResponseAsync() as System.Net.HttpWebResponse;
                if ((int)respuesta.StatusCode == 200)
                {
                    var reader = new StreamReader(respuesta.GetResponseStream());
                    string s = reader.ReadToEnd();
                    resp = JsonConvert.DeserializeObject<Errores.Errores>(s);
                    error = respuesta.StatusCode.ToString();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            return resp;
        }

        public async Task<Errores.Errores> PutHorario(List<Horarios> horarios)
        {
            string json_data = JsonConvert.SerializeObject(horarios);
            var resp = new Errores.Errores();

            //Se configura la petición.
            System.Net.HttpWebRequest peticion;
            peticion = System.Net.WebRequest.Create(url) as System.Net.HttpWebRequest;
            //peticion.Headers.Add("access_token", token);
            peticion.ContentType = "application/json; charset=utf-8";
            peticion.Method = "PUT";

            //Body de la petición
            using (var streamWriter = new StreamWriter(peticion.GetRequestStream()))
            {
                streamWriter.Write(json_data);
                streamWriter.Flush();
                streamWriter.Close();
            }

            try
            {
                // Respuesta
                System.Net.HttpWebResponse respuesta = await peticion.GetResponseAsync() as System.Net.HttpWebResponse;
                if ((int)respuesta.StatusCode == 200)
                {
                    var reader = new StreamReader(respuesta.GetResponseStream());
                    string s = reader.ReadToEnd();
                    resp = JsonConvert.DeserializeObject<Errores.Errores>(s);
                    error = respuesta.StatusCode.ToString();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            return resp;
        }


    }
}
