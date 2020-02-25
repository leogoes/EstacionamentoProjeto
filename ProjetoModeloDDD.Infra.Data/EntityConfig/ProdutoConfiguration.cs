using ProjetoModeloDDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Infra.Data.EntityConfig
{
    public class ProdutoConfiguration : EntityTypeConfiguration<Produto>
    {

        public ProdutoConfiguration()
        {
            //Define chave FK
            HasKey(p => p.ProdutoId);

            //Define Nome como Required e maximo
            Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(250);

            //Propriedade valor requerida
            Property(p => p.Valor)
                .IsRequired();

            //Relação 1:M para Cliente => Produto
            HasRequired(p => p.Cliente)
                .WithMany()
                .HasForeignKey(p => p.ClienteId);
        }
    }
}
