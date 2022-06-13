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

        public List<EPerfil_Usuario> Todos_Listar_Perfiles()
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

    }
}
