using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static WebAppFastReport.Classes.Enums;

namespace WebAppFastReport.Classes
{
    public class Cliente
    {
        public Cliente()
        {
            Telefones = new List<Telefone>();
            Enderecos = new List<Endereco>();
        }

        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public Sexo Sexo { get; set; }
        public string Email { get; set; }
        public List<Telefone> Telefones { get; set; }
        public List<Endereco> Enderecos { get; set; }

    }
}