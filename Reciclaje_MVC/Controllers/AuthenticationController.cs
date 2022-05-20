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
    public class AuthenticationController : Controller
    {
        EUsuario_Login eUsuario_Login;
        EUsuario eUsuario;
        NUsuario nUsuario;

        EMenu_Perfil eMenu_Perfil;
        NAuthentication nAuthentication;

        // GET: Authentication
        public ActionResult Index()
        {
            return View();
        }

        //-------------------Metodos

        [HttpPost]
        [Route("Loguin")]
        public ActionResult Usuario_por_Documento_Password(EUsuario_Login obj)

        {
            try
            {
                nUsuario = new NUsuario();
                eUsuario = new EUsuario();
                var existe_usuario = nUsuario.validar_existe_usuario_por_documento(obj);

                if (existe_usuario)
                {

                    eUsuario = nUsuario.Usuario_por_Documento_Password(obj);
                    if (eUsuario == null)
                    {

                        return new JsonResult { Data = new { resultado = false, codigo_error = 0, errortitulo = "Advertencia", mensaje = "Usuario " + obj.usuario + " Contraseña Incorrecta" }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                    }
                    else
                    {
                        return new JsonResult { Data = new { resultado = true, datos = eUsuario, JsonRequestBehavior = JsonRequestBehavior.AllowGet } };

                    }
                }
                else
                {
                    return new JsonResult { Data = new { resultado = false, codigo_error = 1, errortitulo = "Error", mensaje = "Usuario " + obj.usuario + " No Existe" }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
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


        // GET: Authentication
        public ActionResult RegisterUser()
        {
            return View();
        }

        //-------------------Metodos
        [HttpGet]
        [Route("Register")]
        public ActionResult Crear_Usuario_por_Documento(EUsuario obj)

        {
            try
            {
                nUsuario = new NUsuario();
                eUsuario = new EUsuario();
                eUsuario_Login = new EUsuario_Login();

                eUsuario_Login.usuario = obj.usuario;
                eUsuario_Login.contrasenia = obj.contrasenia;

                var existe_usuario = nUsuario.validar_existe_usuario_por_documento(eUsuario_Login);

                if (existe_usuario)
                {
                    HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    return new JsonResult { Data = new { status = "error", message = "Usuario Ya Existe" }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                }
                else
                {
                    HttpContext.Response.StatusCode = (int)HttpStatusCode.OK;
                    var crear_usuario = nUsuario.crear_usuario_documento(obj);

                    return new JsonResult { Data = crear_usuario, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
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


        [HttpGet]
        public ActionResult listar_menu_perfil(int codigo_perfil)
        {
            try
            {
                nAuthentication = new NAuthentication();

                var lista = nAuthentication.listar_menu_perfil(codigo_perfil);

                return new JsonResult { Data = lista, JsonRequestBehavior = JsonRequestBehavior.AllowGet };

            }
            catch (Exception ex)
            {
                //cls_nSeguridad = new NSeguridad();
                //string innerException = string.Empty;

                //if (ex.InnerException != null)
                //{
                //    innerException = ex.InnerException.Message;
                //}

                //cls_nSeguridad.insertar_log_error(new ELog_error()
                //{
                //    proceso = "seguridad/listar_menu_perfil",
                //    mensaje = ex.Message,
                //    inner_exepcion = innerException,
                //    stack_trace = ex.StackTrace,
                //    codigo_usuario = 0
                //});
                throw;
            }
        }
    }
}