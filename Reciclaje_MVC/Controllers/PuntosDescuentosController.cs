using Entidad;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Reciclaje_MVC.Controllers
{
    public class PuntosDescuentosController : Controller
    {
        NProducto nProducto;
        NReciclaje nReciclaje;
        ECategoria eCategoria;
        EProducto eProducto;
        EEmpresa_Descuento eEmpresa_Descuento;
        EPuntos_Detallados ePuntos_Detallados;

        // GET: PuntosDescuentos
        public ActionResult Index()
        {
            return View();
        }

        //-------------------Metodos
        [HttpPost]
        [Route("Listar_Puntos_Usuario")]
        public ActionResult Listar_Puntos_Usuario(int codigo_usuario)

        {
            try
            {
                nReciclaje = new NReciclaje();

                var existe_usuario = nReciclaje.listar_puntos_descuento_usuario(codigo_usuario);

                //if (existe_usuario.Count == 0)
                //{
                //    HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                //    return new JsonResult { Data = new { status = "Informativo", message = "No hay Datos" }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                //}
                //else
                //{
                return new JsonResult { Data = existe_usuario, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                //}
            }
            catch (Exception ex)
            {
                HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return new JsonResult { Data = new { status = "Error - Servidor", message = ex }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }
    }
}