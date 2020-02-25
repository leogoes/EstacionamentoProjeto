using ProjetoModeloDDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Domain.Interfaces.Repositories
{
    public interface IEstabelecimentoRepository : IRepositoryBase<Estabelecimento> 
    {
        void EntradaVeiculo(int VeiculoId);
        void SaidaVeiculo(int VeiculoId);

    }
}
