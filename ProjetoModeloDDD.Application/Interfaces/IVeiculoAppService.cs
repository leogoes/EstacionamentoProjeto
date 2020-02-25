using ProjetoModeloDDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Application.Interfaces
{
    public interface IVeiculoAppService : IAppServiceBase<Veiculos>
    {
        bool IsEstacionado(int veiculoId);
    }
}
