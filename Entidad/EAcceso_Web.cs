using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class EAcceso_Web
    {
        //acceso a los permisos role
        public int codigo_acceso { get; set; }
        public int codigo_perfil_usuario { get; set; }
        public int codigo_menu { get; set; }
        public int? codigo_usuario_creacion { get; set; }
        public DateTime? fecha_creacion_registro { get; set; }
        public int? codigo_usuario_modificacion { get; set; }
        public DateTime? fecha_modificacion_registro { get; set; }
        public bool? habilitado { get; set; }

        ////Herencia de 0 a muchos
        //public virtual EMenu_Web eMenu_Web { get; set; }
        //public virtual EPerfil_Usuario ePerfil_Usuarios { get; set; }

    }
}
