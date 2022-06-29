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
        EPerfil_Usuario ePerfil_Usuario;
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
                    Utilidades.Encrypt Encrypt = new Utilidades.Encrypt();
                    obj.contrasenia = Encrypt.Encrypt_MD5(obj.contrasenia);
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

                Utilidades.Encrypt Encrypt = new Utilidades.Encrypt();
                obj.contrasenia = Encrypt.Encrypt_MD5(obj.contrasenia);
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

        #region Rol
        public ActionResult Roles()
        {
            return View();
        }
        //-------------------Metodos
        [HttpPost]
        [Route("Listar_Perfiles")]
        public ActionResult Listar_Perfiles()

        {
            try
            {
                nUsuario = new NUsuario();

                var Listar_Perfiles = nUsuario.Listar_Perfiles();

                if (Listar_Perfiles.Count == 0)
                {
                    HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    return new JsonResult { Data = new { status = "Informativo", message = "No hay Datos" }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                }
                else
                {
                    return new JsonResult { Data = Listar_Perfiles, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
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
        [Route("Todo_Listar_Perfiles")]
        public ActionResult Todo_Listar_Perfiles()

        {
            try
            {
                nUsuario = new NUsuario();

                var Listar_Perfiles = nUsuario.Todo_Listar_Perfiles();
                //var Listar_Perfiless = nUsuario.Todo_Listar_Perfiles().ToList();
                // var Listar_Perfiless_habilitado = Listar_Perfiless.Where(x => x.habilitado == true).ToList();

                // var prueba =Listar_Perfiless_habilitado.Count();
                if (Listar_Perfiles.Count == 0)
                {
                    HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    return new JsonResult { Data = new { status = "Informativo", message = "No hay Datos" }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                }
                else
                {
                    return new JsonResult { Data = Listar_Perfiles, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                }
            }
            catch (Exception ex)
            {
                nUsuario = new NUsuario();
                HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return new JsonResult { Data = new { status = "Error - Servidor", message = ex }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }
        [HttpPost]
        [Route("Registro_Roles")]
        public ActionResult Registro_Roles(EPerfil_Usuario obj)

        {
            try
            {
                nUsuario = new NUsuario();
                ePerfil_Usuario = new EPerfil_Usuario();

                var crear_usuario = nUsuario.Registro_Perfil_Usuario(obj);

                if (crear_usuario)
                {

                    return new JsonResult { Data = new { resultado = true, titulo = "Éxito", mensaje = "Roles Creado Correctamente" }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                }
                else
                {
                    return new JsonResult { Data = new { resultado = false, codigo_error = 1, errortitulo = "Error", mensaje = "No Se Creo Roles" }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
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
        [Route("Obtener_Roles")]
        public ActionResult Obtener_Roles(int codigo_perfil_usuario)

        {
            try
            {
                nUsuario = new NUsuario();

                var Listar_Perfiles = nUsuario.Obtener_Perfil_Usuario(codigo_perfil_usuario);

                if (Listar_Perfiles == null)
                {
                    HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    return new JsonResult { Data = new { status = "Informativo", message = "No hay Datos" }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                }
                else
                {
                    return new JsonResult { Data = Listar_Perfiles, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
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
        [Route("Actualizar_Roles")]
        public ActionResult Actualizar_Roles(EPerfil_Usuario obj)

        {
            try
            {
                nUsuario = new NUsuario();
                eUsuario = new EUsuario();
                eUsuario_Login = new EUsuario_Login();

                var existe_usuario = nUsuario.Actualizar_Perfil_Usuario(obj);

                if (existe_usuario)
                {
                    return new JsonResult { Data = new { resultado = true, titulo = "Éxito", mensaje = "Rol Actualizado Correctamente" }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                }
                else
                {
                    return new JsonResult { Data = new { resultado = false, codigo_error = 1, errortitulo = "Error", mensaje = "Rol No Actualizado" }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
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
        [Route("Actualizar_Roles_Estado")]
        public ActionResult Actualizar_Roles_Estado(int codigo_rol)

        {
            try
            {
                nUsuario = new NUsuario();
                eUsuario = new EUsuario();
                eUsuario_Login = new EUsuario_Login();

                var existe_usuario = nUsuario.Actualizar_Estado_Perfil_Usuario(codigo_rol);

                if (existe_usuario)
                {
                    return new JsonResult { Data = new { resultado = true, titulo = "Éxito", mensaje = "Rol Actualizado Correctamente" }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                }
                else
                {
                    return new JsonResult { Data = new { resultado = false, codigo_error = 1, errortitulo = "Error", mensaje = "Rol No Actualizado" }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
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

        #endregion
        #region Modulo
   // [Authorize]
        public ActionResult Menu_Web()
        {
            return View();
        }
        //-------------------Metodos
        [HttpPost]
        [Route("Listar_Menu_Web")]
        public ActionResult Listar_Menu_Web()

        {
            try
            {
                nUsuario = new NUsuario();

                var Listar_Menu_Web = nUsuario.Listar_Menu_Web();

                if (Listar_Menu_Web.Count == 0)
                {
                    HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    return new JsonResult { Data = new { status = "Informativo", message = "No hay Datos" }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                }
                else
                {
                    return new JsonResult { Data = Listar_Menu_Web, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
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
        [Route("Todo_Listar_Menu_Web")]
        public ActionResult Todo_Listar_Menu_Web()

        {
            try
            {
                nUsuario = new NUsuario();

                var Listar_Menu_Web = nUsuario.Todo_Listar_Menu_Web();
                //var Listar_Menu_Webs = nUsuario.Todo_Listar_Menu_Web().ToList();
                // var Listar_Menu_Webs_habilitado = Listar_Menu_Webs.Where(x => x.habilitado == true).ToList();

                // var prueba =Listar_Menu_Webs_habilitado.Count();
                if (Listar_Menu_Web.Count == 0)
                {
                    HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    return new JsonResult { Data = new { status = "Informativo", message = "No hay Datos" }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                }
                else
                {
                    return new JsonResult { Data = Listar_Menu_Web, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                }
            }
            catch (Exception ex)
            {
                nUsuario = new NUsuario();
                HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return new JsonResult { Data = new { status = "Error - Servidor", message = ex }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }
        [HttpPost]
        [Route("Registro_Modulo")]
        public ActionResult Registro_Modulo(EMenu_Web obj)

        {
            try
            {
                nUsuario = new NUsuario();
                //eEMenu_Web = new EMenu_Web();

                var crear_usuario = nUsuario.Registro_Modulo(obj);

                if (crear_usuario)
                {

                    return new JsonResult { Data = new { resultado = true, titulo = "Éxito", mensaje = "Modulo Creado Correctamente" }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                }
                else
                {
                    return new JsonResult { Data = new { resultado = false, codigo_error = 1, errortitulo = "Error", mensaje = "No Se Creo Modulo" }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
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
        [Route("Obtener_Modulo")]
        public ActionResult Obtener_Modulo(int codigo_menu)

        {
            try
            {
                nUsuario = new NUsuario();

                var Listar_Menu_Web = nUsuario.Obtener_Modulo(codigo_menu);

                if (Listar_Menu_Web == null)
                {
                    HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    return new JsonResult { Data = new { status = "Informativo", message = "No hay Datos" }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                }
                else
                {
                    return new JsonResult { Data = Listar_Menu_Web, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
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
        [Route("Actualizar_Modulo")]
        public ActionResult Actualizar_Modulo(EMenu_Web obj)

        {
            try
            {
                nUsuario = new NUsuario();
                eUsuario = new EUsuario();
                eUsuario_Login = new EUsuario_Login();

                var existe_usuario = nUsuario.Actualizar_Modulo(obj);

                if (existe_usuario)
                {
                    return new JsonResult { Data = new { resultado = true, titulo = "Éxito", mensaje = "Rol Actualizado Correctamente" }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                }
                else
                {
                    return new JsonResult { Data = new { resultado = false, codigo_error = 1, errortitulo = "Error", mensaje = "Rol No Actualizado" }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
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
        [Route("Actualizar_Modulo_Estado")]
        public ActionResult Actualizar_Modulo_Estado(int codigo_menu)

        {
            try
            {
                nUsuario = new NUsuario();
                eUsuario = new EUsuario();
                eUsuario_Login = new EUsuario_Login();

                var existe_usuario = nUsuario.Actualizar_Estado_Modulo(codigo_menu);

                if (existe_usuario)
                {
                    return new JsonResult { Data = new { resultado = true, titulo = "Éxito", mensaje = "Rol Actualizado Correctamente" }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                }
                else
                {
                    return new JsonResult { Data = new { resultado = false, codigo_error = 1, errortitulo = "Error", mensaje = "Rol No Actualizado" }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
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
        [Route("Listar_Menu_Web_Parentesco")]
        public ActionResult Listar_Menu_Web_Parentesco()

        {
            try
            {
                nUsuario = new NUsuario();

                var Listar_Menu_Web = nUsuario.Listar_Menu_Web_Parentesco();

                if (Listar_Menu_Web.Count == 0)
                {
                    HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    return new JsonResult { Data = new { status = "Informativo", message = "No hay Datos" }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                }
                else
                {
                    return new JsonResult { Data = Listar_Menu_Web, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
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
        #endregion
        #region Acessos
        public ActionResult Acessos()
        {
            return View();
        }
        //-------------------Metodos
        [HttpPost]
        [Route("Listar_Acceso_Web")]
        public ActionResult Listar_Acceso_Web()

        {
            try
            {
                nUsuario = new NUsuario();

                var Listar_Acceso_Web = nUsuario.Listar_Acceso_Web();

                if (Listar_Acceso_Web.Count == 0)
                {
                    HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    return new JsonResult { Data = new { status = "Informativo", message = "No hay Datos" }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                }
                else
                {
                    return new JsonResult { Data = Listar_Acceso_Web, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
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
        [Route("Todo_Listar_Acceso_Web")]
        public ActionResult Todo_Listar_Acceso_Web()

        {
            try
            {
                nUsuario = new NUsuario();

                var Listar_Acceso_Web = nUsuario.Todo_Listar_Acceso_Web();
                //var Listar_Acceso_Webs = nUsuario.Todo_Listar_Acceso_Web().ToList();
                // var Listar_Acceso_Webs_habilitado = Listar_Acceso_Webs.Where(x => x.habilitado == true).ToList();

                // var prueba =Listar_Acceso_Webs_habilitado.Count();
                if (Listar_Acceso_Web.Count == 0)
                {
                    HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    return new JsonResult { Data = new { status = "Informativo", message = "No hay Datos" }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                }
                else
                {
                    return new JsonResult { Data = Listar_Acceso_Web, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                }
            }
            catch (Exception ex)
            {
                nUsuario = new NUsuario();
                HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return new JsonResult { Data = new { status = "Error - Servidor", message = ex }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }
        //[HttpPost]
        //[Route("Registro_Acceso")]
        //public ActionResult Registro_Acceso(EAcceso_Web obj)

        //{
        //    try
        //    {
        //        nUsuario = new NUsuario();
        //        //eEAcceso_Web = new EAcceso_Web();

        //        var crear_usuario = nUsuario.Registro_Acceso(obj);

        //        if (crear_usuario)
        //        {

        //            return new JsonResult { Data = new { resultado = true, titulo = "Éxito", mensaje = "Acceso Creado Correctamente" }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        //        }
        //        else
        //        {
        //            return new JsonResult { Data = new { resultado = false, codigo_error = 1, errortitulo = "Error", mensaje = "No Se Creo Acceso" }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        //nUsuario.insertar_log_error(new ELog_error()
        //        //{
        //        //    url_error = "Autenticacion/Loguin",
        //        //    descripcion_error = "Web externa RRHH: " + ex.Message
        //        //});

        //        //obj_resultado = new EResultado_transaccion();
        //        //obj_resultado.idrespuesta = 0;
        //        //obj_resultado.descripcion = "Ocurrió un error al iniciar sesión";
        //        HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        //        return new JsonResult
        //        {
        //            Data = new
        //            {
        //                status = "Error - Servidor",
        //                message = ex
        //            },
        //            JsonRequestBehavior = JsonRequestBehavior.AllowGet
        //        };
        //    }
        //}
        ////-------------------Metodos
        //[HttpPost]
        //[Route("Obtener_Acceso")]
        //public ActionResult Obtener_Acceso(int codigo_perfil_usuario)

        //{
        //    try
        //    {
        //        nUsuario = new NUsuario();

        //        var Listar_Acceso_Web = nUsuario.Obtener_Acceso(codigo_perfil_usuario);

        //        if (Listar_Acceso_Web == null)
        //        {
        //            HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        //            return new JsonResult { Data = new { status = "Informativo", message = "No hay Datos" }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        //        }
        //        else
        //        {
        //            return new JsonResult { Data = Listar_Acceso_Web, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        nUsuario = new NUsuario();
        //        HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        //        return new JsonResult { Data = new { status = "Error - Servidor", message = ex }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        //    }
        //}
        ////-------------------Metodos
        //[HttpPost]
        //[Route("Actualizar_Acceso")]
        //public ActionResult Actualizar_Acceso(EAcceso_Web obj)

        //{
        //    try
        //    {
        //        nUsuario = new NUsuario();
        //        eUsuario = new EUsuario();
        //        eUsuario_Login = new EUsuario_Login();

        //        var existe_usuario = nUsuario.Actualizar_Acceso(obj);

        //        if (existe_usuario)
        //        {
        //            return new JsonResult { Data = new { resultado = true, titulo = "Éxito", mensaje = "Rol Actualizado Correctamente" }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        //        }
        //        else
        //        {
        //            return new JsonResult { Data = new { resultado = false, codigo_error = 1, errortitulo = "Error", mensaje = "Rol No Actualizado" }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        nUsuario = new NUsuario();
        //        //nUsuario.insertar_log_error(new ELog_error()
        //        //{
        //        //    url_error = "Autenticacion/Loguin",
        //        //    descripcion_error = "Web externa RRHH: " + ex.Message
        //        //});

        //        //obj_resultado = new EResultado_transaccion();
        //        //obj_resultado.idrespuesta = 0;
        //        //obj_resultado.descripcion = "Ocurrió un error al iniciar sesión";
        //        HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        //        return new JsonResult { Data = new { status = "Error - Servidor", message = ex }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        //    }
        //}
        ////-------------------Metodos
        //[HttpPost]
        //[Route("Actualizar_Acceso_Estado")]
        //public ActionResult Actualizar_Acceso_Estado(int codigo_rol)

        //{
        //    try
        //    {
        //        nUsuario = new NUsuario();
        //        eUsuario = new EUsuario();
        //        eUsuario_Login = new EUsuario_Login();

        //        var existe_usuario = nUsuario.Actualizar_Estado_Acceso(codigo_rol);

        //        if (existe_usuario)
        //        {
        //            return new JsonResult { Data = new { resultado = true, titulo = "Éxito", mensaje = "Rol Actualizado Correctamente" }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        //        }
        //        else
        //        {
        //            return new JsonResult { Data = new { resultado = false, codigo_error = 1, errortitulo = "Error", mensaje = "Rol No Actualizado" }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        nUsuario = new NUsuario();
        //        //nUsuario.insertar_log_error(new ELog_error()
        //        //{
        //        //    url_error = "Autenticacion/Loguin",
        //        //    descripcion_error = "Web externa RRHH: " + ex.Message
        //        //});

        //        //obj_resultado = new EResultado_transaccion();
        //        //obj_resultado.idrespuesta = 0;
        //        //obj_resultado.descripcion = "Ocurrió un error al iniciar sesión";
        //        HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        //        return new JsonResult { Data = new { status = "Error - Servidor", message = ex }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        //    }
        //}
        #endregion
    }
}