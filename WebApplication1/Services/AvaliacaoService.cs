using ForlogicAutoAvaliacao.Domain.Entities;
using ForlogicAutoAvaliacao.Domain.Interfaces.Repository;
using ForlogicAutoAvaliacao.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ForlogicAutoAvaliacao.Services
{
    public class AvaliacaoService : IAvaliacaoService
    {
        private readonly IAvaliacaoRepository _avaliacaoRepository;
        private readonly IClienteRepository _clienteRepository;
        public AvaliacaoService(
            IAvaliacaoRepository avaliacaoRepository,
            IClienteRepository clienteRepository)
        {
            _avaliacaoRepository = avaliacaoRepository;
            _clienteRepository = clienteRepository;
        }

        public async Task Delete(int id)
        {
            await _avaliacaoRepository.Delete(id);
        }

        public bool ExistAvaliacoesToMesAno(int idCliente, DateTime mesAno)
        {
           return _avaliacaoRepository.ExistAvaliacoesToMesAno(idCliente, mesAno);
        }

        public async Task<IEnumerable<Avaliacao>> GetAll()
        {
            return await _avaliacaoRepository.GetAvaliacoes();
        }

        public async Task<Avaliacao> GetById(int id)
        {
            return await _avaliacaoRepository.GetById(id);
        }

        public async Task Insert(Avaliacao avaliacao)
        {
            await _avaliacaoRepository.Insert(avaliacao);

            await AplicaCategoriaCliente(avaliacao.IdCliente, avaliacao.Nota);
        }

        public async Task Update(Avaliacao avaliacao)
        {
            await _avaliacaoRepository.Update(avaliacao);

            await AplicaCategoriaCliente(avaliacao.IdCliente, avaliacao.Nota);
        }

        private async Task AplicaCategoriaCliente(int idCliente, int nota)
        {
            var cliente = await _clienteRepository.GetById(idCliente);

            if (nota.Equals(9) || nota.Equals(10))
            {
                cliente.Categoria = "Promotor";
            }
            else if (nota.Equals(7) || nota.Equals(8))
            {
                cliente.Categoria = "Neutro";
            }
            else if (nota.Equals(0) || nota.Equals(6))
            {
                cliente.Categoria = "Detrator";
            }
            else
            {
                cliente.Categoria = "Neutro";
            }

            await _clienteRepository.UpdateCliente(cliente);
        }
    }
}
