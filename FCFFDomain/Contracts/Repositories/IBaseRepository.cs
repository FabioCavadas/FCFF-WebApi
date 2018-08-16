using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCFFDomain.Contracts.Repositories
{
    public interface IBaseRepository<TEntity> : IDisposable 
        where TEntity : class
    {
        /// <summary>
        /// Métodos genéricos para consultas no Repositório
        /// LAMBDA
        /// </summary>
        /// <param name="t">Parametro da IBaseRepository tipado com TEntity</param>

        void Insert(TEntity t);

        void Update(TEntity t);

        void Delete(TEntity t);

        List<TEntity> FindAll();

        List<TEntity> FindAll(Func<TEntity, bool> expression);

        TEntity Find(Func<TEntity, bool> expression);

        TEntity FindById(int id);

        int Count();

        int Count(Func<TEntity, bool> expression);


    }
}
