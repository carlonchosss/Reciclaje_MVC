using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class ERegistro_Reciclaje
    {
        public int codigo_registro_reciclaje { get; set; }
        public int codigo_usuario { get; set; }
        public int cantidad_agrupado { get; set; }
        public string fecha_creacion_registro { get; set; }
        public bool habilitado { get; set; }
    }
}
