using ProjetoModeloDDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Infra.Data.EntityConfig
{
    public class EstabelecimentoConfiguration : EntityTypeConfiguration<Estabelecimento>
    {
        public EstabelecimentoConfiguration()
        {
            ToTable("Estabelecimento");

            Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(100);

            Property(p => p.CNPJ)
                .IsRequired()
                .HasMaxLength(14);

            Property(p => p.Endereço)
                .IsRequired()
                .HasMaxLength(14);

            Property(p => p.Telefone)
                .IsRequired();

            Property(p => p.Endereço)
                .IsRequired()
                .HasMaxLength(14);

            Property(p => p.QtdeVagaCarro)
                .IsRequired();

            Property(p => p.QtdeVagaCarro)
                .IsRequired();

            Property(p => p.Senha)
                .IsRequired();
        }

    }
}
