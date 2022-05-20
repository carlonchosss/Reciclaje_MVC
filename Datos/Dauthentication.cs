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
    public class DAuthentication
    {
        public List<EMenu_Perfil> listar_menu_perfil(int codigo_perfil_usuario)
        {
            List<EMenu_Perfil> lista = new List<EMenu_Perfil>();

            try
            {
                using (IDbConnection cn = new DConexion().ConectarBD())
                {
                    cn.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("@codigo_perfil_usuario", codigo_perfil_usuario);

                    lista = cn.Query<EMenu_Perfil>("scc_sp_bo_listar_menu_perfil",
                                                   parameters,
                                                   commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return lista;
        }

    }
}
