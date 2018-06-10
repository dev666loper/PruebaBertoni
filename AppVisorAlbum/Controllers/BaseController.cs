using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Http;
using System.IO;
using System.Text;
using System.Web.Script.Serialization; 
namespace AppVisorAlbum.Controllers
{
    public class BaseController : Controller
    {
        
        public IEnumerable<T> cargarServicio<T>(string servicio)
        {
            IEnumerable<T> listaRecurso = new List<T>();
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(servicio);
            request.ContentType = "application/json; charset=utf-8";
            request.Headers["Authorization"] = "Basic " + Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes("username:password"));
            request.PreAuthenticate = true;
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            using (Stream responseStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                String resultado = reader.ReadToEnd();
                JavaScriptSerializer oJS = new JavaScriptSerializer();
                listaRecurso = oJS.Deserialize<List<T>>(resultado);
            }
            return listaRecurso;
        }
    }
}