using FCFFDomain.Contracts.Repositories;
using FCFFInfra.Data.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCFFInfra.Data.Repositories
{
    /// <summary>
    /// Implementando interfaces do Dominio
    /// DataContext contexto -> Atributo para receber o contexto do EF..
    /// BaseRepository(DataContext contexto) - > Construtor que será utilizado pelo Simple Injector para "injetar" espaço de memória do atributo DataContext
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : class
    {
        
        private readonly DataContext contexto; 
        
        public BaseRepository(DataContext contexto)
        {
            this.contexto = contexto;
        }
        
        public int Count()
        {
            return contexto.Set<TEntity>().Count();
        }

        public int Count(Func<TEntity, bool> expression)
        {
            return contexto.Set<TEntity>().Count(expression); 
        }

        public void Delete(TEntity t)
        {
            contexto.Entry(t).State = EntityState.Deleted;
            contexto.SaveChanges();

        }

        public void Dispose()
        {
            contexto.Dispose();
        }

        public TEntity Find(Func<TEntity, bool> expression)
        {
            return contexto.Set<TEntity>().FirstOrDefault(expression);
        }

        public List<TEntity> FindAll()
        {
            return contexto.Set<TEntity>().ToList();
        }

        public List<TEntity> FindAll(Func<TEntity, bool> expression)
        {
            return contexto.Set<TEntity>().Where(expression).ToList();
        }

        public TEntity FindById(int id)
        {
            return contexto.Set<TEntity>().Find(id);
        }

        public void Insert(TEntity t)
        {
            contexto.Entry(t).State = EntityState.Added;
            contexto.SaveChanges();

        }

        public void Update(TEntity t)
        {
            contexto.Entry(t).State = EntityState.Modified;
            contexto.SaveChanges();

        }
    }
}
