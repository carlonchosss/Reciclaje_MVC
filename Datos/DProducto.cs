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
    public class DProducto
    {
        //--------------------------------------------Categoria
        public List<ECategoria> Listar_Categorias()
        {
            List<ECategoria> obj_resultado;
            try
            {
                using (SqlConnection cn = new DConexion().ConectarBD())
                {
                    cn.Open();
                    obj_resultado = new List<ECategoria>();
                    var parameters = new DynamicParameters();
                    //parameters.Add("@usuario", obj.usuario);
                    //parameters.Add("@contrasenia", obj.contrasenia);
                    obj_resultado = cn.Query<ECategoria>("listar_categorias", parameters, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return obj_resultado;
        }
        public bool crear_categorias(ECategoria obj)
        {
            bool valor = false;
            try
            {
                using (SqlConnection cn = new DConexion().ConectarBD())
                {
                    cn.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("@descripcion_categoria", obj.descripcion_categoria);
                    valor = cn.Query<bool>("crear_categorias", parameters, commandType: CommandType.StoredProcedure).SingleOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return valor;
        }
        public bool actualizar_categorias(ECategoria obj)
        {
            bool valor = false;
            try
            {
                using (SqlConnection cn = new DConexion().ConectarBD())
                {
                    cn.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("@codigo_categoria", obj.codigo_categoria);
                    parameters.Add("@descripcion_categoria", obj.descripcion_categoria);
                    parameters.Add("@habilitado", obj.habilitado);

                    valor = cn.Query<bool>("actualizar_categorias", parameters, commandType: CommandType.StoredProcedure).SingleOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return valor;
        }
        public bool actualizar_estado_categoria(int obj)
        {
            bool valor = false;
            try
            {
                using (SqlConnection cn = new DConexion().ConectarBD())
                {
                    cn.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("@codigo_categoria", obj);
                    valor = cn.Query<bool>("actualizar_estado_categorias", parameters, commandType: CommandType.StoredProcedure).SingleOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return valor;
        }

        //--------------------------------------------Producto
        public List<EProducto> listar_producto()
        {
            List<EProducto> obj_resultado;
            try
            {
                using (SqlConnection cn = new DConexion().ConectarBD())
                {
                    cn.Open();
                    obj_resultado = new List<EProducto>();
                    var parameters = new DynamicParameters();
                    //parameters.Add("@usuario", obj.usuario);
                    //parameters.Add("@contrasenia", obj.contrasenia);
                    obj_resultado = cn.Query<EProducto>("listar_productos", parameters, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return obj_resultado;
        }
        public bool crear_producto(EProducto obj)
        {
            bool valor = false;
            try
            {
                using (SqlConnection cn = new DConexion().ConectarBD())
                {
                    cn.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("@descripcion_producto", obj.descripcion_producto);
                    parameters.Add("@codigo_categoria", obj.codigo_categoria);

                    valor = cn.Query<bool>("crear_producto", parameters, commandType: CommandType.StoredProcedure).SingleOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return valor;
        }
        public bool actualizar_producto(EProducto obj)
        {
            bool valor = false;
            try
            {
                using (SqlConnection cn = new DConexion().ConectarBD())
                {
                    cn.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("@descripcion_producto", obj.descripcion_producto);
                    parameters.Add("@codigo_categoria", obj.codigo_categoria);
                    parameters.Add("@habilitado", obj.habilitado);

                    parameters.Add("@codigo_producto", obj.codigo_producto);

                    valor = cn.Query<bool>("actualizar_Producto", parameters, commandType: CommandType.StoredProcedure).SingleOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return valor;
        }
        public bool actualizar_estado_producto(int obj)
        {
            bool valor = false;
            try
            {
                using (SqlConnection cn = new DConexion().ConectarBD())
                {
                    cn.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("@codigo_producto", obj);
                    valor = cn.Query<bool>("actualizar_estado_Producto", parameters, commandType: CommandType.StoredProcedure).SingleOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return valor;
        }

        public List<EProducto> listar_producto_categoria(int obj)
        {
            List<EProducto> obj_resultado;
            try
            {
                using (SqlConnection cn = new DConexion().ConectarBD())
                {
                    cn.Open();
                    obj_resultado = new List<EProducto>();
                    var parameters = new DynamicParameters();
                    parameters.Add("@codigo_categoria", obj);
                    obj_resultado = cn.Query<EProducto>("listar_productos_categoria", parameters, commandType: CommandType.StoredProcedure).ToList();
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
