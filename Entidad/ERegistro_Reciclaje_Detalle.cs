using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class ERegistro_Reciclaje_Detalle
    {
        public int codigo_registro_reciclaje_detalle { get; set; }
        public int codigo_registro_reciclaje { get; set; }
        public int codigo_categoria { get; set; }
        public string descripcion_categoria { get; set; }
        public int codigo_producto { get; set; }
        public string descripcion_producto { get; set; }
        public int cantidad { get; set; }
        public DateTime fecha_creacion_registro { get; set; }
        public bool habilitado { get; set; }
    }
}
