using Datos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NReciclaje
    {
        #region  Reciclaje
        public int crear_reciclaje(string codigo_usuario, List<ERegistro_Reciclaje_Detalle> valor_detalle) => new DReciclaje().crear_reciclaje(codigo_usuario, valor_detalle);
        public List<ERegistro_Reciclaje> listar_reciclaje_usuario(int codigo_usuario) => new DReciclaje().listar_reciclaje_usuario(codigo_usuario);
        public List<ERegistro_Reciclaje_Detalle> listar_todo_reciclaje_usuario(int codigo_usuario) => new DReciclaje().listar_todo_reciclaje_usuario(codigo_usuario);
        #endregion

        #region  Empresa Descuento
        public List<EEmpresa_Descuento> Listar_Empresa_Descuento() => new DReciclaje().Listar_Empresa_Descuento();
        public bool crear_Empresa_Descuentos(EEmpresa_Descuento obj) => new DReciclaje().crear_Empresa_Descuentos(obj);
        public bool actualizar_empresa_descuento(EEmpresa_Descuento obj) => new DReciclaje().actualizar_empresa_descuento(obj);
        public bool actualizar_estado_empresa_descuento(int obj) => new DReciclaje().actualizar_estado_empresa_descuento(obj);
        public List<EEmpresa_Descuento> Listar_Empresa_Descuento_Reciclaje_cantidad(int codigo_usuario)=> new DReciclaje().Listar_Empresa_Descuento_Reciclaje_cantidad(codigo_usuario);
        #endregion

        #region  Puntos Reciclaje
        public int Mostrar_Puntos_Reciclaje(int codigo_usuario) => new DReciclaje().Mostrar_Puntos_Reciclaje(codigo_usuario);
        #endregion
    }
}
