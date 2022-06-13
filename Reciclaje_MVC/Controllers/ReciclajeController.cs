using Entidad;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Negocio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Reciclaje_MVC.Controllers
{
    public class ReciclajeController : Controller
    {
        NProducto nProducto;
        NReciclaje nReciclaje;
        ECategoria eCategoria;
        EProducto eProducto;
        EEmpresa_Descuento eEmpresa_Descuento;
        EPuntos_Detallados ePuntos_Detallados;

        // GET: Reciclaje
        public ActionResult Index()
        {
            return View();
        }

        //-------------------Metodos
        [HttpPost]
        [Route("Listar_Producto_Categoria")]
        public ActionResult Listar_Producto_Categoria(int codigo_categoria)

        {
            try
            {
                nProducto = new NProducto();
                eProducto = new EProducto();

                var existe_usuario = nProducto.listar_producto_categoria(codigo_categoria);

                //if (existe_usuario.Count == 0)
                //{
                //    HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                //    return new JsonResult { Data = new { status = "Informativo", message = "No hay Datos" }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                //}
                //else
                //{
                return new JsonResult { Data = existe_usuario, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                //}
            }
            catch (Exception ex)
            {
                HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return new JsonResult { Data = new { status = "Error - Servidor", message = ex }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }

        //-------------------Metodos
        [HttpPost]
        [Route("Guardar_reciclaje")]

        public ActionResult Guardar_reciclaje(string codigo_usuario, List<ERegistro_Reciclaje_Detalle> valor_detalle)

        {
            try
            {

                nReciclaje = new NReciclaje();
                var crear_usuario = nReciclaje.crear_reciclaje(codigo_usuario, valor_detalle);

                if (crear_usuario > 0)
                {

                    return new JsonResult { Data = new { resultado = true, titulo = "Éxito", mensaje = "Reciclaje Creado Correctamente" }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                }
                else
                {
                    return new JsonResult { Data = new { resultado = false, codigo_error = 1, errortitulo = "Error", mensaje = "No Se Creo Reciclaje" }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                }
            }
            catch (Exception ex)
            {
                //nUsuario.insertar_log_error(new ELog_error()
                //{
                //    url_error = "Autenticacion/Loguin",
                //    descripcion_error = "Web externa RRHH: " + ex.Message
                //});

                //obj_resultado = new EResultado_transaccion();
                //obj_resultado.idrespuesta = 0;
                //obj_resultado.descripcion = "Ocurrió un error al iniciar sesión";
                HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return new JsonResult
                {
                    Data = new
                    {
                        status = "Error - Servidor",
                        message = ex
                    },
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }
        }

        //-------------------Metodos
        [HttpPost]
        [Route("Listar_Reciclaje_Usuario")]
        public ActionResult Listar_Reciclaje_Usuario(int codigo_usuario)

        {
            try
            {
                nReciclaje = new NReciclaje();

                var existe_usuario = nReciclaje.listar_reciclaje_usuario(codigo_usuario);

                //if (existe_usuario.Count == 0)
                //{
                //    HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                //    return new JsonResult { Data = new { status = "Informativo", message = "No hay Datos" }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                //}
                //else
                //{
                return new JsonResult { Data = existe_usuario, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                //}
            }
            catch (Exception ex)
            {
                HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return new JsonResult { Data = new { status = "Error - Servidor", message = ex }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }

        //-------------------Metodos
        [HttpPost]
        [Route("Listar_Todo_Reciclaje_Usuario")]
        public ActionResult Listar_Todo_Reciclaje_Usuario(int codigo_usuario)

        {
            try
            {
                nReciclaje = new NReciclaje();

                var existe_usuario = nReciclaje.listar_todo_reciclaje_usuario(codigo_usuario);

                //if (existe_usuario.Count == 0)
                //{
                //    HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                //    return new JsonResult { Data = new { status = "Informativo", message = "No hay Datos" }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                //}
                //else
                //{
                return new JsonResult { Data = existe_usuario, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                //}
            }
            catch (Exception ex)
            {
                HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return new JsonResult { Data = new { status = "Error - Servidor", message = ex }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }


        //--------------------------------------------------------------------EmpresaDescuento
        public ActionResult EmpresaDescuento()
        {
            return View();
        }

        //-------------------Metodos
        [HttpPost]
        [Route("Listar_Empresa_Descuento")]
        public ActionResult Listar_Empresa_Descuento()

        {
            try
            {
                nReciclaje = new NReciclaje();
                eEmpresa_Descuento = new EEmpresa_Descuento();

                var existe_usuario = nReciclaje.Listar_Empresa_Descuento();

                if (existe_usuario.Count == 0)
                {
                    HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    return new JsonResult { Data = new { status = "Informativo", message = "No hay Datos" }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                }
                else
                {
                    return new JsonResult { Data = existe_usuario, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                }
            }
            catch (Exception ex)
            {
                HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return new JsonResult { Data = new { status = "Error - Servidor", message = ex }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }

        //-------------------Metodos
        [HttpPost]
        [Route("Registro_Empresa_Descuento")]
        public ActionResult Registro_Empresa_Descuento(EEmpresa_Descuento obj)

        {
            try
            {
                nReciclaje = new NReciclaje();
                eEmpresa_Descuento = new EEmpresa_Descuento();

                var crear_usuario = nReciclaje.crear_Empresa_Descuentos(obj);

                if (crear_usuario)
                {

                    return new JsonResult { Data = new { resultado = true, titulo = "Éxito", mensaje = "Empresa Descuento Creado Correctamente" }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                }
                else
                {
                    return new JsonResult { Data = new { resultado = false, codigo_error = 1, errortitulo = "Error", mensaje = "No Se Creo Empresa Descuento" }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                }
            }
            catch (Exception ex)
            {
                //nUsuario.insertar_log_error(new ELog_error()
                //{
                //    url_error = "Autenticacion/Loguin",
                //    descripcion_error = "Web externa RRHH: " + ex.Message
                //});

                //obj_resultado = new EResultado_transaccion();
                //obj_resultado.idrespuesta = 0;
                //obj_resultado.descripcion = "Ocurrió un error al iniciar sesión";
                HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return new JsonResult
                {
                    Data = new
                    {
                        status = "Error - Servidor",
                        message = ex
                    },
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }
        }


        //-------------------Metodos
        [HttpPost]
        [Route("Actualizar_Empresa_Descuento")]
        public ActionResult Actualizar_Empresa_Descuento(EEmpresa_Descuento obj)

        {
            try
            {
                nReciclaje = new NReciclaje();
                eEmpresa_Descuento = new EEmpresa_Descuento();


                var existe_usuario = nReciclaje.actualizar_empresa_descuento(obj);

                if (existe_usuario)
                {
                    return new JsonResult { Data = new { resultado = true, titulo = "Éxito", mensaje = "Empresa Descuento Actualizado Correctamente" }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                }
                else
                {
                    return new JsonResult { Data = new { resultado = false, codigo_error = 1, errortitulo = "Error", mensaje = "Empresa Descuento No Actualizado" }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                }
            }
            catch (Exception ex)
            {
                //nUsuario.insertar_log_error(new ELog_error()
                //{
                //    url_error = "Autenticacion/Loguin",
                //    descripcion_error = "Web externa RRHH: " + ex.Message
                //});

                //obj_resultado = new EResultado_transaccion();
                //obj_resultado.idrespuesta = 0;
                //obj_resultado.descripcion = "Ocurrió un error al iniciar sesión";
                HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return new JsonResult { Data = new { status = "Error - Servidor", message = ex }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }
        //-------------------Metodos
        [HttpPost]
        [Route("Actualizar_Estado_Empresa_Descuento")]
        public ActionResult Actualizar_Estado_Empresa_Descuento(int codigo_empresa_descuento)

        {
            try
            {
                nReciclaje = new NReciclaje();
                eEmpresa_Descuento = new EEmpresa_Descuento();


                var existe_usuario = nReciclaje.actualizar_estado_empresa_descuento(codigo_empresa_descuento);

                if (existe_usuario)
                {
                    return new JsonResult { Data = new { resultado = true, titulo = "Éxito", mensaje = "Empresa Descuento Actualizado Correctamente" }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                }
                else
                {
                    return new JsonResult { Data = new { resultado = false, codigo_error = 1, errortitulo = "Error", mensaje = "Empresa Descuento No Actualizado" }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                }
            }
            catch (Exception ex)
            {
                //nUsuario = new NUsuario();
                //nUsuario.insertar_log_error(new ELog_error()
                //{
                //    url_error = "Autenticacion/Loguin",
                //    descripcion_error = "Web externa RRHH: " + ex.Message
                //});

                //obj_resultado = new EResultado_transaccion();
                //obj_resultado.idrespuesta = 0;
                //obj_resultado.descripcion = "Ocurrió un error al iniciar sesión";
                HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return new JsonResult { Data = new { status = "Error - Servidor", message = ex }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }

        [HttpPost]
        [Route("Mostrar_Puntos_Reciclaje")]
        public ActionResult Mostrar_Puntos_Reciclaje(int codigo_usuario)

        {
            try
            {
                nReciclaje = new NReciclaje();

                var existe_usuario = nReciclaje.Mostrar_Puntos_Reciclaje(codigo_usuario);

                //if (existe_usuario.Count == 0)
                //{
                //    HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                //    return new JsonResult { Data = new { status = "Informativo", message = "No hay Datos" }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                //}
                //else
                //{
                return new JsonResult { Data = existe_usuario, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                //}
            }
            catch (Exception ex)
            {
                HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return new JsonResult { Data = new { status = "Error - Servidor", message = ex }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }


        [HttpPost]
        [Route("Listar_Empresa_Descuento_Reciclaje_cantidad")]
        public ActionResult Listar_Empresa_Descuento_Reciclaje_cantidad(int codigo_usuario)

        {
            try
            {
                nReciclaje = new NReciclaje();

                var existe_usuario = nReciclaje.Listar_Empresa_Descuento_Reciclaje_cantidad(codigo_usuario);

                //if (existe_usuario.Count == 0)
                //{
                //    HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                //    return new JsonResult { Data = new { status = "Informativo", message = "No hay Datos" }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                //}
                //else
                //{
                return new JsonResult { Data = existe_usuario, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                //}
            }
            catch (Exception ex)
            {
                HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return new JsonResult { Data = new { status = "Error - Servidor", message = ex }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }




        //-------------------Metodos
        [HttpPost]
        [Route("guardar_puntos_descuento_reciclaje")]
        public ActionResult guardar_puntos_descuento_reciclaje(EPuntos_Detallados obj)

        {
            try
            {
                nReciclaje = new NReciclaje();
                ePuntos_Detallados = new EPuntos_Detallados();

                var crear_usuario = nReciclaje.guardar_puntos_descuento_reciclaje(obj);

                if (crear_usuario != 0)
                {
                    var obj_pdf = nReciclaje.obtener_puntos_descuento_reciclaje(crear_usuario);

                    var fexportado = formato_pdf_exportado_reciclaje_canjeado(obj_pdf);

                    var nombrepdfs = obj_pdf.numero_documento + "_" + DateTime.Now.ToString("ddMMyyy_hhmmss");

                    return new JsonResult { Data = new { resultado = true, titulo = "Éxito", nombrepdf = nombrepdfs, base64 = fexportado }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                }

                else
                {
                    return new JsonResult { Data = new { resultado = false, codigo_error = 1, errortitulo = "Error", mensaje = "No Se Creo Puntos Descuento" }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                }
            }
            catch (Exception ex)
            {
                //nUsuario.insertar_log_error(new ELog_error()
                //{
                //    url_error = "Autenticacion/Loguin",
                //    descripcion_error = "Web externa RRHH: " + ex.Message
                //});

                //obj_resultado = new EResultado_transaccion();
                //obj_resultado.idrespuesta = 0;
                //obj_resultado.descripcion = "Ocurrió un error al iniciar sesión";
                HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return new JsonResult
                {
                    Data = new
                    {
                        status = "Error - Servidor",
                        message = ex
                    },
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }
        }

        //-------------------Metodos
        [HttpPost]
        [Route("obtener_puntos_descuento_reciclaje")]
        public ActionResult obtener_puntos_descuento_reciclaje(int codigo_detalle)

        {
            try
            {
                nReciclaje = new NReciclaje();
                ePuntos_Detallados = new EPuntos_Detallados();

                var obj_pdf = nReciclaje.obtener_puntos_descuento_reciclaje(codigo_detalle);

                if (obj_pdf != null)
                {
                    var pdf_exportado = formato_pdf_exportado_reciclaje_canjeado(obj_pdf);

                    var nombre_pdfs = obj_pdf.numero_documento + "_" + DateTime.Now.ToString("ddMMyyy_hhmmss");

                    return new JsonResult { Data = new { resultado = true, titulo = "Éxito", nombrepdf = nombre_pdfs, base64 = pdf_exportado }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                }

                else
                {
                    return new JsonResult { Data = new { resultado = false, codigo_error = 1, errortitulo = "Error", mensaje = "No Se pudo Exportar Puntos Descuento" }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                }
            }
            catch (Exception ex)
            {
                //nUsuario.insertar_log_error(new ELog_error()
                //{
                //    url_error = "Autenticacion/Loguin",
                //    descripcion_error = "Web externa RRHH: " + ex.Message
                //});

                //obj_resultado = new EResultado_transaccion();
                //obj_resultado.idrespuesta = 0;
                //obj_resultado.descripcion = "Ocurrió un error al iniciar sesión";
                HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return new JsonResult
                {
                    Data = new
                    {
                        status = "Error - Servidor",
                        message = ex
                    },
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }
        }


        public string formato_pdf_exportado_reciclaje_canjeado(EPuntos_Detallados puntos_datos)
        {
            Document doc = new Document();

            //se utiliza medida points
            // doc.SetPageSize(PageSize.A4);
            doc.SetPageSize(new Rectangle(226.772f, 326.772f));

            // doc.SetMargins(226.772f, 226.772f, 226.772f, 226.772f);
            MemoryStream memoryStream = new MemoryStream();
            PdfWriter writer = PdfWriter.GetInstance(doc, memoryStream);
            doc.AddAuthor("CJG - ECL");
            doc.AddTitle(puntos_datos.numero_documento);
            doc.Open();

            //base de titulo
            BaseFont base_titulo = BaseFont.CreateFont(BaseFont.COURIER, BaseFont.CP1250, true);
            Font titulo_fuente = new Font(base_titulo, 9f, Font.BOLD, BaseColor.BLACK);

            BaseFont base_sub_titulo = BaseFont.CreateFont(BaseFont.COURIER, BaseFont.CP1250, true);
            Font sub_titulo_fuente = new Font(base_sub_titulo, 7f, Font.BOLD, BaseColor.BLACK);

            BaseFont base_titulo_tabla = BaseFont.CreateFont(BaseFont.COURIER, BaseFont.CP1250, true);
            Font titulo_tabla_fuente = new Font(base_titulo_tabla, 7f, Font.BOLD, BaseColor.BLACK);

            BaseFont base_parrafo = BaseFont.CreateFont(BaseFont.COURIER, BaseFont.CP1250, true);
            Font parrafo_fuente = new Font(base_parrafo, 7f, Font.NORMAL, BaseColor.BLACK);

            BaseFont base_detalle = BaseFont.CreateFont(BaseFont.COURIER, BaseFont.CP1250, true);
            Font detalle_fuente = new Font(base_detalle, 7f, Font.NORMAL, BaseColor.BLACK);

            string ruta_clave_privada_SSH = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory + "assets\\media\\reciclaje\\", "logo_sin_texto_color.png");

            Image img = Image.GetInstance(ruta_clave_privada_SSH);
            img.ScalePercent(15f);

            //aca se esta dando el tamaño de la tabla y el procentaje de la hoja
            var tabla = new PdfPTable(new float[] { 100f }) { WidthPercentage = 100 };
            tabla.AddCell(new PdfPCell(new Phrase("Sistema de reciclaje", titulo_fuente)) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_CENTER });
            tabla.AddCell(new PdfPCell(img) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_CENTER });
            doc.Add(tabla);

            tabla = new PdfPTable(new float[] { 50f, 50f }) { WidthPercentage = 100 };

            tabla.AddCell(new PdfPCell(new Phrase("Ticket De Descuento", sub_titulo_fuente)) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_CENTER, Colspan = 2 });
            tabla.AddCell(new PdfPCell(new Phrase("Cod. Ticket:", sub_titulo_fuente)) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
            tabla.AddCell(new PdfPCell(new Phrase(puntos_datos.codigo_puntos_detallados.ToString(), parrafo_fuente)) { Border = 0, HorizontalAlignment = Element.ALIGN_MIDDLE });

            tabla.AddCell(new PdfPCell(new Phrase("Cod. Cliente:", sub_titulo_fuente)) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
            tabla.AddCell(new PdfPCell(new Phrase(puntos_datos.codigo_usuario.ToString(), parrafo_fuente)) { Border = 0, HorizontalAlignment = Element.ALIGN_MIDDLE });

            tabla.AddCell(new PdfPCell(new Phrase("Num. Doc:", sub_titulo_fuente)) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
            tabla.AddCell(new PdfPCell(new Phrase(puntos_datos.numero_documento.ToString(), parrafo_fuente)) { Border = 0, HorizontalAlignment = Element.ALIGN_MIDDLE });

            tabla.AddCell(new PdfPCell(new Phrase("Fecha/Hora:", sub_titulo_fuente)) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
            tabla.AddCell(new PdfPCell(new Phrase(puntos_datos.fecha_creacion_registro, parrafo_fuente)) { Border = 0, HorizontalAlignment = Element.ALIGN_MIDDLE });
            doc.Add(tabla);

            doc.Add(new Paragraph(" "));

            //columna
            tabla = new PdfPTable(new float[] { 50f, 50f, 50f }) { WidthPercentage = 100 };
            tabla.AddCell(new PdfPCell(new Phrase("Cantidad", titulo_tabla_fuente)) { Border = 0, HorizontalAlignment = Element.ALIGN_MIDDLE });
            tabla.AddCell(new PdfPCell(new Phrase("Descripcion", titulo_tabla_fuente)) { Border = 0, HorizontalAlignment = Element.ALIGN_MIDDLE });
            tabla.AddCell(new PdfPCell(new Phrase("Descuento", titulo_tabla_fuente)) { Border = 0, HorizontalAlignment = Element.ALIGN_MIDDLE });

            //detalle
            tabla.AddCell(new PdfPCell(new Phrase("1", parrafo_fuente)) { Border = 0, HorizontalAlignment = Element.ALIGN_MIDDLE });
            tabla.AddCell(new PdfPCell(new Phrase(puntos_datos.descripcion_empresa_descuento.ToString(), parrafo_fuente)) { Border = 0, HorizontalAlignment = Element.ALIGN_MIDDLE });
            tabla.AddCell(new PdfPCell(new Phrase(puntos_datos.descuento_aplicado.ToString() +" %" , parrafo_fuente)) { Border = 0, HorizontalAlignment = Element.ALIGN_MIDDLE });
            doc.Add(tabla);

            writer.CloseStream = false;
            doc.Close();

            //poner siempre el memoryStream.Position al ultimo si el pdf no funciona
            memoryStream.Position = 0;
            //return File(memoryStream, "application/pdf");

            var file = Convert.ToBase64String(memoryStream.ToArray());

            return file;
        }
    }
}
// [HttpPost]
//[Route("exportar_pdf_reciclaje_cliente_puntos")]
////public ActionResult exportar_pdf_reciclaje_cliente_puntos(int codigo_usuario)
//public ActionResult exportar_pdf_reciclaje_cliente_puntos()

//{
//    Document doc = new Document();

//    //se utiliza medida points
//    // doc.SetPageSize(PageSize.A4);
//    doc.SetPageSize(new Rectangle(226.772f, 326.772f));

//    // doc.SetMargins(226.772f, 226.772f, 226.772f, 226.772f);
//    MemoryStream memoryStream = new MemoryStream();
//    PdfWriter writer = PdfWriter.GetInstance(doc, memoryStream);
//    doc.AddAuthor("CJG - ECL");
//    doc.AddTitle("PDF_PRUEBA");
//    doc.Open();


//    //base de titulo
//    BaseFont base_titulo = BaseFont.CreateFont(BaseFont.COURIER, BaseFont.CP1250, true);
//    Font titulo_fuente = new Font(base_titulo, 9f, Font.BOLD, BaseColor.BLACK);

//    BaseFont base_sub_titulo = BaseFont.CreateFont(BaseFont.COURIER, BaseFont.CP1250, true);
//    Font sub_titulo_fuente = new Font(base_sub_titulo, 7f, Font.BOLD, BaseColor.BLACK);

//    BaseFont base_titulo_tabla = BaseFont.CreateFont(BaseFont.COURIER, BaseFont.CP1250, true);
//    Font titulo_tabla_fuente = new Font(base_titulo_tabla, 7f, Font.BOLD, BaseColor.BLACK);

//    BaseFont base_parrafo = BaseFont.CreateFont(BaseFont.COURIER, BaseFont.CP1250, true);
//    Font parrafo_fuente = new Font(base_parrafo, 7f, Font.NORMAL, BaseColor.BLACK);

//    BaseFont base_detalle = BaseFont.CreateFont(BaseFont.COURIER, BaseFont.CP1250, true);
//    Font detalle_fuente = new Font(base_detalle, 7f, Font.NORMAL, BaseColor.BLACK);

//    string ruta_clave_privada_SSH = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory + "assets\\media\\reciclaje\\", "logo_sin_texto_color.png");

//    Image img = Image.GetInstance(ruta_clave_privada_SSH);
//    img.ScalePercent(15f);

//    //aca se esta dando el tamaño de la tabla y el procentaje de la hoja
//    var tabla = new PdfPTable(new float[] { 100f }) { WidthPercentage = 100 };
//    tabla.AddCell(new PdfPCell(new Phrase("Sistema de reciclaje", titulo_fuente)) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_CENTER });
//    tabla.AddCell(new PdfPCell(img) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_CENTER });
//    doc.Add(tabla);

//    tabla = new PdfPTable(new float[] { 50f, 50f }) { WidthPercentage = 100 };

//    tabla.AddCell(new PdfPCell(new Phrase("Ticket De Descuento", sub_titulo_fuente)) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_CENTER, Colspan = 2 });
//    tabla.AddCell(new PdfPCell(new Phrase("Cod. Ticket:", sub_titulo_fuente)) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
//    tabla.AddCell(new PdfPCell(new Phrase("1111", parrafo_fuente)) { Border = 0, HorizontalAlignment = Element.ALIGN_MIDDLE });

//    tabla.AddCell(new PdfPCell(new Phrase("Cod. Cliente:", sub_titulo_fuente)) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
//    tabla.AddCell(new PdfPCell(new Phrase("1111", parrafo_fuente)) { Border = 0, HorizontalAlignment = Element.ALIGN_MIDDLE });

//    tabla.AddCell(new PdfPCell(new Phrase("Fecha/Hora:", sub_titulo_fuente)) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
//    tabla.AddCell(new PdfPCell(new Phrase(DateTime.Now.ToString("dd/MM/yyy hh:mm"), parrafo_fuente)) { Border = 0, HorizontalAlignment = Element.ALIGN_MIDDLE });
//    doc.Add(tabla);

//    doc.Add(new Paragraph(" "));

//    //columna
//    tabla = new PdfPTable(new float[] { 50f, 50f, 50f }) { WidthPercentage = 100 };
//    tabla.AddCell(new PdfPCell(new Phrase("Cantidad", titulo_tabla_fuente)) { Border = 0, HorizontalAlignment = Element.ALIGN_MIDDLE });
//    tabla.AddCell(new PdfPCell(new Phrase("Descripcion", titulo_tabla_fuente)) { Border = 0, HorizontalAlignment = Element.ALIGN_MIDDLE });
//    tabla.AddCell(new PdfPCell(new Phrase("Descuento", titulo_tabla_fuente)) { Border = 0, HorizontalAlignment = Element.ALIGN_MIDDLE });

//    //detalle
//    tabla.AddCell(new PdfPCell(new Phrase("1", parrafo_fuente)) { Border = 0, HorizontalAlignment = Element.ALIGN_MIDDLE });
//    tabla.AddCell(new PdfPCell(new Phrase("BIMBO", parrafo_fuente)) { Border = 0, HorizontalAlignment = Element.ALIGN_MIDDLE });
//    tabla.AddCell(new PdfPCell(new Phrase("20%", parrafo_fuente)) { Border = 0, HorizontalAlignment = Element.ALIGN_MIDDLE });
//    doc.Add(tabla);

//    writer.CloseStream = false;
//    doc.Close();
//    memoryStream.Position = 0;
//    return File(memoryStream, "application/pdf");
//}
