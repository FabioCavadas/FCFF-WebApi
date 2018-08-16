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
    /// Atributo para armazenar o Contexto do EF, construtor para injeção de dependência
    /// </summary>
    public class EstoqueRepository 
        : BaseRepository<Estoque>, IEstoqueRepository
    {
        private readonly DataContext contexto;

        public EstoqueRepository(DataContext contexto) 
            : base(contexto)
        {
            this.contexto = contexto;
        }
    }
}
