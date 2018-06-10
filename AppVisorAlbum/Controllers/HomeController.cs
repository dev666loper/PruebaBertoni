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
using AppVisorAlbum.Models;
namespace AppVisorAlbum.Controllers
{
    public class HomeController : BaseController
    {
       

        public ActionResult ObtenerAlbum(int? idUsuario)
        {
           IEnumerable<AlbumModel>  listaAlbum=cargarServicio<AlbumModel>("https://jsonplaceholder.typicode.com/albums");
            if (idUsuario.HasValue)
            listaAlbum = listaAlbum.Where((obj) => idUsuario.Value == obj.id).ToList();

            return PartialView("_AlbumLista", listaAlbum);
        }

        public ActionResult ObtenerFotos(int idAlbum )
        {
            IEnumerable<FotoModel> listaFotos = cargarServicio<FotoModel>("https://jsonplaceholder.typicode.com/photos");    
           listaFotos = listaFotos.Where((obj) => obj.albumId == idAlbum).ToList();
            return Json(listaFotos, JsonRequestBehavior.AllowGet);
        }
        public ActionResult ObtenerComentario(int idFoto)
        {
            IEnumerable<ComentarioModel> listaComentario = cargarServicio<ComentarioModel>("https://jsonplaceholder.typicode.com/comments");
            listaComentario = listaComentario.Where((obj) => obj.postId == idFoto).ToList();
            return Json(listaComentario, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Index()
        {
            return View();
        }

      

        
    }
}