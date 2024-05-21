using FastReport;
using FastReport.Data;
using FastReport.Export.PdfSimple;
using System;
using System.Configuration;
using System.IO;
using WebAppFastReport.EntityFrameWork;
using WebAppFastReport.Helpers;

namespace WebAppFastReport
{
    public partial class RelatorioCategoria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (DB_TestesEdsEntities ctx = new DB_TestesEdsEntities())
            {
                //criamos uma instancia do objeto webreport
                var webReport = new FastReport.Report();

                // Obtemos uma instância do objeto MsSqlDataConnection
                // e definimos a string de conexão para o banco de dados nele
                var mssqlDataConnection = new MsSqlDataConnection();

                mssqlDataConnection.ConnectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

                var relatorioPath = Server.MapPath("~") + @"Relatorios\RelCategoriaProdutos.frx";

                webReport.Report.Dictionary.Connections.Add(mssqlDataConnection);

                //carregamos o relatório criado na pasta reports
                webReport.Report.Load(relatorioPath);

                //obtemos os dados para categorias e products
                var categories = HelperFastReport.GetTable(ctx.CATEGORIA, "Categoria");
                var products = HelperFastReport.GetTable(ctx.PRODUTO, "Produto");

                //registramos as fontes de dados 
                webReport.Report.RegisterData(categories, "Categoria");
                webReport.Report.RegisterData(products, "Produto");

                webReport.Report.Prepare();

                // Atribui o relatório preparado ao controle WebReport
                // Exporta o relatório para PDF
                using (MemoryStream ms = new MemoryStream())
                {
                    var pdfExport = new PDFSimpleExport();
                    webReport.Export(pdfExport, ms);
                    ms.Flush();
                    ms.Position = 0;

                    // Salva o PDF em uma pasta temporária e exibe no iframe
                    string tempFileName = Guid.NewGuid().ToString() + ".pdf";
                    string tempFilePath = Server.MapPath("~/Temp/" + tempFileName);
                    File.WriteAllBytes(tempFilePath, ms.ToArray());

                    // Configura o iframe para exibir o PDF
                    iframeReport.Attributes["src"] = "~/Temp/" + tempFileName;
                }
            }
        }
    }
}