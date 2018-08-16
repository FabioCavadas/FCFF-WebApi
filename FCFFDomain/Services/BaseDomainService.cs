using FCFFDomain.Contracts.Repositories;
using FCFFDomain.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCFFDomain.Services
{
    /// <summary>
    /// Implementando as classes de Dominio
    /// IBaseRepository<TEntity> repository -> atributo para acessar o repositorio
    /// BaseDomainService(IBaseRepository<TEntity> repository) -> construtor para injeção de dependencia
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class BaseDomainService<TEntity>
        : IBaseDomainService<TEntity>
        where TEntity : class
    {       
        private readonly IBaseRepository<TEntity> repository;
        
        public BaseDomainService(IBaseRepository<TEntity> repository)
        {
            this.repository = repository;
        }

        public void Cadastrar(TEntity t)
        {
            repository.Insert(t);
        }

        public void Atualizar(TEntity t)
        {
            repository.Update(t);
        }
        
        public void Excluir(TEntity t)
        {
            repository.Delete(t);
        }

        public List<TEntity> ConsultarTodos()
        {
            return repository.FindAll();
        }

        public TEntity ConsultarPorId(int id)
        {
            return repository.FindById(id);
        }        

        public void Dispose()
        {
            repository.Dispose();
        }

    }
}
