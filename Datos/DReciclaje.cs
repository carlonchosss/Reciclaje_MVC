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
    public class DReciclaje
    {
        #region  Reciclaje

        public int crear_reciclaje(string codigo_usuario, List<ERegistro_Reciclaje_Detalle> valor_detalle)
        {
            int codigo_reciclaje = 0;
            int codigo_reciclaje_detalle = 0;

            try
            {
                using (SqlConnection cn = new DConexion().ConectarBD())
                {
                    cn.Open();
                    using (var transaction = cn.BeginTransaction())
                    {
                        try
                        {
                            var parameters = new DynamicParameters();
                            parameters.Add("@codigo_usuario", codigo_usuario);
                            codigo_reciclaje = cn.Query<int>("crear_reciclaje", parameters, transaction: transaction, commandType: CommandType.StoredProcedure).SingleOrDefault();


                            foreach (var item_det in valor_detalle)
                            {
                                var parameters_d = new DynamicParameters();
                                parameters_d.Add("@codigo_registro_reciclaje", codigo_reciclaje);
                                parameters_d.Add("@codigo_categoria", item_det.codigo_categoria);
                                parameters_d.Add("@codigo_producto", item_det.codigo_producto);
                                parameters_d.Add("@cantidad", item_det.cantidad);

                                codigo_reciclaje_detalle = cn.Query<int>("crear_reciclaje_detalle", parameters_d, transaction: transaction, commandType: CommandType.StoredProcedure).SingleOrDefault();
                            }

                            var parameters_c = new DynamicParameters();
                            parameters_c.Add("@codigo_usuario", codigo_usuario);
                            parameters_c.Add("@puntos_reciclaje", valor_detalle.Count());
                            codigo_reciclaje = cn.Query<int>("actualizar_puntos_cliente_reciclaje", parameters_c, transaction: transaction, commandType: CommandType.StoredProcedure).SingleOrDefault();

                            transaction.Commit();
                        }
                        catch (Exception)
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return codigo_reciclaje;
        }

        public List<ERegistro_Reciclaje> listar_reciclaje_usuario(int codigo_usuario)
        {
            List<ERegistro_Reciclaje> obj_resultado;
            try
            {
                using (SqlConnection cn = new DConexion().ConectarBD())
                {
                    cn.Open();
                    obj_resultado = new List<ERegistro_Reciclaje>();
                    var parameters = new DynamicParameters();
                    parameters.Add("@codigo_usuario", codigo_usuario);
                    //parameters.Add("@contrasenia", obj.contrasenia);
                    obj_resultado = cn.Query<ERegistro_Reciclaje>("listar_reciclaje_usuario", parameters, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return obj_resultado;
        }

        public List<ERegistro_Reciclaje_Detalle> listar_todo_reciclaje_usuario(int codigo_usuario)
        {
            List<ERegistro_Reciclaje_Detalle> obj_resultado;
            try
            {
                using (SqlConnection cn = new DConexion().ConectarBD())
                {
                    cn.Open();
                    obj_resultado = new List<ERegistro_Reciclaje_Detalle>();
                    var parameters = new DynamicParameters();
                    parameters.Add("@codigo_usuario", codigo_usuario);
                    //parameters.Add("@contrasenia", obj.contrasenia);
                    obj_resultado = cn.Query<ERegistro_Reciclaje_Detalle>("listar_todo_reciclaje_usuario", parameters, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return obj_resultado;
        }
        #endregion

        #region  Empresa Descuento
        public List<EEmpresa_Descuento> Listar_Empresa_Descuento()
        {
            List<EEmpresa_Descuento> obj_resultado;
            try
            {
                using (SqlConnection cn = new DConexion().ConectarBD())
                {
                    cn.Open();
                    obj_resultado = new List<EEmpresa_Descuento>();
                    var parameters = new DynamicParameters();
                    //parameters.Add("@usuario", obj.usuario);
                    //parameters.Add("@contrasenia", obj.contrasenia);
                    obj_resultado = cn.Query<EEmpresa_Descuento>("listar_empresa_descuento", parameters, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return obj_resultado;
        }
        public bool crear_Empresa_Descuentos(EEmpresa_Descuento obj)
        {
            bool valor = false;
            try
            {
                using (SqlConnection cn = new DConexion().ConectarBD())
                {
                    cn.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("@descripcion_empresa_descuento", obj.descripcion_empresa_descuento);
                    parameters.Add("@descuento", obj.descuento);
                    parameters.Add("@stock", obj.stock);

                    valor = cn.Query<bool>("crear_empresa_descuentos", parameters, commandType: CommandType.StoredProcedure).SingleOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return valor;
        }

        public bool actualizar_empresa_descuento(EEmpresa_Descuento obj)
        {
            bool valor = false;
            try
            {
                using (SqlConnection cn = new DConexion().ConectarBD())
                {
                    cn.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("@codigo_empresa_descuento", obj.codigo_empresa_descuento);
                    parameters.Add("@descripcion_empresa_descuento", obj.descripcion_empresa_descuento);
                    parameters.Add("@descuento", obj.descuento);
                    parameters.Add("@stock", obj.stock);
                    parameters.Add("@habilitado", obj.habilitado);

                    valor = cn.Query<bool>("actualizar_empresa_descuento", parameters, commandType: CommandType.StoredProcedure).SingleOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return valor;
        }
        public bool actualizar_estado_empresa_descuento(int obj)
        {
            bool valor = false;
            try
            {
                using (SqlConnection cn = new DConexion().ConectarBD())
                {
                    cn.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("@codigo_empresa_descuento", obj);
                    valor = cn.Query<bool>("actualizar_estado_empresa_descuento", parameters, commandType: CommandType.StoredProcedure).SingleOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return valor;
        }


        public List<EEmpresa_Descuento> Listar_Empresa_Descuento_Reciclaje_cantidad(int codigo_usuario)
        {
            List<EEmpresa_Descuento> obj_resultado;
            try
            {
                using (SqlConnection cn = new DConexion().ConectarBD())
                {
                    cn.Open();
                    obj_resultado = new List<EEmpresa_Descuento>();
                    var parameters = new DynamicParameters();
                    parameters.Add("@codigo_usuario", codigo_usuario);
                    //parameters.Add("@contrasenia", obj.contrasenia);
                    obj_resultado = cn.Query<EEmpresa_Descuento>("listar_empresa_descuento_cantidad", parameters, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return obj_resultado;
        }

        #endregion

        public int Mostrar_Puntos_Reciclaje(int codigo_usuario)
        {
            int valor = 0;
            try
            {
                using (SqlConnection cn = new DConexion().ConectarBD())
                {
                    cn.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("@codigo_usuario", codigo_usuario);
                    valor = cn.Query<int>("mostrar_puntos_reciclaje", parameters, commandType: CommandType.StoredProcedure).SingleOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return valor;
        }
        public int guardar_puntos_descuento_reciclaje(EPuntos_Detallados obj)
        {
            int valor = 0;
            try
            {
                using (SqlConnection cn = new DConexion().ConectarBD())
                {
                    cn.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("@codigo_empresa_descuento", obj.codigo_empresa_descuento);
                    parameters.Add("@codigo_usuario", obj.codigo_usuario);
                    parameters.Add("@descuento_aplicado", obj.descuento_aplicado);
                    parameters.Add("@puntos_canjeados", obj.puntos_canjeados);
                    valor = cn.Query<int>("guardar_puntos_descuento_reciclaje", parameters, commandType: CommandType.StoredProcedure).SingleOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return valor;
        }
        public EPuntos_Detallados obtener_puntos_descuento_reciclaje(int codigo_detalle)
        {
            EPuntos_Detallados obj_resultado;
            try
            {
                using (SqlConnection cn = new DConexion().ConectarBD())
                {
                    cn.Open();
                    obj_resultado = new EPuntos_Detallados();
                    var parameters = new DynamicParameters();
                    parameters.Add("@codigo_detalle", codigo_detalle);
                    //parameters.Add("@contrasenia", obj.contrasenia);
                    obj_resultado = cn.Query<EPuntos_Detallados>("obtener_puntos_descuento_reciclaje", parameters, commandType: CommandType.StoredProcedure).SingleOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return obj_resultado;
        }
        public List<EPuntos_Detallados> listar_puntos_descuento_usuario(int codigo_usuario)
        {
            List < EPuntos_Detallados> obj_resultado;
            try
            {
                using (SqlConnection cn = new DConexion().ConectarBD())
                {
                    cn.Open();
                    obj_resultado = new List<EPuntos_Detallados>();
                    var parameters = new DynamicParameters();
                    parameters.Add("@codigo_usuario", codigo_usuario);
                    //parameters.Add("@contrasenia", obj.contrasenia);
                    obj_resultado = cn.Query<EPuntos_Detallados>("listar_puntos_descuento_reciclaje", parameters, commandType: CommandType.StoredProcedure).ToList();
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
