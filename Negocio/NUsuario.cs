using Datos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NUsuario
    {
        public bool validar_existe_usuario_por_documento(EUsuario_Login obj) => new DUsuario().validar_existe_usuario_por_documento(obj);

        public EUsuario Usuario_por_Documento_Password(EUsuario_Login obj) => new DUsuario().Usuario_por_Documento_Password(obj);

        public EUsuario crear_usuario_documento(EUsuario obj) => new DUsuario().crear_usuario_documento(obj);

        public List<EUsuario> listar_usuarios() => new DUsuario().listar_usuarios();
        public bool crear_usuario_sistema(EUsuario obj) => new DUsuario().crear_usuario_sistema(obj);
        public bool actualizar_usuario_sistema(EUsuario obj) => new DUsuario().actualizar_usuario_sistema(obj);
        public bool actualizar_estado_usuario_sistema(int obj) => new DUsuario().actualizar_estado_usuario_sistema(obj);

        #region Perfil Usuario
        // public List<EPerfil_Usuario> Listar_Perfiles() => new DUsuario().Listar_Perfiles();
        #endregion

        #region Rol
        public List<EPerfil_Usuario> Listar_Perfiles() => new DUsuario().Listar_Perfiles();
        public List<EPerfil_Usuario> Todo_Listar_Perfiles() => new DUsuario().Todo_Listar_Perfiles();
        public bool Registro_Perfil_Usuario(EPerfil_Usuario obj) => new DUsuario().Registro_Perfil_Usuario(obj);
        public EPerfil_Usuario Obtener_Perfil_Usuario(int obj) => new DUsuario().Obtener_Perfil_Usuario(obj);
        public bool Actualizar_Perfil_Usuario(EPerfil_Usuario obj) => new DUsuario().Actualizar_Perfil_Usuario(obj);
        public bool Actualizar_Estado_Perfil_Usuario(int obj) => new DUsuario().Actualizar_Estado_Perfil_Usuario(obj);

        #endregion
        #region Modulo
        public List<EMenu_Web> Listar_Menu_Web() => new DUsuario().Listar_Menu_Web();
        public List<EMenu_Web> Todo_Listar_Menu_Web() => new DUsuario().Todo_Listar_Menu_Web();
        public bool Registro_Modulo(EMenu_Web obj) => new DUsuario().Registro_Modulo(obj);
        public EMenu_Web Obtener_Modulo(int obj) => new DUsuario().Obtener_Modulo(obj);
        public bool Actualizar_Modulo(EMenu_Web obj) => new DUsuario().Actualizar_Modulo(obj);
        public bool Actualizar_Estado_Modulo(int obj) => new DUsuario().Actualizar_Estado_Modulo(obj);

        #endregion
        #region Acessos
        public List<EAcceso_Web> Listar_Acceso_Web() => new DUsuario().Listar_Acceso_Web();
        public List<EAcceso_Web> Todo_Listar_Acceso_Web() => new DUsuario().Todo_Listar_Acceso_Web();
        public  List<EPerfil_Usuario> Obtener_Lista_Acceso_Rol(int obj) => new DUsuario().Obtener_Lista_Acceso_Rol(obj);

        //public bool Registro_Acceso(EAcceso_Web obj) => new DUsuario().Registro_Acceso(obj);
        //public bool Actualizar_Acceso(EAcceso_Web obj) => new DUsuario().Actualizar_Acceso(obj);
        //public bool Actualizar_Estado_Acceso(int obj) => new DUsuario().Actualizar_Estado_Acceso(obj);
        #endregion
    }
}
