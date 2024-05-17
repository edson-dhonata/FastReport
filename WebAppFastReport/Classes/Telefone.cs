using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static WebAppFastReport.Classes.Enums;

namespace WebAppFastReport.Classes
{
    public class Telefone
    {
        public int Codigo { get; set; }
        public string DDD { get; set; }
        public string Numero { get; set; }
        public TipoTelefone Tipo { get; set; }
    }
}