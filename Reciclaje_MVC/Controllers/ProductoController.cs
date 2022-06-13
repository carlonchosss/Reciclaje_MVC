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
    public class ProductoController : Controller
    {
        NProducto nProducto;
        ECategoria eCategoria;
        EProducto eProducto;

        //vistas
        // GET: Producto
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
        [Route("Listar_Producto")]
        public ActionResult Listar_Producto()

        {
            try
            {
                nProducto = new NProducto();
                eProducto = new EProducto();

                var existe_usuario = nProducto.Listar_Producto();

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
        [Route("Todo_Listar_Producto")]
        public ActionResult Todo_Listar_Producto()

        {
            try
            {
                nProducto = new NProducto();
                eProducto = new EProducto();

                var existe_usuario = nProducto.Todo_Listar_Producto();

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
        [Route("Registro_Producto")]
        public ActionResult Registro_Producto(EProducto obj)

        {
            try
            {
                nProducto = new NProducto();
                eProducto = new EProducto();

                var crear_usuario = nProducto.crear_producto(obj);

                if (crear_usuario)
                {

                    return new JsonResult { Data = new { resultado = true, titulo = "Éxito", mensaje = "Producto Creado Correctamente" }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                }
                else
                {
                    return new JsonResult { Data = new { resultado = false, codigo_error = 1, errortitulo = "Error", mensaje = "No Se Creo Producto" }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
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
        [Route("Actualizar_Producto")]
        public ActionResult Actualizar_Producto(EProducto obj)

        {
            try
            {
                nProducto = new NProducto();
                eProducto = new EProducto();


                var existe_usuario = nProducto.actualizar_producto(obj);

                if (existe_usuario)
                {
                    return new JsonResult { Data = new { resultado = true, titulo = "Éxito", mensaje = "Producto Actualizado Correctamente" }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                }
                else
                {
                    return new JsonResult { Data = new { resultado = false, codigo_error = 1, errortitulo = "Error", mensaje = "Producto No Actualizado" }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
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
        [Route("Actualizar_Estado_Producto")]
        public ActionResult Actualizar_Estado_Producto(int codigo_producto)

        {
            try
            {
                nProducto = new NProducto();
                eProducto = new EProducto();


                var existe_usuario = nProducto.actualizar_estado_producto(codigo_producto);

                if (existe_usuario)
                {
                    return new JsonResult { Data = new { resultado = true, titulo = "Éxito", mensaje = "Producto Actualizado Correctamente" }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                }
                else
                {
                    return new JsonResult { Data = new { resultado = false, codigo_error = 1, errortitulo = "Error", mensaje = "Producto No Actualizado" }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
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