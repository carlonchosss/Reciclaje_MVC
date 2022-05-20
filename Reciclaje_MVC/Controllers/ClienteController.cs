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
    public class ClienteController : Controller
    {
        EUsuario_Login eUsuario_Login;
        EUsuario eUsuario;
        NUsuario nUsuario;

        //vistas
        // GET: Principal
        public ActionResult Index()
        {
            return View();
        }

        //-------------------Metodos
        [HttpPost]
        [Route("Listar_Usuarios")]
        public ActionResult Listar_Usuarios()

        {
            try
            {
                nUsuario = new NUsuario();
                eUsuario = new EUsuario();
                eUsuario_Login = new EUsuario_Login();

                var existe_usuario = nUsuario.listar_usuarios();

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
                nUsuario = new NUsuario();
                HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return new JsonResult { Data = new { status = "Error - Servidor", message = ex }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }


        //-------------------Metodos
        [HttpPost]
        [Route("Registro_Usuario_Adm")]
        public ActionResult Registro_Usuario_Adm(EUsuario obj)

        {
            try
            {
                nUsuario = new NUsuario();
                eUsuario = new EUsuario();
                eUsuario_Login = new EUsuario_Login();

                eUsuario_Login.usuario = obj.usuario;

                var existe_usuario = nUsuario.validar_existe_usuario_por_documento(eUsuario_Login);

                if (existe_usuario)
                {
                    return new JsonResult { Data = new { resultado = false, codigo_error = 0, errortitulo = "Advertencia", mensaje = "Usuario Ya Existe" }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                }
                else
                {
                    var crear_usuario = nUsuario.crear_usuario_sistema(obj);
                    return new JsonResult { Data = new { resultado = true, titulo = "Éxito", mensaje = "Usuario Creado Correctamente" }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                }
            }
            catch (Exception ex)
            {
                nUsuario = new NUsuario();
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
        [Route("Actualizar_Usuario_Adm")]
        public ActionResult Actualizar_Usuario_Adm(EUsuario obj)

        {
            try
            {
                nUsuario = new NUsuario();
                eUsuario = new EUsuario();
                eUsuario_Login = new EUsuario_Login();


                var existe_usuario = nUsuario.actualizar_usuario_sistema(obj);

                if (existe_usuario)
                {
                    return new JsonResult { Data = new { resultado = true, titulo = "Éxito", mensaje = "Usuario Actualizado Correctamente" }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                }
                else
                {
                    return new JsonResult { Data = new { resultado = false, codigo_error = 1, errortitulo = "Error", mensaje = "Usuario No Actualizado" }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                }
            }
            catch (Exception ex)
            {
                nUsuario = new NUsuario();
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
        [Route("Actualizar_Estado_Usuario_Adm")]
        public ActionResult Actualizar_Estado_Usuario_Adm(int codigo_usuario)

        {
            try
            {
                nUsuario = new NUsuario();
                eUsuario = new EUsuario();
                eUsuario_Login = new EUsuario_Login();


                var existe_usuario = nUsuario.actualizar_estado_usuario_sistema(codigo_usuario);

                if (existe_usuario)
                {
                    return new JsonResult { Data = new { resultado = true, titulo = "Éxito", mensaje = "Usuario Actualizado Correctamente" }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                }
                else
                {
                    return new JsonResult { Data = new { resultado = false, codigo_error = 1, errortitulo = "Error", mensaje = "Usuario No Actualizado" }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                }
            }
            catch (Exception ex)
            {
                nUsuario = new NUsuario();
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