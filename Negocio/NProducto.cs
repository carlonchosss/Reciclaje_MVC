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
        public bool crear_categorias(ECategoria obj) => new DProducto().crear_categorias(obj);
        public bool actualizar_categorias(ECategoria obj) => new DProducto().actualizar_categorias(obj);
        public bool actualizar_estado_categoria(int obj) => new DProducto().actualizar_estado_categoria(obj);

        //--------------------------------------------Producto
        public List<EProducto> listar_producto() => new DProducto().listar_producto();
        public bool crear_producto(EProducto obj) => new DProducto().crear_producto(obj);
        public bool actualizar_producto(EProducto obj) => new DProducto().actualizar_producto(obj);
        public bool actualizar_estado_producto(int obj) => new DProducto().actualizar_estado_producto(obj);
        public List<EProducto> listar_producto_categoria(int obj) => new DProducto().listar_producto_categoria(obj);
    }

}
