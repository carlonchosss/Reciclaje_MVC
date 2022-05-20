using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class EProducto
    {
        public int codigo_producto { get; set; }
        public string descripcion_producto { get; set; }
        public int codigo_categoria { get; set; }
        public string descripcion_categoria { get; set; }
        public bool habilitado { get; set; }

    }
}
