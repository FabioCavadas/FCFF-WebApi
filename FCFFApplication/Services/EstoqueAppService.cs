using AutoMapper;
using FCFFApplication.Contracts;
using FCFFApplication.ViewModels.Estoques;
using FCFFDomain.Contracts.Services;
using FCFFDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCFFApplication.Services
{
    public class EstoqueAppService : IEstoqueAppService
    {
        private readonly IEstoqueDomainService domain;

        public EstoqueAppService(IEstoqueDomainService domain)
        {
            this.domain = domain;
        }

        public void Cadastrar(EstoqueCadastroViewModel model)
        {
            var e = Mapper.Map<Estoque>(model);
            domain.Cadastrar(e);

        }

        public void Atualizar(EstoqueEdicaoViewModel model)
        {
            var e = Mapper.Map<Estoque>(model);
            domain.Atualizar(e);

        }

        public void Excluir(int idEstoque)
        {
            var e = domain.ConsultarPorId(idEstoque);
            domain.Excluir(e);

        }

        public List<EstoqueConsultaViewModel> ConsultarTodos()
        {
            var lista = new List<EstoqueConsultaViewModel>();
            foreach (var e in domain.ConsultarTodos())
            {
                lista.Add(Mapper.Map<EstoqueConsultaViewModel>(e));
            }

            return lista;

        }

        public EstoqueConsultaViewModel ConsultarPorId(int idEstoque)
        {
            var e = domain.ConsultarPorId(idEstoque);
            return Mapper.Map<EstoqueConsultaViewModel>(e);

        }

    }
}
