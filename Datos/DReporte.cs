﻿using Dapper;
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
    }
}
