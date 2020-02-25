using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Domain.Entities
{
    public class Produto
    {
        public int ProdutoId { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public bool Disponivel { get; set; }
        //Chave FK para Relacionar com os Clientes (1(C):M(P))
        public int ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }
    }
}
