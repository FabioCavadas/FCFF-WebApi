using FCFFDomain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCFFInfra.Data.Mappings
{
    /// <summary>
    /// Mapeamento da entidade de domínio para o modelo relacional
    /// </summary>
    public class ProdutoMap : EntityTypeConfiguration<Produto>
    {
        //Construtor
        public ProdutoMap()
        {
            HasKey(p => p.IdProduto);

            Property(p => p.Nome)
                .HasMaxLength(50)
                .IsRequired();

            Property(p => p.Preco)
                .HasPrecision(18,2)
                .IsRequired();

            Property(p => p.Quantidade)
                .IsRequired();

            HasRequired(p => p.Estoque)
                .WithMany(e => e.Produtos)
                .HasForeignKey(p => p.IdEstoque);
        }

    }
}
