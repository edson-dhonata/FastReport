using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppFastReport.Classes;
using static WebAppFastReport.Classes.Enums;

namespace WebAppFastReport.Data
{
    public class Dados
    {
        public static List<Cliente> getClientes()
        {
           var Clientes = new List<Cliente>();

            for (int i = 1; i <= 15; i++)
            {
                var cliente = new Cliente
                {
                    Codigo = i,
                    Nome = $"Cliente {i} Com Nome Completo",
                    CPF = $"123.456.789-0{i % 10}",
                    DataNascimento = new DateTime(1990 + (i % 10), (i % 12) + 1, (i % 28) + 1),
                    Sexo = (Sexo)(i % 3),
                    Email = $"cliente{i}@example.com",
                    Telefones = new List<Telefone>
                    {
                        new Telefone { Codigo = i * 2 - 1, DDD = "11", Numero = $"98765432{i % 10}", Tipo = TipoTelefone.Celular },
                        new Telefone { Codigo = i * 2, DDD = "11", Numero = $"12345678{i % 10}", Tipo = TipoTelefone.Residencial }
                    },
                    Enderecos = new List<Endereco>
                    {
                        new Endereco
                        {
                            Codigo = i,
                            EnderecoCompleto = $"Rua {i} das Flores, {i * 10}",
                            Complemento = $"Apt {i}",
                            Bairro = $"Bairro {i}",
                            Cidade = "São Paulo",
                            Estado = "SP",
                            CEP = $"0100{i % 10}-000"
                        }
                    }
                };

                Clientes.Add(cliente);
            }

            return Clientes;
        }
    }
}