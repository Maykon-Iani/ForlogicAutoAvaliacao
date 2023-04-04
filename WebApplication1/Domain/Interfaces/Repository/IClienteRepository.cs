using ForlogicAutoAvaliacao.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using static ForlogicAutoAvaliacao.Domain.Interfaces.Repository.IGenericRepository;

namespace ForlogicAutoAvaliacao.Domain.Interfaces.Repository
{
    public interface IClienteRepository : IGenericRepository<Cliente>
    {
        bool IsExistCnpj(string cnpj);
        Task UpdateCliente(Cliente cliente);
        Task<IEnumerable<object>> ClientesByName();
    }
}
