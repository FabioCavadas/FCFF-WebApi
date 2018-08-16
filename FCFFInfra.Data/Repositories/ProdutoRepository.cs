using FCFFDomain.Contracts.Repositories;
using FCFFDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FCFFInfra.Data.Context;

namespace FCFFInfra.Data.Repositories
{
    /// <summary>
    /// Atributo para armazenar o COntexto do EF, construtor para injeção de dependência
    /// </summary>
    public class ProdutoRepository
        : BaseRepository<Produto>, IProdutoRepository

    {
        private readonly DataContext contexto;

        public ProdutoRepository(DataContext contexto)
            : base(contexto)
        {
            this.contexto = contexto;
        }
    }
}
