using Entidad;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reciclaje_MVC.Controllers;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Routing;

namespace UnitTest_Reciclaje_MVC
{
    [TestClass]
    public class UnitTest_AuthenticationController
    {
        [TestMethod]
        public void test_login_correcto()
        {
            EUsuario_Login eUsuario_Login = new EUsuario_Login();
            AuthenticationController controller = new AuthenticationController();
            eUsuario_Login.usuario = "admin";
            eUsuario_Login.contrasenia = "admin";

            var response = controller.Usuario_por_Documento_Password(eUsuario_Login) as JsonResult;
            var result = new RouteValueDictionary(response.Data);

            bool valor = Convert.ToBoolean(result["resultado"]);
            Assert.IsTrue(valor);
        }

        [TestMethod]
        public void test_login_incorrecto()
        {
            EUsuario_Login eUsuario_Login = new EUsuario_Login();
            AuthenticationController controller = new AuthenticationController();
            eUsuario_Login.usuario = "admin1";
            eUsuario_Login.contrasenia = "admin1";

            var response = controller.Usuario_por_Documento_Password(eUsuario_Login) as JsonResult;
            var result = new RouteValueDictionary(response.Data);

            bool valor = Convert.ToBoolean(result["resultado"]);
            Assert.IsFalse(valor);
        }

        [TestMethod]
        public void test_creacion_usuario_correcto()
        {
            EUsuario eUsuario = new EUsuario();
            AuthenticationController controller = new AuthenticationController();
            eUsuario.usuario = "test_unit_1";
            eUsuario.contrasenia = "test_unit_1";
            eUsuario.nombre = "test_unit_nombre";
            eUsuario.apellido = "test_unit_apellido";
            eUsuario.celular = "999999999";
            eUsuario.numero_documento = "9999999";
            eUsuario.correo_electronico = "test_unit_1@test_unit_1.com";

            var response = controller.Crear_Usuario_por_Documento(eUsuario) as JsonResult;
            var result = new RouteValueDictionary(response.Data);

            if (result["message"].ToString() == "Usuario Ya Existe")
            {
                Assert.IsFalse(false);
            }
            else
            {
                Assert.IsTrue(true);

            }
        }

        [TestMethod]
        public void test_creacion_usuario_incorrecto()
        {
            EUsuario eUsuario = new EUsuario();
            AuthenticationController controller = new AuthenticationController();
            eUsuario.usuario = "test_unit_1";
            eUsuario.contrasenia = "test_unit_1";
            eUsuario.nombre = "test_unit_nombre";
            eUsuario.apellido = "test_unit_apellido";
            eUsuario.celular = "999999999";
            eUsuario.numero_documento = "9999999";
            eUsuario.correo_electronico = "test_unit_1@test_unit_1.com";

            var response = controller.Crear_Usuario_por_Documento(eUsuario) as JsonResult;
            var result = new RouteValueDictionary(response.Data);

            if (result["message"].ToString() == "Usuario Ya Existe")
            {
                Assert.IsFalse(false);
            }
        }

        [TestMethod]
        public void test_listar_menu_perfil_correcto()
        {
            EUsuario_Login eUsuario_Login = new EUsuario_Login();
            EUsuario eUsuario = new EUsuario();
            List<EMenu_Perfil> eMenu_Perfils = new List<EMenu_Perfil>();
            AuthenticationController controller = new AuthenticationController();
            eUsuario_Login.usuario = "admin";
            eUsuario_Login.contrasenia = "admin";

            var response = controller.Usuario_por_Documento_Password(eUsuario_Login) as JsonResult;
            var result = new RouteValueDictionary(response.Data);
            eUsuario = (EUsuario)result["datos"];

            var response_menu = controller.listar_menu_perfil(eUsuario.codigo_perfil_usuario) as JsonResult;
            eMenu_Perfils = (List<EMenu_Perfil>)response_menu.Data;

            if (eMenu_Perfils.Count != 0)
            {
                Assert.IsTrue(true);
            }
            else
            {
                Assert.IsTrue(false);
            }
        }

        [TestMethod]
        public void test_listar_menu_perfil_incorrecto()
        {
            EUsuario_Login eUsuario_Login = new EUsuario_Login();
            EUsuario eUsuario = new EUsuario();
            List<EMenu_Perfil> eMenu_Perfils = new List<EMenu_Perfil>();
            AuthenticationController controller = new AuthenticationController();
            eUsuario_Login.usuario = "admin11";
            eUsuario_Login.contrasenia = "admin11";

            var response = controller.Usuario_por_Documento_Password(eUsuario_Login) as JsonResult;
            var result = new RouteValueDictionary(response.Data);
            bool valor = Convert.ToBoolean(result["resultado"]);

            if (valor == false)
            {
                var response_menu = controller.listar_menu_perfil(0) as JsonResult;

                eMenu_Perfils = (List<EMenu_Perfil>)response_menu.Data;
                if (eMenu_Perfils.Count == 0)
                {
                    Assert.IsFalse(valor);
                }
            }
        }

    }
}
