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
    public class CategoriasController : Controller
    {
        NProducto nProducto;
        ECategoria eCategoria;

        //vistas
        // GET: Categorias
        public ActionResult Index()
        {
            return View();
        }

        //-------------------Metodos
        [HttpPost]
        [Route("Listar_Categorias")]
        public ActionResult Listar_Categorias()

        {
            try
            {
                nProducto = new NProducto();
                eCategoria = new ECategoria();

                var existe_usuario = nProducto.Listar_Categorias();

                if (existe_usuario.Count == 0)
                {
                    HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    return new JsonResult { Data = new { status = "Informativo", message = "No hay Datos" }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                }
                else
                {
                    return new JsonResult { Data = existe_usuario, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                }
            }
            catch (Exception ex)
            {
                HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return new JsonResult { Data = new { status = "Error - Servidor", message = ex }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }


        //-------------------Metodos
        [HttpPost]
        [Route("Registro_Categoria")]
        public ActionResult Registro_Categoria(ECategoria obj)

        {
            try
            {
                nProducto = new NProducto();
                eCategoria = new ECategoria();

                var crear_usuario = nProducto.crear_categorias(obj);

                if (crear_usuario)
                {

                    return new JsonResult { Data = new { resultado = true, titulo = "Éxito", mensaje = "Categoria Creado Correctamente" }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                }
                else
                {
                    return new JsonResult { Data = new { resultado = false, codigo_error = 1, errortitulo = "Error", mensaje = "No Se Creo Categoria" }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                }
            }
            catch (Exception ex)
            {
                //nUsuario.insertar_log_error(new ELog_error()
                //{
                //    url_error = "Autenticacion/Loguin",
                //    descripcion_error = "Web externa RRHH: " + ex.Message
                //});

                //obj_resultado = new EResultado_transaccion();
                //obj_resultado.idrespuesta = 0;
                //obj_resultado.descripcion = "Ocurrió un error al iniciar sesión";
                HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return new JsonResult
                {
                    Data = new
                    {
                        status = "Error - Servidor",
                        message = ex
                    },
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }
        }
        //-------------------Metodos
        [HttpPost]
        [Route("Actualizar_Categoria")]
        public ActionResult Actualizar_Categoria(ECategoria obj)

        {
            try
            {
                nProducto = new NProducto();
                eCategoria = new ECategoria();


                var existe_usuario = nProducto.actualizar_categorias(obj);

                if (existe_usuario)
                {
                    return new JsonResult { Data = new { resultado = true, titulo = "Éxito", mensaje = "Categoria Actualizado Correctamente" }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                }
                else
                {
                    return new JsonResult { Data = new { resultado = false, codigo_error = 1, errortitulo = "Error", mensaje = "Categoria No Actualizado" }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                }
            }
            catch (Exception ex)
            {
                //nUsuario.insertar_log_error(new ELog_error()
                //{
                //    url_error = "Autenticacion/Loguin",
                //    descripcion_error = "Web externa RRHH: " + ex.Message
                //});

                //obj_resultado = new EResultado_transaccion();
                //obj_resultado.idrespuesta = 0;
                //obj_resultado.descripcion = "Ocurrió un error al iniciar sesión";
                HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return new JsonResult { Data = new { status = "Error - Servidor", message = ex }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }
        //-------------------Metodos
        [HttpPost]
        [Route("Actualizar_Estado_Categoria")]
        public ActionResult Actualizar_Estado_Categoria(int codigo_categoria)

        {
            try
            {
                nProducto = new NProducto();
                eCategoria = new ECategoria();


                var existe_usuario = nProducto.actualizar_estado_categoria(codigo_categoria);

                if (existe_usuario)
                {
                    return new JsonResult { Data = new { resultado = true, titulo = "Éxito", mensaje = "Categoria Actualizado Correctamente" }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                }
                else
                {
                    return new JsonResult { Data = new { resultado = false, codigo_error = 1, errortitulo = "Error", mensaje = "Categoria No Actualizado" }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                }
            }
            catch (Exception ex)
            {
                //nUsuario = new NUsuario();
                //nUsuario.insertar_log_error(new ELog_error()
                //{
                //    url_error = "Autenticacion/Loguin",
                //    descripcion_error = "Web externa RRHH: " + ex.Message
                //});

                //obj_resultado = new EResultado_transaccion();
                //obj_resultado.idrespuesta = 0;
                //obj_resultado.descripcion = "Ocurrió un error al iniciar sesión";
                HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return new JsonResult { Data = new { status = "Error - Servidor", message = ex }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }
    }
}