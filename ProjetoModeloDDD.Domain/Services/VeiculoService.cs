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
    public class VeiculoService : ServiceBase<Veiculos>, IVeiculoService
    {
        private readonly IVeiculoRepository _veiculoRepository;
        public VeiculoService(IVeiculoRepository veiculoRepository)
            : base(veiculoRepository)
        {
            _veiculoRepository = veiculoRepository;
        }

        public bool IsEstacionado(int veiculoId)
        {
            return _veiculoRepository.IsEstacionado(veiculoId);
        }
    }
}
