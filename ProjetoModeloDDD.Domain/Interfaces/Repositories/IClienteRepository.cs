using ProjetoModeloDDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Domain.Interfaces
{
    //Herda da Interface base IRepositoryBase com metodos para CRUD
    //Caso não haja nada alem do CRUD mantem a Interface
    public interface IClienteRepository : IRepositoryBase<Cliente>
    {



    }
}
