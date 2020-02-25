using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoModeloDDD.MVC.ViewModels
{
    public class ProdutoViewModel
    {
        [Key]
        public int ProdutoId { get; set; }

        [Required(ErrorMessage ="Preencha o campo Nome")]
        [MaxLength(250, ErrorMessage ="Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage ="mínimo {0} caracteres")]
        public string Nome { get; set; }

        [DataType(DataType.Currency)]
        [Range(typeof(decimal), "0", "999999999")]
        [Required(ErrorMessage ="Preencha um valor")]
        public decimal Valor { get; set; }

        public bool Disponivel { get; set; }
        //Chave FK para Relacionar com os Clientes (1(C):M(P))
        public int ClienteId { get; set; }
        public virtual ClienteViewModel Cliente { get; set; }
    }
}
