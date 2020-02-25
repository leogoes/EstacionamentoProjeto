using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Domain.Entities
{
    public class Estabelecimento
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CNPJ { get; set; }
        public string Endereço { get; set; }
        public int Telefone { get; set; }
        public int QtdeVagaMoto { get; set; }
        public int QtdeVagaCarro { get; set; }
        public int Senha { get; set; }

    }
}
