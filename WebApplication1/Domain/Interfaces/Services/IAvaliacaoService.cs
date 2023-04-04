using ForlogicAutoAvaliacao.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ForlogicAutoAvaliacao.Domain.Interfaces.Services
{
    public interface IAvaliacaoService
    {
        Task<IEnumerable<Avaliacao>> GetAll();
        Task<Avaliacao> GetById(int id);
        Task Insert(Avaliacao cliente);
        Task Update(Avaliacao cliente);
        Task Delete(int id);
        bool ExistAvaliacoesToMesAno(int idCliente, DateTime mesAno);
    }
}
