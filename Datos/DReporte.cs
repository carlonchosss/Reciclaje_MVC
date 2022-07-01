using Dapper;
using Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DReporte
    {
        public List<EReporte_Empresa_Descuento> Obtener_Reporte_Empresa_Descuento(string fecha_inicio_reporte, string fecha_fin_reporte, string codigo_empresa_descuento)
        {
            List<EReporte_Empresa_Descuento> obj_resultado;
            try
            {
                using (SqlConnection cn = new DConexion().ConectarBD())
                {
                    cn.Open();
                    obj_resultado = new List<EReporte_Empresa_Descuento>();

                    var parameters = new DynamicParameters();
                    parameters.Add("@fecha_inicio", fecha_inicio_reporte);
                    parameters.Add("@fecha_fin", fecha_fin_reporte);
                    parameters.Add("@codigo_empresa_descuento", codigo_empresa_descuento);

                    obj_resultado = cn.Query<EReporte_Empresa_Descuento>("Obtener_Reporte_Empresa_Descuento", parameters, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return obj_resultado;
        }
        public List<EReporte_Categoria_Materiales> Obtener_Reporte_Categoria_Materiales(string fecha_inicio_reporte, string fecha_fin_reporte, string codigo_categoria, string codigo_producto, int tipo_reporte)
        {
            List<EReporte_Categoria_Materiales> obj_resultado;
            try
            {
                using (SqlConnection cn = new DConexion().ConectarBD())
                {
                    cn.Open();
                    obj_resultado = new List<EReporte_Categoria_Materiales>();

                    var parameters = new DynamicParameters();
                    parameters.Add("@fecha_inicio", fecha_inicio_reporte);
                    parameters.Add("@fecha_fin", fecha_fin_reporte);
                    parameters.Add("@codigo_categoria", codigo_categoria);
                    parameters.Add("@codigo_producto", codigo_producto);
                    parameters.Add("@tipo_reporte", tipo_reporte);

                    obj_resultado = cn.Query<EReporte_Categoria_Materiales>("Obtener_Reporte_Categoria_Materiales", parameters, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return obj_resultado;
        }
    }
}
