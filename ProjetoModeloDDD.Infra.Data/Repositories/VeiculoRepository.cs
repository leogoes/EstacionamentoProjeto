using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces;
using ProjetoModeloDDD.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Infra.Data.Repositories
{
    public class VeiculoRepository : RepositoryBase<Veiculos>, IVeiculoRepository
    {

        public bool IsEstacionado(int VeiculoId)
        {

            Veiculos veiculo = GetById(VeiculoId);
            if(veiculo.IsEstacionado != true)
            {
                return false;
            }

            return true;
        }
    }
}
