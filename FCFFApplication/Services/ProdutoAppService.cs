using AutoMapper;
using FCFFApplication.Contracts;
using FCFFApplication.ViewModels.Produtos;
using FCFFDomain.Contracts.Services;
using FCFFDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCFFApplication.Services
{
    public class ProdutoAppService : IProdutoAppService
    {
        private readonly IProdutoDomainService domain;

        public ProdutoAppService(IProdutoDomainService domain)
        {
            this.domain = domain;
        }

        public void Cadastrar(ProdutoCadastroViewModel model)
        {
            var p = Mapper.Map<Produto>(model);
            domain.Cadastrar(p);

        }

        public void Atualizar(ProdutoEdicaoViewModel model)
        {
            var p = Mapper.Map<Produto>(model);
            domain.Atualizar(p);

        }

        public void Excluir(int idProduto)
        {
            var p = domain.ConsultarPorId(idProduto);
            domain.Excluir(p);

        }

        public List<ProdutoConsultaViewModel> ConsultarTodos()
        {
            var lista = new List<ProdutoConsultaViewModel>();
            foreach (var p in domain.ConsultarTodos())
            {
                lista.Add(Mapper.Map<ProdutoConsultaViewModel>(p));
            }

            return lista;

        }

        public ProdutoConsultaViewModel ConsultarPorId(int idProduto)
        {
            var p = domain.ConsultarPorId(idProduto);
            return Mapper.Map<ProdutoConsultaViewModel>(p);

        }

    }
}
