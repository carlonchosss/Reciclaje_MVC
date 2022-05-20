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

        
    }
}
