using ForlogicAutoAvaliacao.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ForlogicAutoAvaliacao.TestApi.MockData
{
    public class ClienteMockData
    {
        public static List<Cliente> GetClientesData()
        {
            return new List<Cliente> {
                new Cliente
                {
                    Id = 1,
                    Nome = "Test Child",
                    NomeContato = "Test Contato",
                    Cnpj = "15315453000184",
                },
                 new Cliente
                {
                   Id = 2,
                    Nome = "Test Child 2",
                    NomeContato = "Test Contato 2",
                    Cnpj = "04579324000187",
                },
                  new Cliente
                {
                   Id = 3,
                    Nome = "Test Child 3",
                    NomeContato = "Test Contato 3",
                    Cnpj = "81779703000161",
                },
            };
        }

        public static List<Cliente> GetEmptyClientes()
        {
            return new List<Cliente>();
        }

        public static Cliente NewCliente()
        {
            return new Cliente
            {
                Id = 0,
                Nome = "Test Child 4",
                NomeContato = "Test Contato 4",
                Cnpj = "16527862000107",
            };
        }
    }
}
