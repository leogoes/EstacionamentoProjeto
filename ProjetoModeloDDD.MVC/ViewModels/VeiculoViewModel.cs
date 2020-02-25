using ProjetoModeloDDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoModeloDDD.MVC.ViewModels
{
    public class VeiculoViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "É necessário inserir uma marca!")]
        public string Marca { get; set; }
        [Required(ErrorMessage = "É necessário inserir uma modelo!")]
        public string Modelo { get; set; }
        [Required(ErrorMessage = "É necessário inserir uma cor!")]
        public string Cor { get; set; }
        [Required(ErrorMessage = "É necessário inserir uma Placa!")]
        [Range(0, int.MaxValue, ErrorMessage = "Somente números são aceitos para o valor da placa!")]
        public string Placa { get; set; }
        [Required(ErrorMessage = "É necessário inserir uma Tipo!")]
        public string Tipo { get; set; }
        public int EstabelecimentoId { get; set; }
        public Estabelecimento Estabelecimento { get; set; }
        public bool IsEstacionado { get; set; } = false;
    }
}