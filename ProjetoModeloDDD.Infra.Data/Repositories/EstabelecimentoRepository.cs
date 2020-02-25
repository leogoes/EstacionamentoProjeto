using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Repositories;
using System;

namespace ProjetoModeloDDD.Infra.Data.Repositories
{
    public class EstabelecimentoRepository : RepositoryBase<Estabelecimento>, IEstabelecimentoRepository
    {
        public void EntradaVeiculo(int VeiculoId)
        {
            try
            {
                VeiculoRepository veiculoRepository = new VeiculoRepository();
                Veiculos veiculoInfo = veiculoRepository.GetById(VeiculoId);

                if(veiculoInfo != null && veiculoInfo.IsEstacionado != true)
                {
                    veiculoInfo.IsEstacionado = true;
                    veiculoRepository.Update(veiculoInfo);
                }

            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public void SaidaVeiculo(int VeiculoId)
        {

            try
            {
                VeiculoRepository veiculoRepository = new VeiculoRepository();
                Veiculos veiculoInfo = veiculoRepository.GetById(VeiculoId);

                if(veiculoInfo != null && veiculoInfo.IsEstacionado != false)
                {
                    veiculoInfo.IsEstacionado = false;
                    veiculoRepository.Update(veiculoInfo);
                }

            }
            catch(Exception e)
            {

                throw e;
            }

        }
    }
}
