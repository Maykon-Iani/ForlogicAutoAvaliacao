using ForlogicAutoAvaliacao.Domain.Entities;
using ForlogicAutoAvaliacao.Domain.Interfaces.Repository;
using ForlogicAutoAvaliacao.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ForlogicAutoAvaliacao.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task Delete(int id)
        {
            await _clienteRepository.Delete(id);
        }

        public async Task<IEnumerable<Cliente>> GetAll()
        {
            return await _clienteRepository.GetAll();
        }

        public async Task<Cliente> GetById(int id)
        {
            return await _clienteRepository.GetById(id);
        }

        public async Task Insert(Cliente cliente)
        {
           await _clienteRepository.Insert(cliente);
        }

        public async Task Update(Cliente cliente)
        {
            await _clienteRepository.UpdateCliente(cliente);
        }

        public bool IsExistCnpj (string cnpj)
        {
            return _clienteRepository.IsExistCnpj(cnpj);
        }

        public Task<IEnumerable<object>> ClientesByName()
        {
            return _clienteRepository.ClientesByName();
        }
    }
}
