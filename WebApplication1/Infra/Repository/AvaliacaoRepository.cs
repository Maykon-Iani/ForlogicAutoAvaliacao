using ForlogicAutoAvaliacao.Domain.Entities;
using ForlogicAutoAvaliacao.Domain.Interfaces.Repository;
using ForlogicAutoAvaliacao.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForlogicAutoAvaliacao.Infra.Repository
{
    public class AvaliacaoRepository : GenericRepository<Avaliacao>, IAvaliacaoRepository
    {
        private readonly MySqlContext _repositoryContext;
        public AvaliacaoRepository(MySqlContext repositoryContext)
            : base(repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }


        public async Task<IEnumerable<Avaliacao>> GetAvaliacoes()
        {
            return await _repositoryContext.Avaliacoes
                .Include(c => c.Cliente)
                .AsNoTracking()
                .ToListAsync();
        }


        public bool ExistAvaliacoesToMesAno(int idCliente, DateTime mesAno)
        {
            return _repositoryContext.Avaliacoes.Any(c => c.IdCliente == idCliente && c.MesAno == mesAno);
        }
    }
}
