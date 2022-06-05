using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
   public  class EEmpresa_Descuento
    {
        public int codigo_empresa_descuento { get; set; }
        public string descripcion_empresa_descuento { get; set; }
        public decimal descuento { get; set; }
        public int stock { get; set; }
        public bool habilitado { get; set; }
    }
}
