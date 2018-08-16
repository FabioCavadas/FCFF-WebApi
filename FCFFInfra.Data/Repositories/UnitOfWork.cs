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
    public class UnitOfWork : IUnitOfWork
    {
        //atributo para armazenar o contexto..
        private readonly DataContext contexto;

        //atributo para armazenar a transação..
        private DbContextTransaction transaction;

        //construtor para injeção de dependencia..
        public UnitOfWork(DataContext contexto)
        {
            this.contexto = contexto;
        }

        public IEstoqueRepository EstoqueRepository
            => new EstoqueRepository(contexto);

        public IProdutoRepository ProdutoRepository
            => new ProdutoRepository(contexto);

        public void BeginTransaction()
        {
            transaction = contexto.Database.BeginTransaction();
        }

        public void Commit()
        {
            transaction.Commit();
        }

        public void Rollback()
        {
            transaction.Rollback();
        }


    }
}
