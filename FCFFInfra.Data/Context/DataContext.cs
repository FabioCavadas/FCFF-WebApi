using FCFFDomain.Entities;
using FCFFInfra.Data.Mappings;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCFFInfra.Data.Context
{
    /// <summary>
    /// Configuração da Stirng de Conexão
    /// Sobrescrever o método OnModelCreating e adicionar classes mapeadas
    /// Propriedade DbSet para cada classe de entidade, permite o uso das operações de persistencia do EF
    /// PluralizingTableNameConvention -> Define o nome da tabela para ser uma versão pluralizada do nome do tipo de entidade.
    /// OneToManyCascadeDeleteConvention -> Ativa a exclusão em cascata para quaisquer relacionamentos necessários.
    /// ManyToManyCascadeDeleteConvention -> Adiciona uma exclusão em cascata à tabela de junção de ambas as tabelas envolvidas em um relacionamento muitos para muitos.
    /// </summary>
    public class DataContext : DbContext
    {
        public DataContext()
            : base(ConfigurationManager.ConnectionStrings["Banco"].ConnectionString)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.Add(new EstoqueMap());
            modelBuilder.Configurations.Add(new ProdutoMap());
        }

        public DbSet<Produto> Produto { get; set; }
        public DbSet<Estoque> Estoque { get; set; }

    }
}
