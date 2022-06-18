using Dapper;
using Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DUsuario
    {
        public bool validar_existe_usuario_por_documento(EUsuario_Login obj)
        {
            bool valor = false;
            try
            {
                using (SqlConnection cn = new DConexion().ConectarBD())
                {
                    cn.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("@usuario", obj.usuario);
                    valor = cn.Query<bool>("validar_usuario_por_documento", parameters, commandType: CommandType.StoredProcedure).SingleOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return valor;
        }

        public EUsuario Usuario_por_Documento_Password(EUsuario_Login obj)
        {
            EUsuario obj_resultado;
            try
            {
                using (SqlConnection cn = new DConexion().ConectarBD())
                {
                    cn.Open();
                    obj_resultado = new EUsuario();
                    var parameters = new DynamicParameters();
                    parameters.Add("@usuario", obj.usuario);
                    parameters.Add("@contrasenia", obj.contrasenia);
                    obj_resultado = cn.Query<EUsuario>("Usuario_por_Documento_Password", parameters, commandType: CommandType.StoredProcedure).SingleOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return obj_resultado;
        }

        public EUsuario crear_usuario_documento(EUsuario obj)
        {
            EUsuario obj_resultado;
            try
            {
                using (SqlConnection cn = new DConexion().ConectarBD())
                {
                    cn.Open();
                    obj_resultado = new EUsuario();
                    var parameters = new DynamicParameters();
                    parameters.Add("@usuario", obj.usuario);
                    parameters.Add("@contrasenia", obj.contrasenia);
                    parameters.Add("@usuario", obj.usuario);
                    parameters.Add("@contrasenia", obj.contrasenia);
                    parameters.Add("@usuario", obj.usuario);
                    parameters.Add("@contrasenia", obj.contrasenia);
                    parameters.Add("@usuario", obj.usuario);
                    parameters.Add("@contrasenia", obj.contrasenia);
                    obj_resultado = cn.Query<EUsuario>("Crear_Usuario_por_Documento_Password", parameters, commandType: CommandType.StoredProcedure).SingleOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return obj_resultado;
        }


        public List<EUsuario> listar_usuarios()
        {
            List<EUsuario> obj_resultado;
            try
            {
                using (SqlConnection cn = new DConexion().ConectarBD())
                {
                    cn.Open();
                    obj_resultado = new List<EUsuario>();
                    var parameters = new DynamicParameters();
                    //parameters.Add("@usuario", obj.usuario);
                    //parameters.Add("@contrasenia", obj.contrasenia);
                    obj_resultado = cn.Query<EUsuario>("Listar_Usuarios_Sistema", parameters, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return obj_resultado;
        }

        public bool crear_usuario_sistema(EUsuario obj)
        {
            bool valor = false;
            try
            {
                using (SqlConnection cn = new DConexion().ConectarBD())
                {
                    cn.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("@nombre", obj.nombre);
                    parameters.Add("@apellido", obj.apellido);
                    parameters.Add("@celular", obj.celular);
                    parameters.Add("@numero_documento", obj.numero_documento);
                    parameters.Add("@correo_electronico", obj.correo_electronico);
                    parameters.Add("@usuario", obj.usuario);
                    parameters.Add("@contrasenia", obj.contrasenia);
                    parameters.Add("@codigo_perfil_usuario", obj.codigo_perfil_usuario);

                    valor = cn.Query<bool>("crear_usuario_sistema", parameters, commandType: CommandType.StoredProcedure).SingleOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return valor;
        }

        public bool actualizar_usuario_sistema(EUsuario obj)
        {
            bool valor = false;
            try
            {
                using (SqlConnection cn = new DConexion().ConectarBD())
                {
                    cn.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("@nombre", obj.nombre);
                    parameters.Add("@apellido", obj.apellido);
                    parameters.Add("@celular", obj.celular);
                    parameters.Add("@numero_documento", obj.numero_documento);
                    parameters.Add("@correo_electronico", obj.correo_electronico);
                    parameters.Add("@usuario", obj.usuario);
                    parameters.Add("@habilitado", obj.habilitado);
                    parameters.Add("@contrasenia", obj.contrasenia);
                    parameters.Add("@codigo_usuario", obj.codigo_usuario);
                    parameters.Add("@codigo_perfil_usuario", obj.codigo_perfil_usuario);

                    valor = cn.Query<bool>("actualizar_usuario_sistema", parameters, commandType: CommandType.StoredProcedure).SingleOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return valor;
        }
        public bool actualizar_estado_usuario_sistema(int obj)
        {
            bool valor = false;
            try
            {
                using (SqlConnection cn = new DConexion().ConectarBD())
                {
                    cn.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("@codigo_usuario", obj);
                    valor = cn.Query<bool>("actualizar_estado_usuario_sistema", parameters, commandType: CommandType.StoredProcedure).SingleOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return valor;
        }

        #region Rol
        public List<EPerfil_Usuario> Listar_Perfiles()
        {
            List<EPerfil_Usuario> obj_resultado;
            try
            {
                using (SqlConnection cn = new DConexion().ConectarBD())
                {
                    cn.Open();
                    obj_resultado = new List<EPerfil_Usuario>();
                    var parameters = new DynamicParameters();
                    //parameters.Add("@usuario", obj.usuario);
                    //parameters.Add("@contrasenia", obj.contrasenia);
                    obj_resultado = cn.Query<EPerfil_Usuario>("Listar_Perfiles_Sistema", parameters, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return obj_resultado;
        }

        public List<EPerfil_Usuario> Todo_Listar_Perfiles()
        {
            List<EPerfil_Usuario> obj_resultado;
            try
            {
                using (SqlConnection cn = new DConexion().ConectarBD())
                {
                    cn.Open();
                    obj_resultado = new List<EPerfil_Usuario>();
                    var parameters = new DynamicParameters();
                    //parameters.Add("@usuario", obj.usuario);
                    //parameters.Add("@contrasenia", obj.contrasenia);
                    obj_resultado = cn.Query<EPerfil_Usuario>("Todo_Listar_Perfiles_Sistema", parameters, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return obj_resultado;
        }
        public bool Registro_Perfil_Usuario(EPerfil_Usuario obj)
        {
            bool valor = false;
            try
            {
                using (SqlConnection cn = new DConexion().ConectarBD())
                {
                    cn.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("@descripcion_perfil_usuario", obj.descripcion_perfil_usuario);
                    valor = cn.Query<bool>("crear_registro_perfil_usuario", parameters, commandType: CommandType.StoredProcedure).SingleOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return valor;
        }
        public EPerfil_Usuario Obtener_Perfil_Usuario(int obj)
        {
            EPerfil_Usuario obj_resultado;
            try
            {
                using (SqlConnection cn = new DConexion().ConectarBD())
                {
                    cn.Open();
                    obj_resultado = new EPerfil_Usuario();
                    var parameters = new DynamicParameters();
                    parameters.Add("@codigo_perfil_usuario", obj);

                    obj_resultado = cn.Query<EPerfil_Usuario>("Obtener_Perfiles_Sistema", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return obj_resultado;
        }
        public bool Actualizar_Perfil_Usuario(EPerfil_Usuario obj)
        {
            bool valor = false;
            try
            {
                using (SqlConnection cn = new DConexion().ConectarBD())
                {
                    cn.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("@descripcion_perfil_usuario", obj.descripcion_perfil_usuario);
                    parameters.Add("@habilitado", obj.habilitado);
                    parameters.Add("@codigo_perfil_usuario", obj.codigo_perfil_usuario);

                    valor = cn.Query<bool>("Actualizar_Perfil_Usuario", parameters, commandType: CommandType.StoredProcedure).SingleOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return valor;
        }
        public bool Actualizar_Estado_Perfil_Usuario(int obj)
        {
            bool valor = false;
            try
            {
                using (SqlConnection cn = new DConexion().ConectarBD())
                {
                    cn.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("@codigo_perfil_usuario", obj);

                    valor = cn.Query<bool>("Actualizar_Estado_Perfil_Usuario", parameters, commandType: CommandType.StoredProcedure).SingleOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return valor;
        }

        #endregion

        #region Modulo
        public List<EMenu_Web> Listar_Menu_Web()
        {
            List<EMenu_Web> obj_resultado;
            try
            {
                using (SqlConnection cn = new DConexion().ConectarBD())
                {
                    cn.Open();
                    obj_resultado = new List<EMenu_Web>();
                    var parameters = new DynamicParameters();
                    //parameters.Add("@usuario", obj.usuario);
                    //parameters.Add("@contrasenia", obj.contrasenia);
                    obj_resultado = cn.Query<EMenu_Web>("Listar_Menu_Web_Sistema", parameters, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return obj_resultado;
        }

        public List<EMenu_Web> Todo_Listar_Menu_Web()
        {
            List<EMenu_Web> obj_resultado;
            try
            {
                using (SqlConnection cn = new DConexion().ConectarBD())
                {
                    cn.Open();
                    obj_resultado = new List<EMenu_Web>();
                    var parameters = new DynamicParameters();
                    //parameters.Add("@usuario", obj.usuario);
                    //parameters.Add("@contrasenia", obj.contrasenia);
                    obj_resultado = cn.Query<EMenu_Web>("Todo_Listar_Menu_Web_Sistema", parameters, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return obj_resultado;
        }
        public bool Registro_Modulo(EMenu_Web obj)
        {
            bool valor = false;
            try
            {
                using (SqlConnection cn = new DConexion().ConectarBD())
                {
                    cn.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("@descripcion", obj.descripcion);
                    parameters.Add("@url", obj.url);

                    valor = cn.Query<bool>("Registro_Menu_Web", parameters, commandType: CommandType.StoredProcedure).SingleOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return valor;
        }
        public EMenu_Web Obtener_Modulo(int obj)
        {
            EMenu_Web obj_resultado;
            try
            {
                using (SqlConnection cn = new DConexion().ConectarBD())
                {
                    cn.Open();
                    obj_resultado = new EMenu_Web();
                    var parameters = new DynamicParameters();
                    parameters.Add("@codigo_menu", obj);

                    obj_resultado = cn.Query<EMenu_Web>("Obtener_Menu_Web_Sistema", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return obj_resultado;
        }
        public bool Actualizar_Modulo(EMenu_Web obj)
        {
            bool valor = false;
            try
            {
                using (SqlConnection cn = new DConexion().ConectarBD())
                {
                    cn.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("@descripcion", obj.descripcion);
                    parameters.Add("@url", obj.url);
                    parameters.Add("@habilitado", obj.habilitado);
                    parameters.Add("@codigo_menu", obj.codigo_menu);
                  
                    valor = cn.Query<bool>("Actualizar_Menu_Web", parameters, commandType: CommandType.StoredProcedure).SingleOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return valor;
        }
        public bool Actualizar_Estado_Modulo(int obj)
        {
            bool valor = false;
            try
            {
                using (SqlConnection cn = new DConexion().ConectarBD())
                {
                    cn.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("@codigo_menu", obj);

                    valor = cn.Query<bool>("Actualizar_Estado_Menu_Web", parameters, commandType: CommandType.StoredProcedure).SingleOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return valor;
        }

        #endregion

        #region Acceso
        public List<EAcceso_Web> Listar_Acceso_Web()
        {
            List<EAcceso_Web> obj_resultado;
            try
            {
                using (SqlConnection cn = new DConexion().ConectarBD())
                {
                    cn.Open();
                    obj_resultado = new List<EAcceso_Web>();
                    var parameters = new DynamicParameters();
                    //parameters.Add("@usuario", obj.usuario);
                    //parameters.Add("@contrasenia", obj.contrasenia);
                    obj_resultado = cn.Query<EAcceso_Web>("Listar_Acceso_Web_Sistema", parameters, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return obj_resultado;
        }

        public List<EAcceso_Web> Todo_Listar_Acceso_Web()
        {
            List<EAcceso_Web> obj_resultado;
            try
            {
                using (SqlConnection cn = new DConexion().ConectarBD())
                {
                    cn.Open();
                    obj_resultado = new List<EAcceso_Web>();
                    var parameters = new DynamicParameters();
                    //parameters.Add("@usuario", obj.usuario);
                    //parameters.Add("@contrasenia", obj.contrasenia);
                    obj_resultado = cn.Query<EAcceso_Web>("Todo_Listar_Acceso_Web_Sistema", parameters, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return obj_resultado;
        }
        public List<EPerfil_Usuario> Obtener_Lista_Acceso_Rol(int obj)
        {
            List <EPerfil_Usuario> obj_resultado;
            try
            {
                using (SqlConnection cn = new DConexion().ConectarBD())
                {
                    cn.Open();
                    obj_resultado = new List<EPerfil_Usuario>();
                    var parameters = new DynamicParameters();
                    parameters.Add("@codigo_perfil_usuario", obj);

                    obj_resultado = cn.Query<EPerfil_Usuario>("Obtener_Lista_Acceso_Rol", parameters, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return obj_resultado;
        }


        //public bool Registro_Acceso(EAcceso_Web obj)
        //{
        //    bool valor = false;
        //    try
        //    {
        //        using (SqlConnection cn = new DConexion().ConectarBD())
        //        {
        //            cn.Open();
        //            var parameters = new DynamicParameters();
        //            parameters.Add("@descripcion", obj.descripcion);
        //            parameters.Add("@codigo_padre", obj.codigo_padre);
        //            parameters.Add("@orden", obj.orden);
        //            parameters.Add("@nivel", obj.nivel);
        //            parameters.Add("@url", obj.url);
        //            parameters.Add("@icono", obj.icono);

        //            valor = cn.Query<bool>("Registro_Acceso_Web", parameters, commandType: CommandType.StoredProcedure).SingleOrDefault();
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //    return valor;
        //}
        //public EAcceso_Web Obtener_Acceso(int obj)
        //{
        //    EAcceso_Web obj_resultado;
        //    try
        //    {
        //        using (SqlConnection cn = new DConexion().ConectarBD())
        //        {
        //            cn.Open();
        //            obj_resultado = new EAcceso_Web();
        //            var parameters = new DynamicParameters();
        //            parameters.Add("@codigo_perfil_usuario", obj);

        //            obj_resultado = cn.Query<EAcceso_Web>("Obtener_Acceso_Web_Sistema", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //    return obj_resultado;
        //}
        //public bool Actualizar_Acceso(EAcceso_Web obj)
        //{
        //    bool valor = false;
        //    try
        //    {
        //        using (SqlConnection cn = new DConexion().ConectarBD())
        //        {
        //            cn.Open();
        //            var parameters = new DynamicParameters();
        //            parameters.Add("@descripcion", obj.descripcion);
        //            parameters.Add("@codigo_padre", obj.codigo_padre);
        //            parameters.Add("@orden", obj.orden);
        //            parameters.Add("@nivel", obj.nivel);
        //            parameters.Add("@url", obj.url);
        //            parameters.Add("@icono", obj.icono);
        //            parameters.Add("@habilitado", obj.habilitado);
        //            parameters.Add("@codigo_menu", obj.codigo_menu);

        //            valor = cn.Query<bool>("Actualizar_Acceso_Web", parameters, commandType: CommandType.StoredProcedure).SingleOrDefault();
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //    return valor;
        //}
        //public bool Actualizar_Estado_Acceso(int obj)
        //{
        //    bool valor = false;
        //    try
        //    {
        //        using (SqlConnection cn = new DConexion().ConectarBD())
        //        {
        //            cn.Open();
        //            var parameters = new DynamicParameters();
        //            parameters.Add("@codigo_menu", obj);

        //            valor = cn.Query<bool>("Actualizar_Estado_Acceso_Web", parameters, commandType: CommandType.StoredProcedure).SingleOrDefault();
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //    return valor;
        //}

        #endregion
    }
}
