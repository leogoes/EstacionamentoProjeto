using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Infra.Data.EntityConfig;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace ProjetoModeloDDD.Infra.Data.Contexto
{
    public class ProjetoModeloContext : DbContext
    {
        //Ctor com nome do DB
        public ProjetoModeloContext()
            :base("ProjetoModeloDDD")
        {

        }

        //Relaciona Model com DB
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Veiculos> Veiculos { get; set; }
        public DbSet<Estabelecimento> Estabeleciementos { get; set; }

        //Remove Convenções e Padroniza a criação de tables e relação entre elas 
        //Pode ser sobreescrivido por uma instancia de Entidades presentes em EntitesConfig
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            //Remove o plural das tables
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //Remove o delete em cascata nas relações de um pra muitos
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            //Remove o Delete em casacata nas relações de muito pra muitos
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

           // Relação de ID para Setar PrimaryKey com Nomes
            modelBuilder.Properties()
                .Where(p => p.Name == p.ReflectedType.Name + "Id")
                .Configure(p => p.IsKey());

            //Definir tipo das colunas nas tables para strings, por default(nvarchar)
            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            //Definir tamanho das colunas das tables
            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));


            //Define Instancia de Entidades em EntitesConfiguration como base para Criação das Tables
            modelBuilder.Configurations.Add(new ClienteConfiguration());
            modelBuilder.Configurations.Add(new ProdutoConfiguration());
            modelBuilder.Configurations.Add(new EstabelecimentoConfiguration());
            modelBuilder.Configurations.Add(new VeiculoConfiguration());

        }
       
        public override int SaveChanges()
        {
            //Procura o Data Cadastro nas entidades com ChangeTrackerEntries?
            //Utiliza o ChngeTracker onde a propriedade se chamar DataCadastro e for != null
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                //Quando for adicionar
                if(entry.State == EntityState.Added)
                {
                    //O valor de dataCadastro é o DateTime.Now
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }

                //Quando estiver modificando
                if(entry.State == EntityState.Modified)
                {
                    //O valor é mantido
                    entry.Property("DataCadastro").IsModified = false;
                }
            }

            return base.SaveChanges();
        }
    }
        

}
