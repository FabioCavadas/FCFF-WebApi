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
    /// IEstoqueRepository repository -> Atributo para armazenar o Contexto do EF
    /// EstoqueDomainService(IEstoqueRepository repository) -> construtor para injeção de dependencia
    /// </summary>
    public class EstoqueDomainService
        : BaseDomainService<Estoque>, IEstoqueDomainService
    {
        private readonly IEstoqueRepository repository;

        public EstoqueDomainService(IEstoqueRepository repository)
            : base(repository)
        {
            this.repository = repository;
        }
    }
}
