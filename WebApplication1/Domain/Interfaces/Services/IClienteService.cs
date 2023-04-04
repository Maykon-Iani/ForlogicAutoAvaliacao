using ForlogicAutoAvaliacao.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ForlogicAutoAvaliacao.Domain.Interfaces.Services
{
    public interface IClienteService
    {
        Task<IEnumerable<Cliente>> GetAll();
        Task<Cliente> GetById(int id);
        Task Insert(Cliente cliente);
        Task Update(Cliente cliente);
        Task Delete(int id);
        bool IsExistCnpj(string cnpj);
        Task<IEnumerable<object>> ClientesByName();
    }
}
