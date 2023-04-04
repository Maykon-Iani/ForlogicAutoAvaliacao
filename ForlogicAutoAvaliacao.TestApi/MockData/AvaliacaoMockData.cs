using ForlogicAutoAvaliacao.Domain.Entities;
using System;
using System.Collections.Generic;

namespace ForlogicAutoAvaliacao.TestApi.MockData
{
    public class AvaliacaoMockData
    {
        public static List<Avaliacao> GetAvaliacoesData()
        {
            return new List<Avaliacao> {
                new Avaliacao
                {
                    Id = 1,
                    MesAno = new DateTime(2023, 04, 1),
                    Nota = 7,
                    IdCliente = 1,
                },
                 new Avaliacao
                {
                    Id = 2,
                    MesAno = new DateTime(2023, 03, 20),
                    Nota = 8,
                    IdCliente = 2,
                },
                  new Avaliacao
                {
                   Id = 3,
                    MesAno = new DateTime(2023, 03, 29),
                    Nota = 9,
                    IdCliente = 3,
                },
            };
        }

        public static List<Avaliacao> GetEmptyAvaliacoes()
        {
            return new List<Avaliacao>();
        }

        public static Avaliacao NewAvaliacao()
        {
            return new Avaliacao
            {
                Id = 4,
                MesAno = new DateTime(2023, 04, 2),
                Nota = 10,
                IdCliente = 4,
            };
        }
    }
}
