using FastReport.Export.PdfSimple;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
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

                var report = new FastReport.Report();

                report.Load(relatorioPath);

                report.Dictionary.RegisterBusinessObject(clientes, "dataClientes", 10, true);

                #region Cria template do report já com a lista de dados

                //report.Report.Save(relatorioPath);

                #endregion

                report.Prepare();

                var pdfExport = new PDFSimpleExport();

                using (MemoryStream ms = new MemoryStream()) 
                { 
                    pdfExport.Export(report, ms);
                    ms.Flush();

                    // Definindo o tipo de conteúdo da resposta como PDF
                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-disposition", "inline; filename=RelClientes.pdf");
                    Response.BinaryWrite(ms.ToArray());
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro na geração do report: {ex.InnerException?.ToString() ?? ex.Message}");
            }

        }
    }
}