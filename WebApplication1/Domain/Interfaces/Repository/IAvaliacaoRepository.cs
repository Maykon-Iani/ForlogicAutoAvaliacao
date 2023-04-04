using ForlogicAutoAvaliacao.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static ForlogicAutoAvaliacao.Domain.Interfaces.Repository.IGenericRepository;

namespace ForlogicAutoAvaliacao.Domain.Interfaces.Repository
{
    public interface IAvaliacaoRepository : IGenericRepository<Avaliacao>
    {
        Task<IEnumerable<Avaliacao>> GetAvaliacoes();
        bool ExistAvaliacoesToMesAno(int idCliente, DateTime mesAno);
    }
}
