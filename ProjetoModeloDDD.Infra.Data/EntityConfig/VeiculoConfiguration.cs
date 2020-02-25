using ProjetoModeloDDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Infra.Data.EntityConfig
{
    public class VeiculoConfiguration : EntityTypeConfiguration<Veiculos>
    {
        public VeiculoConfiguration()
        {
            ToTable("Veiculo");

            Property(v => v.Marca)
                .IsRequired()
                .HasMaxLength(50);

            Property(v => v.Modelo)
                .IsRequired()
                .HasMaxLength(50);

            Property(v => v.Cor)
                .IsRequired()
                .HasMaxLength(20);

            Property(v => v.Placa)
                .IsRequired()
                .HasMaxLength(7);

            Property(v => v.Tipo)
                .IsRequired()
                .HasMaxLength(20);

            HasRequired(v => v.Estabelecimento)
                .WithMany()
                .HasForeignKey(v => v.EstabelecimentoId);
        }
    }
}
