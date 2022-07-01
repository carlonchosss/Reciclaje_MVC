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
    public class ReporteController : Controller
    {
        NReporte nReporte;

        // GET: Reporte
        public ActionResult Reporte_Descuento()
        {
            return View();
        }

        //-------------------Metodos
        [HttpPost]
        [Route("Obtener_Reporte_Empresa_Descuento")]
        public ActionResult Obtener_Reporte_Empresa_Descuento(string fecha_inicio_reporte, string fecha_fin_reporte, string codigo_empresa_descuento)

        {
            try
            {
                nReporte = new NReporte();
                var existe_usuario = new List<EReporte_Empresa_Descuento>();

                if (fecha_inicio_reporte != "" && fecha_fin_reporte != "")
                {
                    existe_usuario = nReporte.Obtener_Reporte_Empresa_Descuento(fecha_inicio_reporte, fecha_fin_reporte, codigo_empresa_descuento);
                }
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

        //-----------------Metodos PDF
        //-------------------Metodos
        [HttpPost]
        [Route("Exportar_Obtener_Reporte_Empresa_Descuento")]
        public ActionResult Exportar_Obtener_Reporte_Empresa_Descuento(string fecha_inicio_reporte, string fecha_fin_reporte, string codigo_empresa_descuento)

        {
            try
            {
                nReporte = new NReporte();
                string nombre_pdfs = "";
                if (fecha_inicio_reporte != "" && fecha_fin_reporte != "")
                {
                    var obj_pdf = nReporte.Obtener_Reporte_Empresa_Descuento(fecha_inicio_reporte, fecha_fin_reporte, codigo_empresa_descuento);
                    if (obj_pdf != null)
                    {
                        var pdf_exportado = formato_pdf_exportado_empresa_descuento(obj_pdf);

                        if (codigo_empresa_descuento == "" || codigo_empresa_descuento == "0")
                        {

                            nombre_pdfs = "Reporte_Todo_Empresa_Descuento" + DateTime.Now.ToString("ddMMyyy_hhmmss");
                        }
                        else
                        {
                            nombre_pdfs = "Reporte_Personalizado_Empresa_Descuento" + DateTime.Now.ToString("ddMMyyy_hhmmss");
                        }

                        return new JsonResult { Data = new { resultado = true, titulo = "Éxito", nombrepdf = nombre_pdfs, base64 = pdf_exportado }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                    }
                    else
                    {
                        return new JsonResult { Data = new { resultado = false, codigo_error = 1, errortitulo = "Error", mensaje = "No Se pudo Exportar Puntos Descuento" }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                    }
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
        public string formato_pdf_exportado_empresa_descuento(List<EReporte_Empresa_Descuento> puntos_datos)
        {
            Document doc = new Document();

            //se utiliza medida points
            doc.SetPageSize(PageSize.A4);
            //doc.SetPageSize(new Rectangle(226.772f, 326.772f));

            // doc.SetMargins(226.772f, 226.772f, 226.772f, 226.772f);
            MemoryStream memoryStream = new MemoryStream();
            PdfWriter writer = PdfWriter.GetInstance(doc, memoryStream);
            doc.AddAuthor("CJG - ECL");
            doc.AddTitle("Reporte General Empresa Descuento");
            doc.Open();

            //creando estilos libres
            Font letra_normal_9 = Estilos_Letra_ITextSharp(0, BaseFont.COURIER, 9f, Font.NORMAL, BaseColor.BLACK);
            Font letra_negrita_9 = Estilos_Letra_ITextSharp(0, BaseFont.COURIER, 9f, Font.BOLD, BaseColor.BLACK);
            Font letra_subrayado_negrita_9 = Estilos_Letra_ITextSharp(0, BaseFont.COURIER, 9f, Font.BOLD | Font.UNDERLINE, BaseColor.BLACK);
            Font letra_subrayado_9 = Estilos_Letra_ITextSharp(0, BaseFont.COURIER, 9f, Font.UNDERLINE, BaseColor.BLACK);

            Font letra_normal_7 = Estilos_Letra_ITextSharp(0, BaseFont.COURIER, 7f, Font.NORMAL, BaseColor.BLACK);
            Font letra_negrita_7 = Estilos_Letra_ITextSharp(0, BaseFont.COURIER, 7f, Font.BOLD, BaseColor.BLACK);
            Font letra_subrayado_negrita_7 = Estilos_Letra_ITextSharp(0, BaseFont.COURIER, 7f, Font.BOLD | Font.UNDERLINE, BaseColor.BLACK);
            Font letra_subrayado_7 = Estilos_Letra_ITextSharp(0, BaseFont.COURIER, 7f, Font.UNDERLINE, BaseColor.BLACK);

            //imagen
            string ruta_clave_privada_SSH = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory + "assets\\media\\reciclaje\\", "logo_sin_texto_color.png");

            Image img = Image.GetInstance(ruta_clave_privada_SSH);
            img.ScalePercent(18f);

            //aca se esta inicializando tabla pdf
            var Tabla_Pdf = new PdfPTable(1);

            //---------------Primera tabla
            Tabla_Pdf = new PdfPTable(new float[] { 20f, 20f, 40f }) { WidthPercentage = 100 };

            //primera columna
            Tabla_Pdf.AddCell(new PdfPCell(new Phrase("Sistema de reciclaje", letra_negrita_9)) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, VerticalAlignment = Element.ALIGN_CENTER, Colspan = 2 });

            Tabla_Pdf.AddCell(new PdfPCell(img) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, VerticalAlignment = Element.ALIGN_CENTER, Rowspan = 3 });

            //segunda columna
            Tabla_Pdf.AddCell(new PdfPCell(new Phrase("Reporte General Empresa Descuento", letra_negrita_9)) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, VerticalAlignment = Element.ALIGN_CENTER, Colspan = 2 });

            //tercera columna
            Tabla_Pdf.AddCell(new PdfPCell(new Phrase("Fecha Reporte:", letra_negrita_9)) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, VerticalAlignment = Element.ALIGN_CENTER });

            //cuarta columna
            Tabla_Pdf.AddCell(new PdfPCell(new Phrase(DateTime.Now.ToString("dd/MM/yyyy HH:mm tt ").ToUpper(), letra_negrita_9)) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, VerticalAlignment = Element.ALIGN_CENTER });

            doc.Add(Tabla_Pdf);

            //---------------Segunda tabla
            Tabla_Pdf = new PdfPTable(new float[] { 20f }) { WidthPercentage = 100 };

            Tabla_Pdf.AddCell(new PdfPCell(new Phrase("Datos Reporte", letra_subrayado_negrita_9)) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_CENTER });
            doc.Add(Tabla_Pdf);

            //---------------Salto de linea para  tabla
            doc.Add(new Paragraph(" "));

            //---------------Tercera tabla
            Tabla_Pdf = new PdfPTable(new float[] { 20f, 20f, 20f, 20f, 20f }) { WidthPercentage = 100 };

            Tabla_Pdf.AddCell(new PdfPCell(new Phrase("Codigo Interno".ToUpper(), letra_negrita_7)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_CENTER });
            Tabla_Pdf.AddCell(new PdfPCell(new Phrase("Usuario Canjeado".ToUpper().ToUpper(), letra_negrita_7)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_CENTER });
            Tabla_Pdf.AddCell(new PdfPCell(new Phrase("Empresa Descuentos".ToUpper().ToUpper(), letra_negrita_7)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_CENTER });
            Tabla_Pdf.AddCell(new PdfPCell(new Phrase("Descuento Aplicado".ToUpper().ToUpper(), letra_negrita_7)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_CENTER });
            Tabla_Pdf.AddCell(new PdfPCell(new Phrase("Puntos Canjeados".ToUpper(), letra_negrita_7)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_CENTER });

            foreach (var item in puntos_datos)
            {
                Tabla_Pdf.AddCell(new PdfPCell(new Phrase(item.codigo_puntos_detallados.ToString(), letra_normal_7)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_CENTER });
                Tabla_Pdf.AddCell(new PdfPCell(new Phrase(item.nombre, letra_normal_7)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_CENTER });
                Tabla_Pdf.AddCell(new PdfPCell(new Phrase(item.descripcion_empresa_descuento, letra_normal_7)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_CENTER });
                Tabla_Pdf.AddCell(new PdfPCell(new Phrase(item.descuento_aplicado, letra_normal_7)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_CENTER });
                Tabla_Pdf.AddCell(new PdfPCell(new Phrase(item.puntos_canjeados, letra_normal_7)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_CENTER });

            }
            doc.Add(Tabla_Pdf);

            writer.CloseStream = false;
            doc.Close();

            //poner siempre el memoryStream.Position al ultimo si el pdf no funciona
            memoryStream.Position = 0;
            //return File(memoryStream, "application/pdf");

            var file = Convert.ToBase64String(memoryStream.ToArray());

            return file;
        }
        public MemoryStream formato_pdf_exportado_reciclaje_canjeado_old(List<EReporte_Empresa_Descuento> puntos_datos, Type objeto_clase)
        {
            Document doc = new Document();

            //se utiliza medida points
            doc.SetPageSize(PageSize.A4);
            //doc.SetPageSize(new Rectangle(226.772f, 326.772f));

            // doc.SetMargins(226.772f, 226.772f, 226.772f, 226.772f);
            MemoryStream memoryStream = new MemoryStream();
            PdfWriter writer = PdfWriter.GetInstance(doc, memoryStream);
            doc.AddAuthor("CJG - ECL");
            doc.AddTitle("Reporte General Empresa Descuento");
            doc.Open();

            //base de titulo
            BaseFont base_titulo = BaseFont.CreateFont(BaseFont.COURIER, BaseFont.CP1250, true);
            Font titulo_fuente = new Font(base_titulo, 9f, Font.BOLD, BaseColor.BLACK);

            BaseFont base_titulo_subrayado = BaseFont.CreateFont(BaseFont.COURIER, BaseFont.CP1250, true);
            Font titulo_fuente_subrayado = new Font(base_titulo_subrayado, 9f, Font.BOLD | Font.UNDERLINE, BaseColor.BLACK);

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
            img.ScalePercent(18f);

            //aca se esta dando el tamaño de la tabla y el procentaje de la hoja
            var tabla = new PdfPTable(new float[] { 100f }) { WidthPercentage = 100 };

            //tabla.AddCell(new PdfPCell(new Phrase("Sistema de reciclaje", titulo_fuente)) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_CENTER });
            //tabla.AddCell(new PdfPCell(img) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_CENTER });
            //doc.Add(tabla);


            tabla = new PdfPTable(new float[] { 20f, 20f, 40f }) { WidthPercentage = 100 };
            //Border = 0,
            //primera columna
            tabla.AddCell(new PdfPCell(new Phrase("Sistema de reciclaje", titulo_fuente)) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, VerticalAlignment = Element.ALIGN_CENTER, Colspan = 2 });

            //tabla.AddCell(new PdfPCell(img) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, VerticalAlignment = Element.ALIGN_CENTER });
            tabla.AddCell(new PdfPCell(img) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, VerticalAlignment = Element.ALIGN_CENTER, Rowspan = 3 });

            //segunda columna
            tabla.AddCell(new PdfPCell(new Phrase("Reporte General Empresa Descuento", titulo_fuente)) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, VerticalAlignment = Element.ALIGN_CENTER, Colspan = 2 });

            // tabla.AddCell(new PdfPCell(new Phrase("img", titulo_fuente)) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, VerticalAlignment = Element.ALIGN_CENTER });
            //tercera columna
            tabla.AddCell(new PdfPCell(new Phrase("Fecha Reporte:", titulo_fuente)) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, VerticalAlignment = Element.ALIGN_CENTER });

            //cuarta columna
            tabla.AddCell(new PdfPCell(new Phrase(DateTime.Now.ToString("dd/MM/yyyy HH:mm "), titulo_fuente)) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, VerticalAlignment = Element.ALIGN_CENTER });

            doc.Add(tabla);

            tabla = new PdfPTable(new float[] { 20f }) { WidthPercentage = 100 };

            tabla.AddCell(new PdfPCell(new Phrase("Datos Reporte", titulo_fuente_subrayado)) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_CENTER });
            doc.Add(tabla);

            doc.Add(new Paragraph(" "));


            tabla = new PdfPTable(new float[] { 20f, 20f, 20f, 20f, 20f }) { WidthPercentage = 100 };

            //capturamos las variables de la clase
            // Type type = typeof(ERepobjeto_claseorte_Empresa_Descuento);

            Type type = objeto_clase;
            //con reflection capturamos las propiedades las variables de la clase
            System.Reflection.PropertyInfo[] propertiesInfo = type.GetProperties();
            foreach (System.Reflection.PropertyInfo propertyInfo in propertiesInfo)
            {
                tabla.AddCell(new PdfPCell(new Phrase(propertyInfo.Name.Replace("_", " ").ToUpper(), titulo_fuente)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_CENTER });
                //Console.WriteLine(propertyInfo.Name);
            }

            foreach (var item in puntos_datos)
            {
                tabla.AddCell(new PdfPCell(new Phrase(item.codigo_puntos_detallados.ToString(), sub_titulo_fuente)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_CENTER });
                tabla.AddCell(new PdfPCell(new Phrase(item.descripcion_empresa_descuento, sub_titulo_fuente)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_CENTER });
                tabla.AddCell(new PdfPCell(new Phrase(item.descuento_aplicado, sub_titulo_fuente)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_CENTER });
                tabla.AddCell(new PdfPCell(new Phrase(item.nombre, sub_titulo_fuente)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_CENTER });
                tabla.AddCell(new PdfPCell(new Phrase(item.puntos_canjeados, sub_titulo_fuente)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_CENTER });

            }
            doc.Add(tabla);

            writer.CloseStream = false;
            doc.Close();

            //poner siempre el memoryStream.Position al ultimo si el pdf no funciona
            memoryStream.Position = 0;
            //return File(memoryStream, "application/pdf");

            //var file = Convert.ToBase64String(memoryStream.ToArray());

            return memoryStream;
        }
        public Font Estilos_Letra_ITextSharp(int parametro_estilo, string tipo_letra = null, float? tamanio_letra = null, int? estilo_letra = null, BaseColor color_letra = null)
        {
            BaseFont base_titulo;
            Font titulo_fuente = null;
            switch (parametro_estilo)
            {
                case 1:
                    //base de titulo - negrita
                    base_titulo = BaseFont.CreateFont(BaseFont.COURIER, BaseFont.CP1250, true);
                    titulo_fuente = new Font(base_titulo, 9f, Font.BOLD, BaseColor.BLACK);
                    break;
                case 2:
                    //base de titulo - sin negrita
                    base_titulo = BaseFont.CreateFont(BaseFont.COURIER, BaseFont.CP1250, true);
                    titulo_fuente = new Font(base_titulo, 9f, Font.NORMAL, BaseColor.BLACK);
                    break;
                case 3:
                    //base de titulo - subrayado - negrita
                    base_titulo = BaseFont.CreateFont(BaseFont.COURIER, BaseFont.CP1250, true);
                    titulo_fuente = new Font(base_titulo, 9f, Font.BOLD | Font.UNDERLINE, BaseColor.BLACK);
                    break;

                case 4:
                    //base de sub titulo - negrita
                    base_titulo = BaseFont.CreateFont(BaseFont.COURIER, BaseFont.CP1250, true);
                    titulo_fuente = new Font(base_titulo, 7f, Font.BOLD, BaseColor.BLACK);
                    break;
                case 5:
                    //base de sub titulo - sin negrita
                    base_titulo = BaseFont.CreateFont(BaseFont.COURIER, BaseFont.CP1250, true);
                    titulo_fuente = new Font(base_titulo, 7f, Font.NORMAL, BaseColor.BLACK);
                    break;
                case 6:
                    //base de sub titulo - subrayado - negrita
                    base_titulo = BaseFont.CreateFont(BaseFont.COURIER, BaseFont.CP1250, true);
                    titulo_fuente = new Font(base_titulo, 7f, Font.BOLD | Font.UNDERLINE, BaseColor.BLACK);
                    break;
                default:
                    // a gusto del cliente su estilo
                    base_titulo = BaseFont.CreateFont(Convert.ToString(tipo_letra), BaseFont.CP1250, true);
                    titulo_fuente = new Font(base_titulo, (float)tamanio_letra, (int)estilo_letra, color_letra);
                    break;
            }
            return titulo_fuente;
        }
    }
}