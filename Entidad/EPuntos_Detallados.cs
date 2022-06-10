using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class EPuntos_Detallados
    {
        public int codigo_puntos_detallados { get; set; }
        public int codigo_usuario { get; set; }
        public int puntos_canjeados { get; set; }
        public decimal descuento_aplicado { get; set; }
        public int codigo_empresa_descuento { get; set; }
        public DateTime fecha_creacion_registro { get; set; }
        public bool habilitado { get; set; }

        public string descripcion_empresa_descuento { get; set; }
    }
}
