using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Domain.Interfaces
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        //Method para adicionar 
        void Add(TEntity obj);
        //Method para pegar pelo ID
        TEntity GetById(int id);
        //Retorna um List 
        IEnumerable<TEntity> GetAll();
        List<TEntity> Listar();
        //Update na List
        void Update(TEntity obj);
        //Remove item
        void Remove(TEntity obj);
        //Realiza o fechamento da conexão quando usado
        void Dispose();

    }
}
