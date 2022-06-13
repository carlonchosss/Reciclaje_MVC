using Entidad;
using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NProducto
    {
        //--------------------------------------------Categoria
        public List<ECategoria> Listar_Categorias() => new DProducto().Listar_Categorias();
        public List<ECategoria> Todo_Listar_Categorias() => new DProducto().Todo_Listar_Categorias();
        public bool crear_categorias(ECategoria obj) => new DProducto().crear_categorias(obj);
        public bool actualizar_categorias(ECategoria obj) => new DProducto().actualizar_categorias(obj);
        public bool actualizar_estado_categoria(int obj) => new DProducto().actualizar_estado_categoria(obj);

        //--------------------------------------------Producto
        public List<EProducto> Listar_Producto() => new DProducto().Listar_Producto();
        public List<EProducto> Todo_Listar_Producto() => new DProducto().Todo_Listar_Producto();

        public bool crear_producto(EProducto obj) => new DProducto().crear_producto(obj);
        public bool actualizar_producto(EProducto obj) => new DProducto().actualizar_producto(obj);
        public bool actualizar_estado_producto(int obj) => new DProducto().actualizar_estado_producto(obj);
        public List<EProducto> listar_producto_categoria(int obj) => new DProducto().listar_producto_categoria(obj);
    }

}
