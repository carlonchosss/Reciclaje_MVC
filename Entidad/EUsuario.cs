using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class EUsuario
    {
        public int codigo_usuario { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string celular { get; set; }
        public string numero_documento { get; set; }
        public string correo_electronico { get; set; }
        public string usuario { get; set; }
        public string contrasenia { get; set; }
        public int codigo_perfil_usuario { get; set; }
        public int codigo_tipo_configuracion_sistema { get; set; }
        public DateTime? fecha_cambio_contrasenia { get; set; }
        public DateTime? fecha_creacion_registro { get; set; }
        public bool habilitado { get; set; }

    }
}
