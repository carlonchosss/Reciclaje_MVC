using Entidad;
using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NAuthentication
    {
        //public List<EMenu_perfil> listar_menu_perfil(int codigo_perfil_usuario)
        //{
        //    return new DSeguridad().listar_menu_perfil(codigo_perfil_usuario);
        //}
        public List<EMenu_Perfil> listar_menu_perfil(int codigo_perfil_usuario) => new DAuthentication().listar_menu_perfil(codigo_perfil_usuario);


    }
}
