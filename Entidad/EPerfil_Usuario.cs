using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class EPerfil_Usuario
    {
        public int codigo_perfil_usuario { get; set; }
        public string descripcion_perfil_usuario { get; set; }
        public DateTime? fecha_creacion_registro { get; set; }
        public bool habilitado { get; set; }
    }
}
