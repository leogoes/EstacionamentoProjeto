using ProjetoModeloDDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Application.Interfaces
{
    public interface IEstabelecimentoAppService : IAppServiceBase<Estabelecimento>
    {
        void EntradaVeiculo(int VeiculoId);
        void SaidaVeiculo(int VeiculoId);
    }
}
