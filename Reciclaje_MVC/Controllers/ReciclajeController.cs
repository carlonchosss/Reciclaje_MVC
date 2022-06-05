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
    public class ReciclajeController : Controller
    {
        NProducto nProducto;
        NReciclaje nReciclaje;
        ECategoria eCategoria;
        EProducto eProducto;
        EEmpresa_Descuento eEmpresa_Descuento;
        // GET: Reciclaje
        public ActionResult Index()
        {
            return View();
        }

        //-------------------Metodos
        [HttpPost]
        [Route("Listar_Producto_Categoria")]
        public ActionResult Listar_Producto_Categoria(int codigo_categoria)

        {
            try
            {
                nProducto = new NProducto();
                eProducto = new EProducto();

                var existe_usuario = nProducto.listar_producto_categoria(codigo_categoria);

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

        //-------------------Metodos
        [HttpPost]
        [Route("Guardar_reciclaje")]

        public ActionResult Guardar_reciclaje(string codigo_usuario, List<ERegistro_Reciclaje_Detalle> valor_detalle)

        {
            try
            {

                nReciclaje = new NReciclaje();
                var crear_usuario = nReciclaje.crear_reciclaje(codigo_usuario, valor_detalle);

                if (crear_usuario > 0)
                {

                    return new JsonResult { Data = new { resultado = true, titulo = "Éxito", mensaje = "Reciclaje Creado Correctamente" }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                }
                else
                {
                    return new JsonResult { Data = new { resultado = false, codigo_error = 1, errortitulo = "Error", mensaje = "No Se Creo Reciclaje" }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
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
        [Route("Listar_Reciclaje_Usuario")]
        public ActionResult Listar_Reciclaje_Usuario(int codigo_usuario)

        {
            try
            {
                nReciclaje = new NReciclaje();

                var existe_usuario = nReciclaje.listar_reciclaje_usuario(codigo_usuario);

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

        //-------------------Metodos
        [HttpPost]
        [Route("Listar_Todo_Reciclaje_Usuario")]
        public ActionResult Listar_Todo_Reciclaje_Usuario(int codigo_usuario)

        {
            try
            {
                nReciclaje = new NReciclaje();

                var existe_usuario = nReciclaje.listar_todo_reciclaje_usuario(codigo_usuario);

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


        //--------------------------------------------------------------------EmpresaDescuento
        public ActionResult EmpresaDescuento()
        {
            return View();
        }

        //-------------------Metodos
        [HttpPost]
        [Route("Listar_Empresa_Descuento")]
        public ActionResult Listar_Empresa_Descuento()

        {
            try
            {
                nReciclaje = new NReciclaje();
                eEmpresa_Descuento = new EEmpresa_Descuento();

                var existe_usuario = nReciclaje.Listar_Empresa_Descuento();

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
        [Route("Registro_Empresa_Descuento")]
        public ActionResult Registro_Empresa_Descuento(EEmpresa_Descuento obj)

        {
            try
            {
                nReciclaje = new NReciclaje();
                eEmpresa_Descuento = new EEmpresa_Descuento();

                var crear_usuario = nReciclaje.crear_Empresa_Descuentos(obj);

                if (crear_usuario)
                {

                    return new JsonResult { Data = new { resultado = true, titulo = "Éxito", mensaje = "Empresa Descuento Creado Correctamente" }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                }
                else
                {
                    return new JsonResult { Data = new { resultado = false, codigo_error = 1, errortitulo = "Error", mensaje = "No Se Creo Empresa Descuento" }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
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
        [Route("Actualizar_Empresa_Descuento")]
        public ActionResult Actualizar_Empresa_Descuento(EEmpresa_Descuento obj)

        {
            try
            {
                nReciclaje = new NReciclaje();
                eEmpresa_Descuento = new EEmpresa_Descuento();


                var existe_usuario = nReciclaje.actualizar_empresa_descuento(obj);

                if (existe_usuario)
                {
                    return new JsonResult { Data = new { resultado = true, titulo = "Éxito", mensaje = "Empresa Descuento Actualizado Correctamente" }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                }
                else
                {
                    return new JsonResult { Data = new { resultado = false, codigo_error = 1, errortitulo = "Error", mensaje = "Empresa Descuento No Actualizado" }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
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
        [Route("Actualizar_Estado_Empresa_Descuento")]
        public ActionResult Actualizar_Estado_Empresa_Descuento(int codigo_empresa_descuento)

        {
            try
            {
                nReciclaje = new NReciclaje();
                eEmpresa_Descuento = new EEmpresa_Descuento();


                var existe_usuario = nReciclaje.actualizar_estado_empresa_descuento(codigo_empresa_descuento);

                if (existe_usuario)
                {
                    return new JsonResult { Data = new { resultado = true, titulo = "Éxito", mensaje = "Empresa Descuento Actualizado Correctamente" }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                }
                else
                {
                    return new JsonResult { Data = new { resultado = false, codigo_error = 1, errortitulo = "Error", mensaje = "Empresa Descuento No Actualizado" }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
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

        [HttpPost]
        [Route("Mostrar_Puntos_Reciclaje")]
        public ActionResult Mostrar_Puntos_Reciclaje(int codigo_usuario)

        {
            try
            {
                nReciclaje = new NReciclaje();

                var existe_usuario = nReciclaje.Mostrar_Puntos_Reciclaje(codigo_usuario);

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


        [HttpPost]
        [Route("Listar_Empresa_Descuento_Reciclaje_cantidad")]
        public ActionResult Listar_Empresa_Descuento_Reciclaje_cantidad(int codigo_usuario)

        {
            try
            {
                nReciclaje = new NReciclaje();

                var existe_usuario = nReciclaje.Listar_Empresa_Descuento_Reciclaje_cantidad(codigo_usuario);

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

        [HttpPost]
        [Route("exportar_pdf_reciclaje_cliente_puntos")]
        public ActionResult exportar_pdf_reciclaje_cliente_puntos(int codigo_usuario)

        {
            try
            {
                nReciclaje = new NReciclaje();

                var existe_usuario = nReciclaje.Listar_Empresa_Descuento_Reciclaje_cantidad(codigo_usuario);

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