using FCFFDomain.Contracts.Repositories;
using FCFFDomain.Contracts.Services;
using FCFFDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCFFDomain.Services
{
    /// <summary>
    /// IProdutoRepository -> Atributo para armazenar o Contexto do EF
    /// </summary>
    public class ProdutoDomainService
        : BaseDomainService<Produto>, IProdutoDomainService
    {
        private readonly IProdutoRepository repository;

        public ProdutoDomainService(IProdutoRepository repository)
            : base(repository)
        {
            this.repository = repository;
        }

    }
}
