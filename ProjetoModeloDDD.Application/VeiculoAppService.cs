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
    public class VeiculoAppService : AppServiceBase<Veiculos>, IVeiculoAppService
    {
        private readonly IVeiculoService _veiculoService;
        public VeiculoAppService(IVeiculoService veiculoService) : base(veiculoService)
        {
            _veiculoService = veiculoService;
        }

        public bool IsEstacionado(int veiculoId)
        {
            return _veiculoService.IsEstacionado(veiculoId);
        }
    }
}
