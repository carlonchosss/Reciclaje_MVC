using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DConexion
    {
        public SqlConnection ConectarBD()
        {
            SqlConnection cn = new SqlConnection();

            try
            {
                string server = ConfigurationManager.AppSettings["server"];
                string database = ConfigurationManager.AppSettings["bd"];
                string user = ConfigurationManager.AppSettings["usuario"];
                string password = ConfigurationManager.AppSettings["password"];
                string cadenaConexion = ConfigurationManager.ConnectionStrings["conexionBD"].ToString();
                cn.ConnectionString = string.Format(cadenaConexion, server, database, user, password);
            }
            catch (Exception e)
            {
                throw e;
            }
            return cn;
        }
    }
}
