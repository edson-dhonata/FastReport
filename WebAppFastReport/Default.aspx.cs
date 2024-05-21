using FastReport.Export.PdfSimple;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web.UI;
using WebAppFastReport.Classes;
using WebAppFastReport.Data;

namespace WebAppFastReport
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                var clientes = Dados.getClientes();

                var relatorioPath = Server.MapPath("~") + @"Relatorios\RelClientes.frx";

                if (!ExistRelatorio(relatorioPath))
                    GeraRelatorio("RelClientes.frx", clientes, "dataClientes", relatorioPath);
                else
                    ApresentarRelatorio("RelClientes.frx", clientes, "dataClientes", relatorioPath);
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro na geração do report: {ex.InnerException?.ToString() ?? ex.Message}");
            }
        }

        private bool ExistRelatorio(string Path)
        {
            return (File.Exists(Path) ? true : false);
        }

        private void GeraRelatorio<T>(string nomeRelatorio,List<T> BaseDados, string nomeBaseDados, string path)
        {
            var report = new FastReport.Report();
            report.Dictionary.RegisterBusinessObject(BaseDados, nomeBaseDados, 10, true);
            report.Report.Save(path);
        }

        private void ApresentarRelatorio<T>(string nomeRelatorio, List<T> BaseDados, string nomeBaseDados, string path)
        {
            var report = new FastReport.Report();
            report.Load(path);
            report.Dictionary.RegisterBusinessObject(BaseDados, nomeBaseDados, 10, true);
            report.Prepare();

            var pdfExport = new PDFSimpleExport();

            using (MemoryStream ms = new MemoryStream())
            {
                pdfExport.Export(report, ms);
                ms.Flush();

                // Definindo o tipo de conteúdo da resposta como PDF
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", "inline; filename=" + nomeBaseDados + ".pdf");
                Response.BinaryWrite(ms.ToArray());
            }
        }
    }
}