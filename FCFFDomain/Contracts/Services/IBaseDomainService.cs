using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCFFDomain.Contracts.Services
{
    /// <summary>
    ///Classe para implementar serviços que o dominio irá entregar para a aplicação 
    /// </summary>
    public interface IBaseDomainService<TEntity> : IDisposable
        where TEntity : class
    {
        void Cadastrar(TEntity t);

        void Atualizar(TEntity t);

        void Excluir(TEntity t);

        List<TEntity> ConsultarTodos();

        TEntity ConsultarPorId(int id);

    }
}
