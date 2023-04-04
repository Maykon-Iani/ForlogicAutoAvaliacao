using ForlogicAutoAvaliacao.Domain.Entities;
using ForlogicAutoAvaliacao.Domain.Interfaces.Repository;
using ForlogicAutoAvaliacao.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForlogicAutoAvaliacao.Infra.Repository
{
    public class ClienteRepository : GenericRepository<Cliente>, IClienteRepository
    {
        private readonly MySqlContext _repositoryContext;
        public ClienteRepository(MySqlContext repositoryContext)
            : base(repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public bool IsExistCnpj(string cnpj)
        {
            return _repositoryContext.Clientes.Any(x => x.Cnpj == cnpj);
        }

        public async Task UpdateCliente(Cliente cliente)
        {

            var entry = _repositoryContext.Clientes.First(e => e.Id == cliente.Id);
            _repositoryContext.Entry(entry).CurrentValues.SetValues(cliente);

            await _repositoryContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<object>> ClientesByName()
        {

            var teste = _repositoryContext.Clientes
            .Select(i => new { i.Id, i.Nome })
            .Distinct()
            .OrderByDescending(i => i.Nome);

            return await teste.ToListAsync();
        }

    }
}
