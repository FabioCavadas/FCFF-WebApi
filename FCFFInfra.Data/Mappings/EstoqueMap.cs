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
    public class EstoqueMap : EntityTypeConfiguration<Estoque>
    {
        //construtor
        public EstoqueMap()
        {
            HasKey(e => e.IdEstoque);

            Property(e => e.Nome)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
