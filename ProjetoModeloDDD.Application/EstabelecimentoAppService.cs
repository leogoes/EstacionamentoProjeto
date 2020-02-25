using ProjetoModeloDDD.Application.Interfaces;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Application
{
    public class EstabelecimentoAppService : AppServiceBase<Estabelecimento>, IEstabelecimentoAppService
    {
        private readonly IEstabelecimentoService _estabelecimentoService;
        public EstabelecimentoAppService(IEstabelecimentoService estabelecimentoService) : base(estabelecimentoService)
        {
            _estabelecimentoService = estabelecimentoService;
        }

        public void EntradaVeiculo(int VeiculoId)
        {
            _estabelecimentoService.EntradaVeiculo(VeiculoId);
        }

        public void SaidaVeiculo(int VeiculoId)
        {
            _estabelecimentoService.SaidaVeiculo(VeiculoId);
        }
    }
}
