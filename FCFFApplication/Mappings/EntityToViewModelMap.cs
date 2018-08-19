using AutoMapper;
using FCFFApplication.ViewModels.Estoques;
using FCFFApplication.ViewModels.Produtos;
using FCFFDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCFFApplication.Mappings
{
    /// <summary>
    /// Classe para mapear troca de dados entre Entidade e ViewModel.
    /// ForMember -> Método para especificar um campo na classe de destino especificando como sera preenchido pela classe de origem.
    /// MapFrom -> destina-se a redirecionar membros de origem.
    /// </summary>
    public class EntityToViewModelMap : Profile
    {
        public EntityToViewModelMap()
        {
            CreateMap<Estoque, EstoqueConsultaViewModel>()
                .ForMember(dest => dest.QuantidadeDeProdutos, src => src.MapFrom(e => e.Produtos.Sum(p => p.Quantidade)));


            CreateMap<Produto, ProdutoConsultaViewModel>()
                .ForMember(dest => dest.Total, src => src.MapFrom(p => p.Preco * p.Quantidade))
                .AfterMap(((src, dest) => dest.Estoque = new EstoqueConsultaViewModel {
                    IdEstoque = src.Estoque.IdEstoque,
                    Nome = src.Estoque.Nome,
                    QuantidadeDeProdutos = src.Estoque.Produtos.Sum(p => p.Quantidade)
                }));
        }
    }
}
