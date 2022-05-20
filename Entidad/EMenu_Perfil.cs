using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class EMenu_Perfil
    {
        public int codigo_menu { get; set; }
        public int nivel { get; set; }
        public string descripcion { get; set; }
        public string icono { get; set; }
        public string url { get; set; }
        public int codigo_padre { get; set; }
    }
}
