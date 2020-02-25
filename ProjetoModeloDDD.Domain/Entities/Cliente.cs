using System;
using System.Collections.Generic;

namespace ProjetoModeloDDD.Domain.Entities
{
    public class Cliente
    {
        public int ClienteId { get; set; } //id
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public DateTime DataCadastro { get; set; } //Hora de Cadastro
        public virtual IEnumerable<Produto> Produtos { get; set; } //Coleção de Produtos
        public bool Ativo { get; set; } //Se esta ativo

        //Define se um Cliente é Especial e return in bool
        public bool ClienteEscpecial(Cliente cliente)
        {
            return cliente.Ativo && DateTime.Now.Year - cliente.DataCadastro.Year >= 5;
        }
    }
}
