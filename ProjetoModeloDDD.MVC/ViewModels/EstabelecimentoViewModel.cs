using ProjetoModeloDDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoModeloDDD.MVC.ViewModels
{
    public class EstabelecimentoViewModel
    {
        public int Id { get; set; }
        [Required( ErrorMessage = "Necessário inserir um valor para o Nome")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Necessário inserir um valor para o CNPJ")]
        public string CNPJ { get; set; }
        [Required(ErrorMessage = "Necessário inserir um valor para o Endereço")]
        public string Endereço { get; set; }
        [Required(ErrorMessage = "Necessário inserir um valor para o Telefone")]
        public int Telefone { get; set; }
        [Required(ErrorMessage = "Necessário inserir um valor para a Quantidade de vagas de moto")]
        public int QtdeVagaMoto { get; set; }
        [Required(ErrorMessage = "Necessário inserir um valor para a Quantidade de vagas de carro")]
        public int QtdeVagaCarro { get; set; }
        [Required(ErrorMessage = "Necessário inserir um valor para a senha")]
        public int Senha { get; set; }
        public List<VeiculoViewModel> VeiculosEstacionados { get; set; }
        public List<VeiculoViewModel> VeiculosNaoEstacionados { get; set; }

    }
}