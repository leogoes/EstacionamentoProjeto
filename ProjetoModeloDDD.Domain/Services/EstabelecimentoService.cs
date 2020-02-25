using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces;
using ProjetoModeloDDD.Domain.Interfaces.Repositories;
using ProjetoModeloDDD.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Domain.Services
{
    public class EstabelecimentoService : ServiceBase<Estabelecimento>, IEstabelecimentoService
    {
        private readonly IEstabelecimentoRepository _estabelecimentoRepository; 
        public EstabelecimentoService(IEstabelecimentoRepository estabelecimentoRepository) : base(estabelecimentoRepository)
        {
            _estabelecimentoRepository = estabelecimentoRepository;
        }

        public void EntradaVeiculo(int VeiculoId)
        {
            _estabelecimentoRepository.EntradaVeiculo(VeiculoId);
        }

        public void SaidaVeiculo(int VeiculoId)
        {
            _estabelecimentoRepository.SaidaVeiculo(VeiculoId);
        }
    }
}
