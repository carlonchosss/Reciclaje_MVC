using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Entidad;

namespace Negocio
{
    public class NReporte
    {
        public List<EReporte_Empresa_Descuento> Obtener_Reporte_Empresa_Descuento(string fecha_inicio_reporte, string fecha_fin_reporte, string codigo_empresa_descuento) => new DReporte().Obtener_Reporte_Empresa_Descuento(fecha_inicio_reporte, fecha_fin_reporte, codigo_empresa_descuento);
    }
}
