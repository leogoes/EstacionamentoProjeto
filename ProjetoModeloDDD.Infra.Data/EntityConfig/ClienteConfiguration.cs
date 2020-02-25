using ProjetoModeloDDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Infra.Data.EntityConfig
{
    //Mapea o comportamento da Cliente e define uma tabela com esse comportamento
    //Cria uma configuração para o cliente migration herdando de EntityTypeConfiguration
    public class ClienteConfiguration : EntityTypeConfiguration<Cliente>
    {
        public ClienteConfiguration()
        {
            
            //Define ClienteId como PK
            HasKey(c => c.ClienteId);

            //Define propriedade Nome como Requirida e com tamanho de 150
            Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(150);

            Property(c => c.Email)
                .IsRequired();

        }
    }
}
