using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class EMenu_Web
    {
        //Modulos
        public int codigo_menu { get; set; }
        public string descripcion { get; set; }
        public int codigo_padre { get; set; }
        public int orden { get; set; }
        public int nivel { get; set; }
        public string url { get; set; }
        public string icono { get; set; }
        public int codigo_usuario_creacion { get; set; }
        public DateTime fecha_creacion_registro { get; set; }
        public bool habilitado { get; set; }

        ////Herencia de 0 a muchos
        //public List<EPerfil_Usuario> ePerfil_Usuarios { get; set; }
    }
}
